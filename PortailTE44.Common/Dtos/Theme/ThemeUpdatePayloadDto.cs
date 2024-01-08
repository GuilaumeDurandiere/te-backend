using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
	public class ThemeUpdatePayloadDto : ThemeBaseDto
	{
		public int Id { get; set; }

		public IEnumerable<SousThemeCreateOrUpdatePayloadDto> SousThemes { get; set; } = default!;
	}
}

