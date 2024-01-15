using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.Common.Enums;
using PortailTE44.Common.Models;

namespace PortailTE44.Business.Services
{
	public class FormulaireSimplifieService : IFormulaireSimplifieService
	{
        IThemeService _themeService;
        ISousThemeService _sousThemeService;
        IMailService _mailService;

		public FormulaireSimplifieService(IThemeService themeService, ISousThemeService sousThemeService, IMailService mailService)
		{
            _themeService = themeService;
            _sousThemeService = sousThemeService;
            _mailService = mailService;
		}

        public async Task<bool> FormulaireSimplifieResponsable(FormulaireSimplifieResponsableDto dto)
        {
            ThemeResponseDto theme = await _themeService.GetById(dto.ThemeId);
            SousThemeResponseDto sousTheme = await _sousThemeService.GetById(dto.SousThemeId);
            if(sousTheme.RefTypeOffre.Id != (int)RefTypeOffreEnum.FORMULAIRE_SIMPLIFIE)
            {
                throw new Exception("Il ne s'agit pas d'un formulaire simplifiée");
            }
            MailData data = new MailData();
            string template = File.ReadAllText("../PortailTE44.Common/Template/FormulaireSimplifieResponsable.html");
            string mail = string.Format(template, "Te44", DateTime.Now, 1, theme.Libelle, sousTheme.Libelle, "Origine", "Demandeur", dto.Telephone, "Signature");
            data.Subject = "Formulaire Simplifié";
            data.From = "pattie.raynor41@ethereal.email";
            data.To = new List<string>() { "stephane.fonte@gmail.com" };
            data.Body = mail;

            return await _mailService.SendAsync(data, new CancellationToken());
        }
    }
}

