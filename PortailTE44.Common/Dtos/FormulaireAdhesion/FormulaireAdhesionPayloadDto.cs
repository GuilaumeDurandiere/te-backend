namespace PortailTE44.Common.Dtos.FormulaireAdhesion
{
	public class FormulaireAdhesionPayloadDto
	{
		public string Message { get; set; } = default!;
		public string Telephone { get; set; } = default!;
		public int SousThemeId { get; set; }
	}
}

