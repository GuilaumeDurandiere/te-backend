namespace PortailTE44.DAL.Entities
{
	public class SousTheme : BaseEntity
	{
		public string Libelle { get; set; } = default!;
		public string? LienExterne { get; set; }
		public bool DemandeSimple { get; set; }
		public string? TypeWorkflow { get; set; }
		public bool Accessible { get; set; }
		public string? Description { get; set; }
		public string MailReferent { get; set; } = default!;
		public Theme Theme { get; set; } = default!;
	}

}

