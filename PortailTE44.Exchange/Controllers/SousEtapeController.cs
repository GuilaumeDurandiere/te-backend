using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/sousEtape")]
    public class SousEtapeController
    {
        private readonly ISousEtapeService _sousEtapeService;

        public SousEtapeController(
            ISousEtapeService sousEtapeService
        )
        {
            _sousEtapeService = sousEtapeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<SousEtapeResponseDto> Create([FromBody] SousEtapeCreatePayloadDto dto)
        {
            return await _sousEtapeService.Create(dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<SousEtapeResponseDto> Get(int id)
        {
            return await _sousEtapeService.Get(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Delete(int id)
        {
            await _sousEtapeService.Delete(id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<SousEtapeResponseDto> Update([FromBody] SousEtapeUpdatePayloadDto dto)
        {
            return await _sousEtapeService.Update(dto);
        }
    }
}
