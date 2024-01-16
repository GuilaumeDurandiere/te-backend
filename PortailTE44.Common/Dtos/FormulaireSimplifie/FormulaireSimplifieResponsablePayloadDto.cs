namespace PortailTE44.Common.Dtos.Demande
{
	public class FormulaireSimplifieResponsablePayloadDto
	{
		public string Message { get; set; } = default!;
		public string Telephone { get; set; } = default!;
		public int SousThemeId { get; set; }
	}
}

