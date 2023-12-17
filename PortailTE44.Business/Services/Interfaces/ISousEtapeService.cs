using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface ISousEtapeService : IGenericService<SousEtape>
    {
        Task<SousEtapeResponseDto> Create(SousEtapeCreatePayloadDto dto);
    }
}
