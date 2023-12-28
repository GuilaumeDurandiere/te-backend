using PortailTE44.Common.Dtos.Etape;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface IEtapeService : IGenericService<Etape>
    {
        Task<EtapeResponseDto> Create(EtapeCreatePayloadDto dto);
        Task<EtapeResponseDto> Update(int id, EtapeUpdatePayloadDto dto);
        Task<EtapeResponseDto> GetById(int id);
        Task<IEnumerable<EtapeResponseDto>> GetByWorkflowId(int id);
        Task Delete(int id);
    }
}
