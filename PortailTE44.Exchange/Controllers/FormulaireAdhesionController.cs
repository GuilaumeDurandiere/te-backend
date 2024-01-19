using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.FormulaireAdhesion;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/formulaireAdhesion")]
    public class FormulaireAdhesionController
	{
        IFormulaireAdhesionService _formulaireAdhesionService;

        public FormulaireAdhesionController(IFormulaireAdhesionService formulaireAdhesionService)
        {
            _formulaireAdhesionService = formulaireAdhesionService;
        }

        [HttpPost]
        public async Task<bool> SendMailFormulaireAdhesion([FromBody] FormulaireAdhesionPayloadDto dto)
        {
            return await _formulaireAdhesionService.SendMailFormulaireAdhesion(dto);
        }
    }
}

