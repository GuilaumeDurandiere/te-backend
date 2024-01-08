using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
	public class ThemeCreatePayloadDto : ThemeBaseDto
	{
		public IEnumerable<SousThemeCreateOrUpdatePayloadDto> SousTheme { get; set; } = default!;
	}
}

