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
        private readonly ILogger<EtapeController> _logger;

        public EtapeController(
            IEtapeService etapeService,
            ILogger<EtapeController> logger
        )
        {
            _etapeService = etapeService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetById(int id)
        {
            EtapeResponseDto responseDto = await _etapeService.GetById(id);
            return responseDto != null ? Results.Ok(responseDto) : Results.NotFound();
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> Create([FromBody] EtapeCreatePayloadDto dto)
        {
            EtapeResponseDto responseDto = await _etapeService.Create(dto);
            return Results.Created("", responseDto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> Update([FromBody] EtapeUpdatePayloadDto dto)
        {
            EtapeResponseDto responseDto = await _etapeService.Update(dto);
            return Results.Ok(responseDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IResult> Delete([FromRoute] int id)
        {
            await _etapeService.Delete(id);
            return Results.NoContent();
        }

        [HttpGet("GetByWorkflow/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetByWorkflow([FromRoute] int id)
        {
            IEnumerable<EtapeResponseDto> responseDtos = await _etapeService.GetByWorkflowId(id);
            return Results.Ok(responseDtos);
        }
    }
}
