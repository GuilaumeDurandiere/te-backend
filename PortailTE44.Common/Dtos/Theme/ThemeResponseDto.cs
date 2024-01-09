using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
    public class ThemeResponseDto : ThemeLightResponseDto
    {
		public IEnumerable<SousThemeResponseDto> SousThemes { get; set; } = default!;
	}
}

