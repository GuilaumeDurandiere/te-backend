using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Common.Dtos.Etape
{
    public class EtapeUpdatePayloadDto : EtapeBaseDto
    {
        public int Id { get; set; }
        public IEnumerable<SousEtapeCreateOrUpdatePayloadDto> SousEtapes { get; set; } = default!;
    }
}
