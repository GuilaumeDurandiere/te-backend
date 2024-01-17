using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/eudonet")]
    public class TestEudonetController
    {
        protected readonly ITestApiEudonetService _testApiEudonetService;
        public TestEudonetController(
            ITestApiEudonetService testApiEudonetService
        )
        {
            _testApiEudonetService = testApiEudonetService;
        }

        [HttpGet("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool GetTest()
        {
            return _testApiEudonetService.GetTest();
        }
    }
}
