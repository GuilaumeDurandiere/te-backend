using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface ISousThemeService : IGenericService<SousTheme>
	{
		Task<SousThemeResponseDto> Create(SousThemeCreatePayloadDto dto);
		Task<SousThemeResponseDto> Update(SousThemeUpdatePayloadDto dto);
		Task<SousThemeResponseDto> GetById(int id);
		Task Delete(int id);
		Task<IEnumerable<SousThemeOffreResponseDto>> GetByThemeId(int id);
    }
}

