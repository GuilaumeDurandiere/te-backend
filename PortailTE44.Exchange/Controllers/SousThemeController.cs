using System;
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
		private readonly ILogger<SousThemeController> _logger;

		public SousThemeController(ISousThemeService sousThemeService, ILogger<SousThemeController> logger)
		{
			_sousThemeService = sousThemeService;
			_logger = logger;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IResult> GetById(int id)
		{
			SousThemeResponseDto response = await _sousThemeService.GetById(id);
			return Results.Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IResult> Create([FromBody] SousThemeCreatePayloadDto dto)
		{
			SousThemeResponseDto response = await _sousThemeService.Create(dto);
			return Results.Created("", response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IResult> Update([FromBody] SousThemeUpdatePayloadDto dto)
		{
			SousThemeResponseDto response = await _sousThemeService.Update(dto);
			return Results.Ok(response);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IResult> Delete(int id)
		{
			await _sousThemeService.Delete(id);
			return Results.NoContent();
		} 
	}
}

