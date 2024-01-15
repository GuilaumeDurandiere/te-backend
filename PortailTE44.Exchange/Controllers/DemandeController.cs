using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Demande;

namespace PortailTE44.Exchange.Controllers
{
	[ApiController]
	[Route("api/demande")]
	public class DemandeController
	{
		IDemandeService _demandeService;

		public DemandeController(IDemandeService demandeService)
		{
			_demandeService = demandeService;
		}

		[HttpPost]
		public async Task FormulaireSimplifieResponsable([FromBody] DemandeFormulaireSimplifieResponsableDto demandeFormulaireSimplifieResponsableDto)
		{
			return null;
		}
	}
}

