using PortailTE44.Common.Dtos.Etape;

namespace PortailTE44.Common.Dtos.Workflow
{
	public class WorkflowDuplicatePayloadDto : WorkflowBaseDto
	{
        public IEnumerable<EtapeDuplicatePayloadDto> Etapes { get; set; } = default!;
    }
}

