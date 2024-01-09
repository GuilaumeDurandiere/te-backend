namespace PortailTE44.DAL.Entities
{
    public class SousThemeCollectivite : BaseEntity
    {
        public int SousThemeId { get; set; }
        public int CollectiviteId { get; set; }
        public SousTheme SousTheme { get; set; } = default!;
        public Collectivite Collectivite { get; set; } = default!;
    }
}
