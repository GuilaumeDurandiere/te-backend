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
        FormulaireSimplifieResponsableTemplate formulaireSimplifieResponsableTemplate;

		public FormulaireSimplifieService(ISousThemeRepository sousThemeRepository, IMailService mailService, IOptions<MailTemplates> templates, IOptions<MailSettings> settings)
        { 
            _sousThemeRepository = sousThemeRepository;
            _mailService = mailService;
            _mailSettings = settings;
            formulaireSimplifieResponsableTemplate = templates.Value.FormulaireSimplifieResponsable;
        }

        public async Task<bool> FormulaireSimplifieResponsable(FormulaireSimplifieResponsablePayloadDto dto)
        {
            SousTheme? sousTheme = await _sousThemeRepository.GetByIdAsync(dto.SousThemeId);

            if(sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.SousThemeId}");

            if(sousTheme.RefTypeOffre.Id != (int)RefTypeOffreEnum.FORMULAIRE_SIMPLIFIE)
                throw new Exception("Il ne s'agit pas d'un formulaire simplifié");
            
            return await _mailService.SendAsync(BuildFormulaireSimplifieResponsableMail(dto, sousTheme), new CancellationToken());
        }

        private MailData BuildFormulaireSimplifieResponsableMail(FormulaireSimplifieResponsablePayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            string template = File.ReadAllText(formulaireSimplifieResponsableTemplate.Path);
            string mail = string.Format(template, _mailSettings.Value.DisplayName, DateTime.Now, 1, sousTheme.Theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", dto.Telephone, dto.Message, "Signature");
            data.Subject = formulaireSimplifieResponsableTemplate.Subject;
            data.To = new List<string>() { sousTheme.MailReferent };
            data.Body = mail;
            return data;
        }
    }
}

