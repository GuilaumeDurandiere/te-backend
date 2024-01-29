namespace PortailTE44.Common.Dtos.Workflow
{
    public class WorkflowPaginatedResponseDto : WorkflowBaseDto
    {
        public int Id { get; set; }
        public bool Actif { get; set; } = default!;
        public IEnumerable<string> Offres { get; set; } = default!;
    }
}
