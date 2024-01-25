using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.ServiceCompetence;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/serviceCompetence")]
    public class ServiceCompetenceController
    {
        private readonly IServiceCompetenceService _serviceCompetenceService;

        public ServiceCompetenceController(IServiceCompetenceService serviceCompetenceService)
        {
            _serviceCompetenceService = serviceCompetenceService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ServiceCompetenceResponseDto>> GetAll()
        {
            return await _serviceCompetenceService.GetAll();
        }
    }
}
