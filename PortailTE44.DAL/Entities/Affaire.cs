namespace PortailTE44.DAL.Entities
{
	public class Affaire : BaseEntity
	{
		public string NumAffaire { get; set; } = default!;
		public DateTime DateCreation { get; set; } = default!;
		public DateTime? DateMiseEnService { get; set; }
		public string Adresse { get; set; } = default!;
		public string NumeroVoie { get; set; } = default!;
		public string? Site { get; set; }
		public DateTime? DateValidationFacture { get; set; }
		public string Description { get; set; } = default!;
		public string? Commentaire { get; set; }
		public DateTime? DateCloture { get; set; }
		public bool HorsTravaux { get; set; }
		public string DemandeurNom { get; set; } = default!;
		public string DemandeurPrenom { get; set; } = default!;
		public string DemandeurMail { get; set; } = default!;
		public string DemandeurPoste { get; set; } = default!;
		public int? ContactTechniqueId { get; set; }
		public int? ContactAdministratif { get; set; }
		public SousTheme SousTheme { get; set; } = default!;
		public int SousThemeId { get; set; }
		public int? CollectiviteId { get; set; }

	}
}

