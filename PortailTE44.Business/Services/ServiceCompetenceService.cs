using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.ServiceCompetence;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class ServiceCompetenceService : GenericService<ServiceCompetence>, IServiceCompetenceService
    {
        public ServiceCompetenceService(
            IGenericRepository<ServiceCompetence> repository,
            IMapper mapper
        ) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<ServiceCompetenceResponseDto>> GetAll()
        {
            IEnumerable<ServiceCompetence> serviceCompetences = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceCompetence>, IEnumerable<ServiceCompetenceResponseDto>>(serviceCompetences);
        }
    }
}
