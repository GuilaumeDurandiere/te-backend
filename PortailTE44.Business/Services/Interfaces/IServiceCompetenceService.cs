using PortailTE44.Common.Dtos.ServiceCompetence;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface IServiceCompetenceService : IGenericService<ServiceCompetence>
    {
        Task<IEnumerable<ServiceCompetenceResponseDto>> GetAll();
    }
}
