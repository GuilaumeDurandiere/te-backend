using PortailTE44.Common.Dtos.Theme;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface IThemeService : IGenericService<Theme>
	{
		Task<ThemeResponseDto> Create(ThemeCreatePayloadDto dto);
		Task<ThemeResponseDto> Update(ThemeUpdatePayloadDto dto);
		Task<ThemeResponseDto> GetById(int id);
		Task Delete(int id);
		Task<IEnumerable<ThemeResponseDto>> GetAll();
		PaginatedList<ThemeResponseDto> GetAllPaginated(int size, int page);

    }
}

