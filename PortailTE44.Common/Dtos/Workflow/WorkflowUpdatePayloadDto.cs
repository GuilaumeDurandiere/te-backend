using PortailTE44.Common.Dtos.Etape;

namespace PortailTE44.Common.Dtos.Workflow
{
    public class WorkflowUpdatePayloadDto : WorkflowBaseDto
    {
        public int Id { get; set; }
        public bool Actif { get; set; } = default!;
        public IEnumerable<EtapeUpdatePayloadDto> Etapes { get; set; } = default!;
    }
}
