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
		private readonly ILogger<ThemeController> _logger;

		public ThemeController(IThemeService themeService,
			ILogger<ThemeController> logger)
		{
			_themeService = themeService;
			_logger = logger;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IResult> GetById(int id)
		{
			ThemeResponseDto response = await _themeService.GetById(id);
			return Results.Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IResult> Create([FromBody] ThemeCreatePayloadDto dto)
		{
			ThemeResponseDto response = await _themeService.Create(dto);
			return Results.Created("", response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IResult> Update([FromBody] ThemeUpdatePayloadDto dto)
		{
			ThemeResponseDto response = await _themeService.Update(dto);
			return Results.Ok(response);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IResult> Delete(int id)
		{
			await _themeService.Delete(id);
			return Results.NoContent();
		}
	}
}

