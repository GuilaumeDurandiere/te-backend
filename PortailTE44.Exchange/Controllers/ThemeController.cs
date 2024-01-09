using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.Common.Utils;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ThemeLightResponseDto>> GetAll()
        {
            return await _themeService.GetAll();
        }

        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public PaginatedList<ThemeResponseDto> GetAllPaginated(int size, int page)
        {
            return _themeService.GetAllPaginated(size, page);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ThemeResponseDto> GetById(int id)
        {
            return await _themeService.GetById(id);
        }

        //NICH TEST image
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<ThemeResponseDto> Create([FromBody] ThemeCreatePayloadDto dto)
        //{
        //    return await _themeService.Create(dto);
        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<ThemeResponseDto> Create([FromForm] IFormFile file, [FromBody] ThemeCreatePayloadDto dto)
        //public async Task<ThemeResponseDto> Create([FromBody] ThemeCreatePayloadDto dto)
        public async Task<ThemeResponseDto> Create([FromForm] ThemeCreatePayloadDto dto)
        {
            //var rrrt = Convert.ToBase64String(dto.file);
            //if (dto.file != null && dto.file.Length > 0)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        dto.file.CopyTo(ms);
            //        var fileBytes = ms.ToArray();
            //        string s = Convert.ToBase64String(fileBytes);
            //        // act on the Base64 data
            //    }
            //}
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

