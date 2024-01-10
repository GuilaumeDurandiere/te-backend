namespace PortailTE44.Common.Dtos.Workflow
{
    public class WorkflowUpdatePayloadDto : WorkflowBaseDto
    {
        public int Id { get; set; }
        public bool Actif { get; set; } = default!;
    }
}
