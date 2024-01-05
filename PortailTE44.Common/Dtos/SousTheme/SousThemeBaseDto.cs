namespace PortailTE44.Common.Dtos.SousTheme
{
	public class SousThemeBaseDto
	{
        public string Libelle { get; set; } = default!;
        public string? LienExterne { get; set; }
        public bool DemandeSimple { get; set; }
        public bool AccessibleATous { get; set; }
        public string? Description { get; set; }
        public string MailReferent { get; set; } = default!;
        public string Icone { get; set; } = default!;
        public bool HorsTravaux { get; set; }
        public string Couleur { get; set; } = default!;
        public bool? WorkflowTravauxSimplifie { get; set; }
    }
}

