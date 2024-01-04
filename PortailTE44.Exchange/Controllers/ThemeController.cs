using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Theme;

namespace PortailTE44.Exchange.Controllers
{
	[ApiController]
	[Route("api/theme")]
	public class ThemeController
	{
		private readonly IThemeService _themeService;

		public ThemeController(IThemeService themeService)
		{
			_themeService = themeService;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ThemeResponseDto> GetById(int id)
		{
			return await _themeService.GetById(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ThemeResponseDto> Create([FromBody] ThemeCreatePayloadDto dto)
		{
			return await _themeService.Create(dto);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ThemeResponseDto> Update([FromBody] ThemeUpdatePayloadDto dto)
		{
			return await _themeService.Update(dto);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task Delete(int id)
		{
			await _themeService.Delete(id);
		}
	}
}

