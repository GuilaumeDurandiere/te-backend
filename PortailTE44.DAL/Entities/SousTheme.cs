namespace PortailTE44.DAL.Entities
{
	public class SousTheme : BaseEntity
	{
		public string Libelle { get; set; } = default!;
		public string? LienExterne { get; set; }
		public bool AccessibleATous { get; set; }
		public string? Description { get; set; }
        public string? MailReferent { get; set; } = default!;
        public string Couleur { get; set; } = default!;
		public bool WorkflowTravauxSimplifie { get; set; }
        public byte[]? Icone { get; set; }
        public int ThemeId { get; set; } = default!;
        public int? WorkflowId { get; set; }
        public int RefTypeOffreId { get; set; }
        public Theme Theme { get; set; } = default!;
        public Workflow? Workflow { get; set; }
		public IEnumerable<SousThemeCollectivite>? SousThemeCollectivites { get; set; }
		public RefTypeOffre RefTypeOffre { get; set; } = default!;
    }
}

