using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.Common.Dtos.Workflow;

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

        [HttpGet]
        public async Task<EtapeResponseDto> GetById(int id)
        {
            return await _etapeService.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<EtapeResponseDto> Create([FromBody] EtapeCreatePayloadDto dto)
        {
            return await _etapeService.Create(dto);
        }

        [HttpPut("Update")]
        public async Task<EtapeResponseDto> Update([FromBody] EtapeUpdatePayloadDto dto)
        {
            return await _etapeService.Update(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _etapeService.Delete(id);
        }

        [HttpGet("GetByWorkflow/{id}")]
        public async Task<IEnumerable<EtapeResponseDto>> GetByWorkflow([FromRoute] int id)
        {
            return await _etapeService.GetByWorkflowId(id);
        }
    }
}
