using PortailTE44.Common.Dtos.Affaire;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IAffaireService : IGenericService<Affaire>
    {
		Task<AffaireResponseDto> Create(AffaireCreatePayloadDto dto);
		Task<AffaireResponseDto> GetById(int id);
		Task<AffaireResponseDto> Update(AffaireUpdatePayloadDto dto);
		Task Delete(int id);
	}
}

