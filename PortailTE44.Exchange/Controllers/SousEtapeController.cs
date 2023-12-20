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

        private readonly ILogger<SousEtapeController> _logger;

        public SousEtapeController(
            ISousEtapeService sousEtapeService,
            ILogger<SousEtapeController> logger
        )
        {
            _sousEtapeService = sousEtapeService;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<SousEtapeResponseDto> Create([FromBody] SousEtapeCreatePayloadDto dto)
        {
            return await _sousEtapeService.Create(dto);
        }

        [HttpGet("{id}")]
        public async Task<SousEtapeResponseDto> Get(int id)
        {
            return await _sousEtapeService.Get(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _sousEtapeService.Delete(id);
        }

        [HttpPut("Update")]
        public async Task<SousEtapeResponseDto> Update([FromBody]SousEtapeUpdatePayloadDto dto)
        {
            return await _sousEtapeService.Update(dto);
        }
    }
}
