using Microsoft.Extensions.Options;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;
using PortailTE44.Common.Enums;
using PortailTE44.Common.Models;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class FormulaireSimplifieService : IFormulaireSimplifieService
	{
        ISousThemeRepository _sousThemeRepository;
        IMailService _mailService;
        FormulaireSimplifieResponsableTemplate formulaireSimplifieResponsableTemplate;

		public FormulaireSimplifieService(ISousThemeRepository sousThemeRepository, IMailService mailService, IOptions<MailTemplates> options)
        { 
            _sousThemeRepository = sousThemeRepository;
            _mailService = mailService;
            formulaireSimplifieResponsableTemplate = options.Value.FormulaireSimplifieResponsable;

        }

        public async Task<bool> FormulaireSimplifieResponsable(FormulaireSimplifieResponsablePayloadDto dto)
        {
            SousTheme? sousTheme = await _sousThemeRepository.GetByIdAsync(dto.SousThemeId);
            if(sousTheme is null)
            {
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.SousThemeId}");
            }

            if(sousTheme.RefTypeOffre.Id != (int)RefTypeOffreEnum.FORMULAIRE_SIMPLIFIE)
            {
                throw new Exception("Il ne s'agit pas d'un formulaire simplifiée");
            }
            

            return await _mailService.SendAsync(BuildMailData(dto, sousTheme), new CancellationToken());
        }

        private MailData BuildMailData(FormulaireSimplifieResponsablePayloadDto dto, SousTheme sousTheme)
        {
            MailData data = new MailData();
            string template = File.ReadAllText(formulaireSimplifieResponsableTemplate.Path);
            string mail = string.Format(template, "Te44", DateTime.Now, 1, sousTheme.Theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", dto.Telephone, "Signature");
            data.Subject = formulaireSimplifieResponsableTemplate.Subject;
            data.To = new List<string>() { sousTheme.MailReferent };
            data.Body = mail;
            return data;
        }
    }
}

