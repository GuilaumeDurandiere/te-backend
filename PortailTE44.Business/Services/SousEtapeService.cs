﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class SousEtapeService : GenericService<SousEtape>, ISousEtapeService
    {
        ILogger<SousEtapeService> _logger;
        public SousEtapeService(
            IGenericRepository<SousEtape> repository,
            IMapper mapper,
            ILogger<SousEtapeService> logger
        ) : base(repository, mapper) {
            _logger = logger;
        }

        public async Task<SousEtapeResponseDto> Create(SousEtapeCreatePayloadDto dto)
        {
            SousEtape sousEtape = _mapper.Map<SousEtapeCreatePayloadDto, SousEtape>(dto);
            _repository.Add(sousEtape);
            await _repository.SaveAsync();
            return _mapper.Map<SousEtape, SousEtapeResponseDto>(sousEtape);
        }

        public async Task<SousEtapeResponseDto> Get(int id) 
        {
            SousEtape sousEtape = await _repository.GetByIdAsync(id);
            if(sousEtape == null ) throw new Exception($"Aucune étape avec l'id {id} n'a été retrouvé");
            return _mapper.Map <SousEtape, SousEtapeResponseDto>(sousEtape);
        }

        public async Task<SousEtapeResponseDto> Update(int id, SousEtapeUpdatePayloadDto dto)
        {
            SousEtape sousEtape = await _repository.GetByIdAsync(id);
            if (sousEtape == null) throw new Exception($"Il n'existe aucune sous étape avec l'id {dto.Id}");
            sousEtape.Description = dto.Description;
            sousEtape.Libelle = dto.Libelle;
            _repository.Update(sousEtape);
            await _repository.SaveAsync();
            return _mapper.Map<SousEtape, SousEtapeResponseDto>(sousEtape);
        }

        public async Task Delete (int id)
        {
            SousEtape sousEtape = await _repository.GetByIdAsync(id);
            if (sousEtape == null) throw new Exception($"Il n'existe aucune sous étape avec l'id {id}");
            _repository.Delete(sousEtape);
        }
    }
}
