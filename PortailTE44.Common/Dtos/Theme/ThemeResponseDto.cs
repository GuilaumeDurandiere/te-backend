using System;
using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Common.Dtos.Theme
{
	public class ThemeResponseDto : ThemeBaseDto
	{
		public int Id { get; set; }
		public IEnumerable<SousThemeResponseDto> SousThemes { get; set; } = default!;
	}
}

