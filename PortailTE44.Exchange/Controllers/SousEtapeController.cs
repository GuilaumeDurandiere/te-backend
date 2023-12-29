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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> Create([FromBody] SousEtapeCreatePayloadDto dto)
        {
            SousEtapeResponseDto responseDto = await _sousEtapeService.Create(dto);
            return Results.Ok(responseDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> Get(int id)
        {
            SousEtapeResponseDto sousEtapeResponseDto = await _sousEtapeService.Get(id);
            return Results.Ok(sousEtapeResponseDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IResult> Delete(int id)
        {
            await _sousEtapeService.Delete(id);

            return Results.NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> Update([FromBody]SousEtapeUpdatePayloadDto dto)
        {
            SousEtapeResponseDto responseDto = await _sousEtapeService.Update(dto);
            return Results.Ok(responseDto);
        }
    }
}
