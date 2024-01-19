using Microsoft.Extensions.Options;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;
using PortailTE44.Common.Enums;
using PortailTE44.Common.Models;
using PortailTE44.DAL.Configurations;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class FormulaireSimplifieService : IFormulaireSimplifieService
	{
        ISousThemeRepository _sousThemeRepository;
        IMailService _mailService;
        IOptions<MailSettings> _mailSettings;
        IOptions<MailTemplates> _mailTemplates;

		public FormulaireSimplifieService(ISousThemeRepository sousThemeRepository, IMailService mailService, IOptions<MailTemplates> templates, IOptions<MailSettings> settings)
        { 
            _sousThemeRepository = sousThemeRepository;
            _mailService = mailService;
            _mailSettings = settings;
            _mailTemplates = templates;
        }

        public async Task<bool> SendMailFormulaireSimplifie(FormulaireSimplifiePayloadDto dto)
        {
            SousTheme? sousTheme = await _sousThemeRepository.GetByIdAsync(dto.SousThemeId);

            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.SousThemeId}");

            if (sousTheme.RefTypeOffre.Id != (int)RefTypeOffreEnum.FORMULAIRE_SIMPLIFIE)
                throw new Exception("Il ne s'agit pas d'un formulaire simplifié");

            return await SendMailFormulaireSimplifieResponsable(dto, sousTheme) && await SendMailFormulaireSimplifieUtilisateur(dto, sousTheme);
        }

        private async Task<bool> SendMailFormulaireSimplifieResponsable(FormulaireSimplifiePayloadDto dto, SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireSimplifieResponsable(dto, sousTheme), new CancellationToken());
        }

        private async Task<bool> SendMailFormulaireSimplifieUtilisateur(FormulaireSimplifiePayloadDto dto, SousTheme sousTheme)
        {
            return await _mailService.SendAsync(BuildMailFormulaireSimplifieUtilisateur(sousTheme), new CancellationToken());
        }

        private MailData BuildMailFormulaireSimplifieResponsable(FormulaireSimplifiePayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireSimplifieResponsableTemplate formulaireSimplifieResponsableTemplate = _mailTemplates.Value.FormulaireSimplifieResponsable;
            string template = File.ReadAllText(formulaireSimplifieResponsableTemplate.Path);
            string mail = string.Format(template, _mailSettings.Value.DisplayName, DateTime.Now.ToString("dd/MM/yyyy"), 1, sousTheme.Theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", dto.Telephone, dto.Message, "Signature");
            data.Subject = string.Format(formulaireSimplifieResponsableTemplate.Subject, _mailSettings.Value.DisplayName, 1, sousTheme.Libelle);
            data.To = new List<string>() { sousTheme.MailReferent! };
            data.Body = mail;
            return data;
        }

        private MailData BuildMailFormulaireSimplifieUtilisateur(SousTheme sousTheme)
        {
            MailData data = new MailData();
            FormulaireSimplifieUtilisateurTemplate formulaireSimplifieUtilisateurTemplate = _mailTemplates.Value.FormulaireSimplifieUtilisateur;
            string template = File.ReadAllText(formulaireSimplifieUtilisateurTemplate.Path);
            string mail = string.Format(template, 1, sousTheme.Libelle, DateTime.Now.ToString("dd/MM/yyyy"), _mailSettings.Value.DisplayName);
            data.Subject = string.Format(formulaireSimplifieUtilisateurTemplate.Subject, _mailSettings.Value.DisplayName, 1, sousTheme.Libelle);
            data.To = new List<string>() { sousTheme.MailReferent! };
            data.Body = mail;
            return data;
        }
    }
}

