using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos;
using PortailTE44.Common.Utils;

namespace PortailTE44.Business.Services
{
    public class TestApiEudonetService : ITestApiEudonetService
    {
        protected readonly EudoAPI _eudoAPI;
        public TestApiEudonetService(EudoAPI eudoAPI)
        {
            _eudoAPI = eudoAPI;
        }

        public bool GetTest()
        {
            bool succes = _eudoAPI.Connect();
            if (!succes) return false;
            GetCollectivites();
            _eudoAPI.Disconnect();
            return true;
        }

        public void GetCollectivites()
        {
            List<CollectiviteTestDto> collectiviteDtos = new List<CollectiviteTestDto>();
            // ----------------------------------------------------------------------------------
            // Liste des Communautés de commune
            // ----------------------------------------------------------------------------------
            // Table Entité (300)
            // Type (313) = "2132" (Public)
            // Sous-Catégorie (323) = "2180" (Communautés de communes)
            List<EudoAPI_Row> communauteRows = new List<EudoAPI_Row>();
            EudoAPI_Rootobject? entities_ComCom = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323 },
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
                        entities_ComCom = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323 },
                            new int[] { 313, 323 }, new string[] { "2132", "2180" }, page);
                        // Boucler sur les lignes de résultat des pages suivantes ici
                        if (entities_ComCom?.ResultData?.Rows is not null)
                            communauteRows.AddRange(entities_ComCom.ResultData.Rows);
                    }
                }

                foreach (EudoAPI_Row communauteRow in communauteRows)
                    collectiviteDtos.Add(MapCollectiviteDto(communauteRow, true));
            }

            // ----------------------------------------------------------------------------------
            // Liste des communes
            // ----------------------------------------------------------------------------------
            // Table Entité (300)
            // Type (313) = "2132" (Public)
            // Sous-Catégorie (323) = "2191" (Communes)
            List<EudoAPI_Row> communeRows = new List<EudoAPI_Row>();
            EudoAPI_Rootobject? entities_Communes = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323 },
                new int[] { 313, 323 }, new string[] { "2132", "2191" });

            if (entities_Communes?.ResultData?.Rows is not null)
            {
                communeRows.AddRange(entities_Communes.ResultData.Rows);
                int pageCountCommune = entities_Communes.ResultMetaData.TotalPages;
                if (entities_Communes.ResultMetaData.TotalPages > 1)
                {
                    for (int page = 2; page <= pageCountCommune; page++)
                    {
                        entities_Communes = EudoAPI.QueryByCustoms(300, new int[] { 301, 313, 323 },
                            new int[] { 313, 323 }, new string[] { "2132", "2191" }, page);
                        if (entities_Communes?.ResultData?.Rows is not null)
                            communeRows.AddRange(entities_Communes.ResultData.Rows);
                    }
                }

                foreach (EudoAPI_Row communeRow in communeRows)
                    collectiviteDtos.Add(MapCollectiviteDto(communeRow, false));
            }
        }

        private CollectiviteTestDto MapCollectiviteDto(EudoAPI_Row row, bool isCommunauteCommune)
        {
            CollectiviteTestDto dto = new CollectiviteTestDto();
            //NICH a verifier que l'id correspond bien a ce champ!!
            dto.IdEudonet = row.FileId;
            dto.Libelle = row.Fields is not null ? row.Fields[0].Value : default!;
            dto.CommunauteCommune = isCommunauteCommune;
            return dto;
        }
    }
}
