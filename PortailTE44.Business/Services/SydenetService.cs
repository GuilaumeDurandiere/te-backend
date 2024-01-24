using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Sydenet;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class SydenetService : ISydenetService
    {
        protected readonly int competenceServiceFieldId = 1602;
        protected readonly int natureCompetence = 3275;
        protected readonly int natureService = 3276;
        protected readonly int typeCommCommunes = 345;
        protected readonly int typeCommune = 319;
        IGenericRepository<Collectivite> _collectiviteRepository;
        IGenericRepository<ServiceCompetence> _serviceCompetenceRepository;


        protected readonly EudoAPI _eudoAPI;
        public SydenetService(IGenericRepository<Collectivite> collectiviteRepository,
                              IGenericRepository<ServiceCompetence> serviceCompetenceRepository,
                              EudoAPI eudoAPI)
        {
            _eudoAPI = eudoAPI;
            _collectiviteRepository = collectiviteRepository;
            _serviceCompetenceRepository = serviceCompetenceRepository;
        }

        public async Task<bool> SynchronizeServiceCompetences()
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<ServiceCompetenceDto> dtos = GetServiceCompetencesDtos();
            IEnumerable<ServiceCompetence> serviceCompetences = await _serviceCompetenceRepository.GetAllAsync();
            foreach (ServiceCompetenceDto dto in dtos)
            {
                ServiceCompetence? serviceCompetence = serviceCompetences.FirstOrDefault(s => s.SydenetId == dto.SydenetId);
                if (serviceCompetence is not null)
                {//le serviceCompetence existe deja en base, on met à jour ses champs
                    serviceCompetence.Libelle = dto.Libelle;
                    serviceCompetence.SydenetId = dto.SydenetId;
                    serviceCompetence.Competence = dto.Competence;
                    _serviceCompetenceRepository.Update(serviceCompetence);
                }
                else
                {//le serviceCompetence n'existe pas en base, on l'ajoute
                    ServiceCompetence nouveauServiceCompetence = new ServiceCompetence();
                    nouveauServiceCompetence.Libelle = dto.Libelle;
                    nouveauServiceCompetence.SydenetId = dto.SydenetId;
                    nouveauServiceCompetence.Competence = dto.Competence;
                    _serviceCompetenceRepository.Add(nouveauServiceCompetence);
                }
            }
            await _serviceCompetenceRepository.SaveAsync();
            _eudoAPI.Disconnect();
            return true;
        }

        public async Task<bool> SynchronizeCollectivites()
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<CollectiviteDto> dtos = GetCollectivites();
            IEnumerable<Collectivite> collectivites = await _collectiviteRepository.GetAllAsync();
            foreach (CollectiviteDto dto in dtos)
            {
                Collectivite? collectivite = collectivites.FirstOrDefault(c => c.CodeInsee == dto.CodeInsee);
                if (collectivite is not null)
                {//la collectivite existe deja en base, on met à jour ses champs
                    collectivite.Libelle = dto.Libelle;
                    collectivite.SydenetId = dto.SydenetId;
                    collectivite.Siret = dto.Siret;
                    collectivite.CommunauteCommune = dto.CommunauteCommune;
                    _collectiviteRepository.Update(collectivite);
                }
                else
                {//la collectivite n'existe pas en base, on l'ajoute
                    Collectivite nouvelleCollectivite = new Collectivite();
                    nouvelleCollectivite.CodeInsee = dto.CodeInsee;
                    nouvelleCollectivite.Libelle = dto.Libelle;
                    nouvelleCollectivite.SydenetId = dto.SydenetId;
                    nouvelleCollectivite.Siret = dto.Siret;
                    nouvelleCollectivite.CommunauteCommune = dto.CommunauteCommune;
                    _collectiviteRepository.Add(nouvelleCollectivite);
                }
            }
            await _collectiviteRepository.SaveAsync();
            _eudoAPI.Disconnect();
            return true;
        }

        public bool GetSydenetCompetencesByCommunauteCommune(string codeInsee)
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<ServiceCompetenceCollectiviteDto> dtos = GetCompetencesServicesByCollectivite(codeInsee, natureCompetence.ToString(), typeCommCommunes, true);
            _eudoAPI.Disconnect();
            return true;
        }

        public bool GetSydenetCompetencesByCommune(string codeInsee)
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<ServiceCompetenceCollectiviteDto> dtos = GetCompetencesServicesByCollectivite(codeInsee, natureCompetence.ToString(), typeCommune, true);
            _eudoAPI.Disconnect();
            return true;
        }

        public bool GetSydenetServicesByCommunauteCommune(string codeInsee)
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<ServiceCompetenceCollectiviteDto> dtos = GetCompetencesServicesByCollectivite(codeInsee, natureService.ToString(), typeCommCommunes, false);
            _eudoAPI.Disconnect();
            return true;
        }

        public bool GetSydenetServicesByCommune(string codeInsee)
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            IEnumerable<ServiceCompetenceCollectiviteDto> dtos = GetCompetencesServicesByCollectivite(codeInsee, natureService.ToString(), typeCommune, false);
            _eudoAPI.Disconnect();
            return true;
        }

        public IEnumerable<CollectiviteDto> GetCollectivites()
        {
            List<CollectiviteDto> collectiviteDtos = new List<CollectiviteDto>();
            // ----------------------------------------------------------------------------------
            // Liste des Communautés de commune
            // ----------------------------------------------------------------------------------
            // Table Entité (300)
            // Type (313) = "2132" (Public)
            // Sous-Catégorie (323) = "2180" (Communautés de communes)
            List<EudoAPI_Row> communauteRows = new List<EudoAPI_Row>();
            EudoAPI_Rootobject? entities_ComCom = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323, 345, 316 },
                new int[] { 313, 323 }, new string[] { "2132", "2180" });

            if (entities_ComCom?.ResultData?.Rows is not null)
            {
                communauteRows.AddRange(entities_ComCom.ResultData.Rows);
                // Boucler sur les lignes de résultat de la page 1 ici
                int pageCountCommunCommune = entities_ComCom.ResultMetaData.TotalPages;
                if (entities_ComCom.ResultMetaData.TotalPages > 1)
                {
                    for (int page = 2; page <= pageCountCommunCommune; page++)
                    {
                        entities_ComCom = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323, 345, 316 },
                            new int[] { 313, 323 }, new string[] { "2132", "2180" }, page);
                        // Boucler sur les lignes de résultat des pages suivantes ici
                        if (entities_ComCom?.ResultData?.Rows is not null)
                            communauteRows.AddRange(entities_ComCom.ResultData.Rows);
                    }
                }

                collectiviteDtos.AddRange(MapCollectiviteDtos(communauteRows, true));
            }

            // ----------------------------------------------------------------------------------
            // Liste des communes
            // ----------------------------------------------------------------------------------
            // Table Entité (300)
            // Type (313) = "2132" (Public)
            // Sous-Catégorie (323) = "2191" (Communes)
            List<EudoAPI_Row> communeRows = new List<EudoAPI_Row>();
            EudoAPI_Rootobject? entities_Communes = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323, 319, 316 },
                new int[] { 313, 323 }, new string[] { "2132", "2191" });

            if (entities_Communes?.ResultData?.Rows is not null)
            {
                communeRows.AddRange(entities_Communes.ResultData.Rows);
                int pageCountCommune = entities_Communes.ResultMetaData.TotalPages;
                if (entities_Communes.ResultMetaData.TotalPages > 1)
                {
                    for (int page = 2; page <= pageCountCommune; page++)
                    {
                        entities_Communes = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323, 319, 316 },
                            new int[] { 313, 323 }, new string[] { "2132", "2191" }, page);
                        if (entities_Communes?.ResultData?.Rows is not null)
                            communeRows.AddRange(entities_Communes.ResultData.Rows);
                    }
                }

                collectiviteDtos.AddRange(MapCollectiviteDtos(communeRows, false));
            }
            return collectiviteDtos.Where(d => !string.IsNullOrWhiteSpace(d.CodeInsee));
        }

        public IEnumerable<ServiceCompetenceDto> GetServiceCompetencesDtos()
        {
            List<ServiceCompetenceDto> dtos = new List<ServiceCompetenceDto>();
            //1602 = nature (competences et services)
            EudoAPI_Root? result = EudoAPI.QueryCatalog(1602);
            if (result?.ResultData?.CatalogValues is not null)
                dtos.AddRange(MapServiceCompetenceDtos(result.ResultData.CatalogValues));

            return dtos;
        }

        /// <summary>
        /// Retourne la liste des services ou des compétence d'une collectivité 
        /// </summary>
        /// <param name="codeInsee">code insee de la collectivite</param>
        /// <param name="sydenetCodeNature">champ competence ou service dans sydenet [compétence|service]</param>
        /// <param name="sydenetCodeInsee">champ code insee dans sydenet</param>
        public IEnumerable<ServiceCompetenceCollectiviteDto> GetCompetencesServicesByCollectivite(string codeInsee, string sydenetCodeNature, int sydenetCodeInsee, bool isCompetence)
        {
            List<EudoAPI_Row> competencesRows = new List<EudoAPI_Row>();
            EudoAPI_Rootobject? queryResult = SydenetQueryTableCompetenceService(codeInsee, sydenetCodeNature, sydenetCodeInsee);
            if (queryResult?.ResultData?.Rows is not null)
            {
                competencesRows.AddRange(queryResult.ResultData.Rows);
                int pageCount = queryResult.ResultMetaData.TotalPages;
                if (queryResult.ResultMetaData.TotalPages > 1)
                {
                    for (int page = 2; page <= pageCount; page++)
                    {
                        queryResult = SydenetQueryTableCompetenceService(codeInsee, sydenetCodeNature, sydenetCodeInsee);
                        if (queryResult?.ResultData?.Rows is not null)
                            competencesRows.AddRange(queryResult.ResultData.Rows);
                    }
                }
            }

            return MapServiceCompetenceDtos(competencesRows, competenceServiceFieldId, isCompetence);
        }

        private EudoAPI_Rootobject? SydenetQueryTableCompetenceService(string codeInsee, string sydenetCodeNature, int sydenetCodeInsee)
        {
            int tableCompetenceService = 1600;
            int champNature = 1601;
            int champDatePriseEffet = 1605;
            return EudoAPI.QueryByCustoms(tableCompetenceService, new int[] { champNature, competenceServiceFieldId, 301, champDatePriseEffet },
                new int[] { champNature, sydenetCodeInsee }, new string[] { sydenetCodeNature, codeInsee });
        }

        private IEnumerable<CollectiviteDto> MapCollectiviteDtos(IEnumerable<EudoAPI_Row> rows, bool isCommunauteCommune)
        {
            int libelleId = 301;
            int codeInseeComcom = 345;
            int codeInseeCommune = 319;
            int codeSirect = 316;
            List<CollectiviteDto> dtos = new List<CollectiviteDto>();
            foreach (EudoAPI_Row row in rows)
            {
                if (row.Fields is not null)
                {
                    CollectiviteDto dto = new CollectiviteDto();
                    dto.SydenetId = row.FileId.ToString();
                    EudoAPI_Field? codeInseeField = isCommunauteCommune ? row.Fields!.FirstOrDefault(f => f.DescId == codeInseeComcom) : row.Fields!.FirstOrDefault(f => f.DescId == codeInseeCommune);
                    dto.CodeInsee = codeInseeField is not null ? codeInseeField.Value : default!;
                    EudoAPI_Field? libelleField = row.Fields!.FirstOrDefault(f => f.DescId == libelleId);
                    dto.Libelle = libelleField is not null ? libelleField.Value : default!;
                    EudoAPI_Field? siretField = row.Fields!.FirstOrDefault(f => f.DescId == codeSirect);
                    dto.Siret = siretField is not null ? siretField.Value : default!;
                    dto.CommunauteCommune = isCommunauteCommune;
                    dtos.Add(dto);
                }
            }
            return dtos.DistinctBy(d => d.SydenetId);
        }

        private IEnumerable<ServiceCompetenceDto> MapServiceCompetenceDtos(IEnumerable<EudoAPI_CatalogValue> values)
        {
            int competenceId = 3275;
            List<ServiceCompetenceDto> dtos = new List<ServiceCompetenceDto>();
            foreach (EudoAPI_CatalogValue value in values)
            {
                ServiceCompetenceDto dto = new ServiceCompetenceDto();
                dto.SydenetId = value.DbValue;
                dto.Libelle = value.DisplayValue;
                dto.Competence = value.ParentId == competenceId;
                dtos.Add(dto);
            }
            return dtos.DistinctBy(d => d.SydenetId);
        }

        private IEnumerable<ServiceCompetenceCollectiviteDto> MapServiceCompetenceDtos(IEnumerable<EudoAPI_Row> rows, int competenceFieldId, bool isCompetence)
        {
            int compDatePriseEffetField = 1605;
            List<ServiceCompetenceCollectiviteDto> dtos = new List<ServiceCompetenceCollectiviteDto>();
            foreach (EudoAPI_Row row in rows)
            {
                if (row.Fields is not null && row.Fields.Any(f => f.DescId == competenceFieldId))
                {
                    ServiceCompetenceCollectiviteDto dto = new ServiceCompetenceCollectiviteDto();
                    EudoAPI_Field competence = row.Fields.First(f => f.DescId == competenceFieldId);
                    dto.SydenetId = competence.DbValue;
                    dto.Libelle = competence.Value;
                    dto.Competence = isCompetence;
                    EudoAPI_Field? compDatePriseEffet = row.Fields!.FirstOrDefault(f => f.DescId == compDatePriseEffetField);
                    dto.DatePriseEffet = compDatePriseEffet is not null && compDatePriseEffet.DbValue is not null ? DateTime.Parse(compDatePriseEffet.DbValue) : null;
                    dtos.Add(dto);
                }
            }
            return dtos.DistinctBy(d => d.SydenetId);
        }
    }
}
