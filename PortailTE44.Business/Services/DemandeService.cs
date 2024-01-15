using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.Common.Dtos.Theme;

namespace PortailTE44.Business.Services
{
	public class DemandeService : IDemandeService
	{
        IThemeService _themeService;
        ISousThemeService _sousThemeService;

		public DemandeService(IThemeService themeService, ISousThemeService sousThemeService)
		{
            _themeService = themeService;
            _sousThemeService = sousThemeService;
		}

        public async Task<bool> DemandeFormulaireSimplifieResponsable(DemandeFormulaireSimplifieResponsableDto dto)
        {
            ThemeResponseDto theme = await _themeService.GetById(dto.ThemeId);
            SousThemeResponseDto sousTheme = await _sousThemeService.GetById(dto.SousThemeId);

            return null;
        }
    }
}

