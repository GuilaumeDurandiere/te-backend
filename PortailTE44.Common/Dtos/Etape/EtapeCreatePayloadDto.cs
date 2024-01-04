using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Common.Dtos.Etape
{
    public class EtapeCreatePayloadDto : EtapeBaseDto
    {
        public int WorkflowId { get; set; } = default!;
        public IEnumerable<SousEtapeCreateOrUpdatePayloadDto> SousEtapes { get; set; } = default!;
    }
}
