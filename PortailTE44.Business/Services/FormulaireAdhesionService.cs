using Microsoft.Extensions.Options;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.FormulaireAdhesion;
using PortailTE44.Common.Models;
using PortailTE44.DAL.Configurations;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class FormulaireAdhesionService : IFormulaireAdhesionService
	{

        ISousThemeRepository _sousThemeRepository;
        IMailService _mailService;
        IOptions<MailSettings> _mailSettings;
        IOptions<MailTemplates> _mailTemplates;

        public FormulaireAdhesionService(ISousThemeRepository sousThemeRepository, IMailService mailService, IOptions<MailTemplates> templates, IOptions<MailSettings> settings)
        {
            _sousThemeRepository = sousThemeRepository;
            _mailService = mailService;
            _mailSettings = settings;
            _mailTemplates = templates;
        }

        public async Task<bool> SendMailFormulaireAdhesion(FormulaireAdhesionPayloadDto dto)
        {
            SousTheme? sousTheme = await _sousThemeRepository.GetByIdAsync(dto.SousThemeId);

            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.SousThemeId}");

            return await SendMailFormulaireAdhesionResponsableOffre(dto, sousTheme) && await SendMailFormulaireAdhesionResponsableCollectivite(sousTheme);
        }

        private async Task<bool> SendMailFormulaireAdhesionResponsableOffre(FormulaireAdhesionPayloadDto dto, SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireAdhesionResponsableOffre(dto, sousTheme), new CancellationToken());
        }

        private async Task<bool> SendMailFormulaireAdhesionResponsableCollectivite(SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireAdhesionResponsableCollectivite(sousTheme), new CancellationToken());
        }

        private MailData BuildMailFormulaireAdhesionResponsableOffre(FormulaireAdhesionPayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireAdhesionResponsableOffreTemplate formulaireSimplifieResponsableTemplate = _mailTemplates.Value.FormulaireAdhesionResponsableOffre;
            string template = File.ReadAllText(formulaireSimplifieResponsableTemplate.Path);
            string mail = string.Format(template, _mailSettings.Value.DisplayName, DateTime.Now.ToString("dd/MM/yyyy"), sousTheme.Theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", dto.Telephone, dto.Message, "Signature");
            data.Subject = string.Format(formulaireSimplifieResponsableTemplate.Subject, _mailSettings.Value.DisplayName, "Collectivite");
            data.To = new List<string>() { sousTheme.MailReferent! };
            data.Body = mail;
            return data;
        }

        private MailData BuildMailFormulaireAdhesionResponsableCollectivite(SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireAdhesionResponsableCollectiviteTemplate formulaireSimplifieUtilisateurTemplate = _mailTemplates.Value.FormulaireAdhesionResponsableCollectivite;
            string template = File.ReadAllText(formulaireSimplifieUtilisateurTemplate.Path);
            string mail = string.Format(template, sousTheme.Libelle, DateTime.Now.ToString("dd/MM/yyyy"), _mailSettings.Value.DisplayName);
            data.Subject = string.Format(formulaireSimplifieUtilisateurTemplate.Subject, _mailSettings.Value.DisplayName, sousTheme.Libelle);
            data.To = new List<string>() { sousTheme.MailReferent! };
            data.Body = mail;
            return data;
        }
    }
}

