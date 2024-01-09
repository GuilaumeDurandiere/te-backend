namespace PortailTE44.DAL.Entities
{
    public class Collectivite : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        //NICH
        public IEnumerable<SousThemeCollectivite>? SousThemeCollectivites { get; set; }
    }
}
