using Microsoft.AspNetCore.Http;
using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
    //TEST NICH
    //public class ThemeCreatePayloadDto : ThemeBaseDto
    public class ThemeCreatePayloadDto
    {
		public IEnumerable<SousThemeCreateOrUpdatePayloadDto> SousThemes { get; set; } = default!;
        public string Libelle { get; set; } = default!;
        public string? Description { get; set; }
        //NICH image
        //public string? Icone { get; set; }
        //public IFormFile? Icone { get; set; } = default!;
        public IFormFile? IconeFile { get; set; } = default!;

    }
}

