using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class EtapeService : GenericService<Etape>, IEtapeService
    {
        protected readonly IEtapeRepository _etapeRepository;
        protected readonly ISousEtapeService _sousEtapeService;

        public EtapeService(
            IEtapeRepository etapeRepository,
            IMapper mapper,
            ISousEtapeService sousEtapeService
        ) : base(etapeRepository, mapper)
        {
            _etapeRepository = etapeRepository;
            _sousEtapeService = sousEtapeService;
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
            if (etape is null)
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {dto.Id}");

            etape.Libelle = dto.Libelle;
            etape.Description = dto.Description;
            etape.Statut = dto.Statut;
            foreach(SousEtapeCreateOrUpdatePayloadDto sousEtape in dto.SousEtapes!)
            {
                await _sousEtapeService.Update(_mapper.Map<SousEtapeCreateOrUpdatePayloadDto, SousEtapeUpdatePayloadDto>(sousEtape));
            }
            _repository.Update(etape);
            await _repository.SaveAsync();
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task<EtapeResponseDto> GetById(int id)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null)
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {id}");

            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task Delete(int id)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null)
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {id}");

            IEnumerable<Etape> workflowEtapes = await _etapeRepository.GetByWorkflowId(etape.WorkflowId);
            if (workflowEtapes.Count() == 1)
                throw new ArgumentException("Impossible de supprimer l'étape car un workflow doit posséder au moins une étape");

            foreach(SousEtape sousEtape in etape.SousEtapes!) {
                await _sousEtapeService.Delete(sousEtape.Id);
            }
            _repository.Delete(etape);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<EtapeResponseDto>> GetByWorkflowId(int id)
        {
            IEnumerable<Etape> etapes = await _etapeRepository.GetByWorkflowId(id);
            return _mapper.Map<IEnumerable<Etape>, IEnumerable<EtapeResponseDto>>(etapes);
        }
    }
}
