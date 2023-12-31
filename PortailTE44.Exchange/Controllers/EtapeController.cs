using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/etape")]
    public class EtapeController
    {
        private readonly IEtapeService _etapeService;

        public EtapeController(
            IEtapeService etapeService
        )
        {
            _etapeService = etapeService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<EtapeResponseDto> GetById(int id)
        {
            return await _etapeService.GetById(id);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<EtapeResponseDto> Create([FromBody] EtapeCreatePayloadDto dto)
        {
            return await _etapeService.Create(dto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<EtapeResponseDto> Update([FromBody] EtapeUpdatePayloadDto dto)
        {
            return await _etapeService.Update(dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Delete([FromRoute] int id)
        {
            await _etapeService.Delete(id);
        }

        [HttpGet("GetByWorkflow/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<EtapeResponseDto>> GetByWorkflow([FromRoute] int id)
        {
            return await _etapeService.GetByWorkflowId(id);
        }
    }
}
