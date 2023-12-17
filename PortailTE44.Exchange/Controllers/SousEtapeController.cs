using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/sousetape")]
    public class SousEtapeController
    {
        private readonly ISousEtapeService _sousEtapeService;

        public SousEtapeController(
            ISousEtapeService sousEtapeService
        )
        {
            _sousEtapeService = sousEtapeService;
        }

        [HttpPost("Create")]
        public async Task<SousEtapeResponseDto> Create([FromBody] SousEtapeCreatePayloadDto dto)
        {
            return await _sousEtapeService.Create(dto);
        }
    }
}
