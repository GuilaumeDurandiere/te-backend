using PortailTE44.Common.Dtos.Etape;

namespace PortailTE44.Common.Dtos.Workflow
{
    public class WorkflowCreatePayloadDto : WorkflowBaseDto
    {
        public IEnumerable<EtapeCreatePayloadDto> Etapes { get; set; } = default!;
    }
}
