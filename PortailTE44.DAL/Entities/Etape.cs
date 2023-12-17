namespace PortailTE44.DAL.Entities
{
    public class Etape : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        public string? Description { get; set; }
        public string Statut { get; set; } = default!;
        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; } = default!;
        public IEnumerable<SousEtape>? SousEtapes { get; set; } = default!;
    }
}
