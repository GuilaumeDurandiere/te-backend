using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/sydenet")]
    public class SydenetController
    {
        protected readonly ISydenetService _sydenetService;
        public SydenetController(
            ISydenetService sydenetService
        )
        {
            _sydenetService = sydenetService;
        }

        [HttpGet("GetSydenetCompetencesByCommunauteCommune")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool GetSydenetCompetencesByCommunauteCommune(string codeInsee)
        {
            return _sydenetService.GetSydenetCompetencesByCommunauteCommune(codeInsee);
        }

        [HttpGet("GetSydenetCompetencesByCommune")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool GetSydenetCompetencesByCommune(string codeInsee)
        {
            return _sydenetService.GetSydenetCompetencesByCommune(codeInsee);
        }

        [HttpGet("GetSydenetServicesByCommunauteCommune")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool GetSydenetServicesByCommunauteCommune(string codeInsee)
        {
            return _sydenetService.GetSydenetServicesByCommunauteCommune(codeInsee);
        }

        [HttpGet("GetSydenetServicesByCommune")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool GetSydenetServicesByCommune(string codeInsee)
        {
            return _sydenetService.GetSydenetServicesByCommune(codeInsee);
        }

        [HttpGet("SynchronizeCollectivites")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> SynchronizeCollectivites()
        {
            return await _sydenetService.SynchronizeCollectivites();
        }

        [HttpGet("SynchronizeServiceCompetences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> SynchronizeServiceCompetences()
        {
            return await _sydenetService.SynchronizeServiceCompetences();
        }
    }
}
