using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class SousEtapeService : GenericService<SousEtape>, ISousEtapeService
    {
        public SousEtapeService(
            IGenericRepository<SousEtape> repository,
            IMapper mapper
        ) : base(repository, mapper) { }

        public async Task<SousEtapeResponseDto> Create(SousEtapeCreatePayloadDto dto)
        {
            SousEtape sousEtape = _mapper.Map<SousEtapeCreatePayloadDto, SousEtape>(dto);
            _repository.Add(sousEtape);
            await _repository.SaveAsync();
            return _mapper.Map<SousEtape, SousEtapeResponseDto>(sousEtape);
        }
    }
}
