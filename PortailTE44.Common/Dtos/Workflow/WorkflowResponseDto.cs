using PortailTE44.Common.Dtos.Etape;

namespace PortailTE44.Common.Dtos.Workflow
{
    public class WorkflowResponseDto : WorkflowBaseDto
    {
        public int Id { get; set; }
        public bool Actif { get; set; } = default!;
        public IEnumerable<EtapeResponseDto> Etapes { get; set; } = default!;
    }
}
