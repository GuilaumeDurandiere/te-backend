using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Common.Dtos.Etape
{
    public class EtapeResponseDto : EtapeBaseDto
    {
        public int Id { get; set; }
        public IEnumerable<SousEtapeResponseDto> SousEtapes { get; set; } = default!;
    }
}
