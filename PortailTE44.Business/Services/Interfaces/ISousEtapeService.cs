using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface ISousEtapeService : IGenericService<SousEtape>
    {
        Task<SousEtapeResponseDto> Create(SousEtapeCreatePayloadDto dto);
        Task<SousEtapeResponseDto> Get(int id);
        Task<SousEtapeResponseDto> Update(int id, SousEtapeUpdatePayloadDto dto);
        Task Delete(int id);
    }
}
