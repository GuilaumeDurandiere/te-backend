namespace PortailTE44.DAL.Entities
{
    public class Workflow : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        public bool Actif { get; set; } = default!;
        public ICollection<Etape> Etapes { get; set; } = default!;
    }
}
