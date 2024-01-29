using AutoMapper;
using Microsoft.Extensions.Options;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Affaire;
using PortailTE44.Common.Models;
using PortailTE44.DAL.Configurations;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class AffaireService : GenericService<Affaire>, IAffaireService
	{

        IMailService _mailService;
        IOptions<MailSettings> _mailSettings;
        IOptions<MailTemplates> _mailTemplates;
        ISousThemeRepository _sousThemeRepository;

        public AffaireService(IGenericRepository<Affaire> repository,
            IMapper mapper, IMailService mailService, IOptions<MailTemplates> templates, IOptions<MailSettings> settings, ISousThemeRepository sousThemeRepository) : base(repository, mapper)
		{
            _mailService = mailService;
            _mailSettings = settings;
            _mailTemplates = templates;
            _sousThemeRepository = sousThemeRepository;
		}

        public async Task<AffaireResponseDto> Create(AffaireCreatePayloadDto dto)
        {
            Affaire affaire = _mapper.Map<AffaireCreatePayloadDto, Affaire>(dto);
            affaire.NumAffaire = "TestNumAffaire0001";
            affaire.DateCreation = DateTime.Now;
            _repository.Add(affaire);
            await _repository.SaveAsync();
            await SendMailFormulaireDemandeAffaire(dto);
            return _mapper.Map<Affaire, AffaireResponseDto>(affaire);
        }

        public async Task Delete(int id)
        {
            Affaire? affaire = await _repository.GetByIdAsync(id);
            if (affaire is null)
                throw new KeyNotFoundException($"Il n'y a aucune affaire avec l'id {id}");
            _repository.Delete(affaire);
            await _repository.SaveAsync();
        }

        public async Task<AffaireResponseDto> GetById(int id)
        {
            Affaire? affaire = await _repository.GetByIdAsync(id);
            if (affaire is null)
                throw new KeyNotFoundException($"Il n'y a aucune affaire avec l'id {id}");
            return _mapper.Map<Affaire, AffaireResponseDto>(affaire);
        }

        public async Task<AffaireResponseDto> Update(AffaireUpdatePayloadDto dto)
        {
            Affaire? affaire = await _repository.GetByIdAsync(dto.Id);
            if (affaire is null)
                throw new KeyNotFoundException($"Il n'y a aucune affaire avec l'id {dto.Id}");
            affaire.DemandeurNom = dto.DemandeurNom;
            affaire.DemandeurPrenom = dto.DemandeurPrenom;
            affaire.DemandeurMail = dto.DemandeurMail;
            affaire.DemandeurPoste = dto.DemandeurPoste;
            affaire.DateMiseEnService = dto.DateMiseEnService;
            affaire.Adresse = dto.Adresse;
            affaire.NumeroVoie = dto.NumeroVoie;
            affaire.Site = dto.Site;
            affaire.Description = dto.Description;
            _repository.Update(affaire);
            await _repository.SaveAsync();
            return _mapper.Map<Affaire, AffaireResponseDto>(affaire);
        }

        public async Task<bool> SendMailFormulaireDemandeAffaire(AffaireCreatePayloadDto dto)
        {
            SousTheme? sousTheme = await _sousThemeRepository.GetByIdAsync(dto.SousThemeId);

            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.SousThemeId}");

            return await SendMailFormulaireDemandeAffaireResponsable(dto, sousTheme) && await SendMailFormulaireDemandeAffaireUtilisateur(dto, sousTheme);
        }

        private async Task<bool> SendMailFormulaireDemandeAffaireResponsable(AffaireCreatePayloadDto dto, SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireDemandeAffaireResponsable(dto, sousTheme), new CancellationToken());
        }

        private async Task<bool> SendMailFormulaireDemandeAffaireUtilisateur(AffaireCreatePayloadDto dto, SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireDemandeAffaireUtilisateur(dto, sousTheme), new CancellationToken());
        }

        private MailData BuildMailFormulaireDemandeAffaireResponsable(AffaireCreatePayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireDemandeAffaireResponsableTemplate formulaireDemandeAffaireResponsableTemplate = _mailTemplates.Value.FormulaireDemandeAffaireResponsable;
            string template = File.ReadAllText(formulaireDemandeAffaireResponsableTemplate.Path);
            string mail = string.Format(template, _mailSettings.Value.DisplayName, DateTime.Now.ToString("dd/MM/yyyy"), sousTheme.Theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", "Lien Demandeur", "Lien fichier", "Signature");
            data.Subject = string.Format(formulaireDemandeAffaireResponsableTemplate.Subject, _mailSettings.Value.DisplayName, "Nom collectivité");
            data.To = new List<string>() { sousTheme.MailReferent! };
            data.Body = mail;
            return data;
        }

        private MailData BuildMailFormulaireDemandeAffaireUtilisateur(AffaireCreatePayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireDemandeAffaireUtilisateurTemplate formulaireDemandeAffaireUtilisateurTemplate = _mailTemplates.Value.FormulaireDemandeAffaireUtilisateur;
            string template = File.ReadAllText(formulaireDemandeAffaireUtilisateurTemplate.Path);
            string mail = string.Format(template, sousTheme.Libelle, DateTime.Now.ToString("dd/MM/yyyy"), _mailSettings.Value.DisplayName, "link", "Signature");
            data.Subject = string.Format(formulaireDemandeAffaireUtilisateurTemplate.Subject, _mailSettings.Value.DisplayName, sousTheme.Libelle);
            data.To = new List<string>() { dto.DemandeurMail };
            data.Body = mail;
            return data;
        }
    }
}

