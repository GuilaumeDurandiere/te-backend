﻿using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Affaire;

namespace PortailTE44.Exchange.Controllers
{
	[ApiController]
	[Route("api/affaire")]
	public class AffaireController {

		IAffaireService _affaireService;

		public AffaireController(IAffaireService affaireService)
		{
			_affaireService = affaireService;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public Task<AffaireResponseDto> Create([FromBody] AffaireCreatePayloadDto dto)
		{
			return _affaireService.Create(dto);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public Task<AffaireResponseDto> Get(int id)
		{
			return _affaireService.GetById(id);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public Task<AffaireResponseDto> Update([FromBody] AffaireUpdatePayloadDto dto)
		{
			return _affaireService.Update(dto);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task Delete(int id)
		{
			await _affaireService.Delete(id);		}
	}
}

