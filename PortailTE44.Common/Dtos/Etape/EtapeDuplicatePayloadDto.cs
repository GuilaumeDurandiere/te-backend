using System;
using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Common.Dtos.Etape
{
	public class EtapeDuplicatePayloadDto : EtapeBaseDto
	{
        public IEnumerable<SousEtapeDuplicatePayloadDto> SousEtapes { get; set; } = default!;
    }
}

