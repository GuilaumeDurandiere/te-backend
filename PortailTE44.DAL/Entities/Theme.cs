namespace PortailTE44.DAL.Entities
{
    public class Theme : BaseEntity
	{
		public string Libelle { get; set; } = default!;
		public string? Description { get; set; }
        //NICH TEST
        //public string? Icone { get; set; }
        public byte[]? Icone { get; set; }
        public IEnumerable<SousTheme> SousThemes { get; set; } = default!;
	}
}

