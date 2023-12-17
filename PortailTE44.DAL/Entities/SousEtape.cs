namespace PortailTE44.DAL.Entities
{
    public class SousEtape : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        public string? Description { get; set; }
        public int EtapeId { get; set; }
        public Etape Etape { get; set; } = default!;
    }
}
