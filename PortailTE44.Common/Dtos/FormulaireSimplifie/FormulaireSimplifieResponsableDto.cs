namespace PortailTE44.Common.Dtos.Demande
{
	public class FormulaireSimplifieResponsableDto
	{
		public string Message { get; set; } = default!;
		public string Telephone { get; set; } = default!;
		public int ThemeId { get; set; }
		public int SousThemeId { get; set; }
	}
}

