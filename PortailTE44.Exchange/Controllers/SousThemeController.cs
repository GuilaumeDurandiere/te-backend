using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousTheme;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
	[Route("api/sousTheme")]
	public class SousThemeController
	{
		private readonly ISousThemeService _sousThemeService;

		public SousThemeController(ISousThemeService sousThemeService)
		{
			_sousThemeService = sousThemeService;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<SousThemeResponseDto> GetById(int id)
		{
			return await _sousThemeService.GetById(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<SousThemeResponseDto> Create([FromBody] SousThemeCreatePayloadDto dto)
		{
			return await _sousThemeService.Create(dto);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<SousThemeResponseDto> Update([FromBody] SousThemeUpdatePayloadDto dto)
		{
			return await _sousThemeService.Update(dto);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task Delete(int id)
		{
			await _sousThemeService.Delete(id);
		}

        [HttpGet("getByTheme/{id}")]
        public async Task<IEnumerable<SousThemeResponseDto>> GetOne([FromRoute] int id)
		{
			return await _sousThemeService.GetByThemeId(id);
		}
    }
}

