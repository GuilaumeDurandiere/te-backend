namespace PortailTE44.DAL.Entities
{
    public class RefTypeOffre : BaseEntity
    {
        public string Code { get; set; } = default!;
        public string Libelle { get; set; } = default!;
        public IEnumerable<SousTheme> SousThemes { get; set; } = default!;
    }
}
