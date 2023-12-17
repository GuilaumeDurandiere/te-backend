using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class EtapeService : GenericService<Etape>, IEtapeService
    {
        protected readonly IEtapeRepository _etapeRepository;
        public EtapeService(
            IEtapeRepository etapeRepository,
            IMapper mapper
        ) : base(etapeRepository, mapper)
        {
            _etapeRepository = etapeRepository;
        }

        public async Task<EtapeResponseDto> Create(EtapeCreatePayloadDto dto)
        {
            Etape etape = _mapper.Map<EtapeCreatePayloadDto, Etape>(dto);
            _repository.Add(etape);
            await _repository.SaveAsync();
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task<EtapeResponseDto> Update(EtapeUpdatePayloadDto dto)
        {
            Etape? etape = await _repository.GetByIdAsync(dto.Id);
            if (etape is null) throw new KeyNotFoundException("L'étape n'existe pas");
            etape.Libelle = dto.Libelle;
            etape.Description = dto.Description;
            etape.Statut = dto.Statut;
            _repository.Update(etape);
            await _repository.SaveAsync();
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task<EtapeResponseDto> GetById(int id)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null) throw new KeyNotFoundException("L'étape n'existe pas");
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task Delete(int id)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null) throw new KeyNotFoundException("L'étape n'existe pas");
            IEnumerable<Etape> workflowEtapes = await _etapeRepository.GetByWorkflowsId(etape.WorkflowId);
            if (workflowEtapes.Count() == 1) throw new ArgumentException("Un workflow doit posséder au moins une étape");
            _repository.Delete(etape);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<EtapeResponseDto>> GetByWorkflowId(int id)
        {
            IEnumerable<Etape> etapes = await _etapeRepository.GetByWorkflowsId(id);
            return _mapper.Map<IEnumerable<Etape>, IEnumerable<EtapeResponseDto>>(etapes);
        }
    }
}
