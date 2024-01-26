namespace PortailTE44.Common.Dtos.Affaire
{
	public class AffaireBaseDto
	{
        public string DemandeurNom { get; set; } = default!;
        public string DemandeurPrenom { get; set; } = default!;
        public string DemandeurMail { get; set; } = default!;
        public string DemandeurPoste { get; set; } = default!;
        public DateTime? DateMiseEnService { get; set; }
        public string Adresse { get; set; } = default!;
        public string NumeroVoie { get; set; } = default!;
        public string? Site { get; set; }
        public string Description { get; set; } = default!;
        public int SousThemeId { get; set; }
    }
}

