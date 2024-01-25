namespace PortailTE44.Common.Dtos.PreferenceUtilisateurAffichageAffaire
{
	public class PreferenceUtilisateurAffichageAffaireBaseDto
	{
        public int UtilisateurId { get; set; }
        public string? Communautes { get; set; }
        public string? Communes { get; set; }
        public string Themes { get; set; } = default!;
        public string SousThemes { get; set; } = default!;
        public string? Responsables { get; set; }
        public DateOnly? AvantLe { get; set; }
        public DateOnly? ApresLe { get; set; }
        public int NumeroAffaire { get; set; }
    }
}

