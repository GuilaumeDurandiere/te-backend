using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;

namespace PortailTE44.Exchange.Controllers
{
	[ApiController]
	[Route("api/formulaireSimplifie")]
	public class FormulaireSimplifieController
	{
		IFormulaireSimplifieService _formulaireSimplifieService;

		public FormulaireSimplifieController(IFormulaireSimplifieService formulaireSimplifieService)
		{
			_formulaireSimplifieService = formulaireSimplifieService;
		}

		[HttpPost("responsable")]
		public async Task<bool> FormulaireSimplifieResponsable([FromBody] FormulaireSimplifieResponsablePayloadDto dto)
		{
			return await _formulaireSimplifieService.FormulaireSimplifieResponsable(dto);
		}
	}
}

