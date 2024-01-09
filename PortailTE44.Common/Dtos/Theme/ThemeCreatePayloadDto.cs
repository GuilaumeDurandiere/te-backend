using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
    public class ThemeCreatePayloadDto : ThemeBaseDto
    {
        public IEnumerable<SousThemeCreatePayloadDto> SousThemes { get; set; } = default!;
    }
}

