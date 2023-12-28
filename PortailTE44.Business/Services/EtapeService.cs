﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class EtapeService : GenericService<Etape>, IEtapeService
    {
        ILogger<EtapeService> _logger;
        protected readonly IEtapeRepository _etapeRepository;
        public EtapeService(
            IEtapeRepository etapeRepository,
            IMapper mapper,
            ILogger<EtapeService> logger
        ) : base(etapeRepository, mapper)
        {
            _etapeRepository = etapeRepository;
            _logger = logger;
        }

        public async Task<EtapeResponseDto> Create(EtapeCreatePayloadDto dto)
        {
            Etape etape = _mapper.Map<EtapeCreatePayloadDto, Etape>(dto);
            _repository.Add(etape);
            await _repository.SaveAsync();
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task<EtapeResponseDto> Update(int id, EtapeUpdatePayloadDto dto)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null)
            {
                _logger.LogInformation($"Aucune étape trouvée avec l'id {id}");
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {id}");
            }
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
            if (etape is null)
            {
                _logger.LogInformation($"Aucune étape trouvée avec l'id {id}");
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {id}");
            }
            return _mapper.Map<Etape, EtapeResponseDto>(etape);
        }

        public async Task Delete(int id)
        {
            Etape? etape = await _repository.GetByIdAsync(id);
            if (etape is null)
            {
                _logger.LogInformation($"Aucune étape trouvée avec l'id {id}");
                throw new KeyNotFoundException($"Aucune étape trouvée avec l'id {id}");
            }
            IEnumerable<Etape> workflowEtapes = await _etapeRepository.GetByWorkflowsId(etape.WorkflowId);
            if (workflowEtapes.Count() == 1)
            {
                _logger.LogInformation("Impossible de supprimer l'étape car un workflow doit posséder au moins une étape");
                throw new ArgumentException("Impossible de supprimer l'étape car un workflow doit posséder au moins une étape");
            }
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
