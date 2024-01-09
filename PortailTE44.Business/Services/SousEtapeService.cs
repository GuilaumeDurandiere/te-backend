using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
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
        ) : base(repository, mapper) {
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
            SousEtape? sousEtape = await _repository.GetByIdAsync(id);
            if (sousEtape is null)
                throw new KeyNotFoundException($"Aucune étape avec l'id {id} n'a été retrouvé");

            return _mapper.Map <SousEtape, SousEtapeResponseDto>(sousEtape);
        }

        public async Task<SousEtapeResponseDto> Update(SousEtapeUpdatePayloadDto dto)
        {
            SousEtape? sousEtape = await _repository.GetByIdAsync(dto.Id);
            if (sousEtape is null)
                throw new KeyNotFoundException($"Il n'existe aucune sous étape avec l'id {dto.Id}");

            sousEtape.Description = dto.Description;
            sousEtape.Libelle = dto.Libelle;
            _repository.Update(sousEtape);
            await _repository.SaveAsync();
            return _mapper.Map<SousEtape, SousEtapeResponseDto>(sousEtape);
        }

        public async Task Delete (int id)
        {
            SousEtape? sousEtape = await _repository.GetByIdAsync(id);
            if (sousEtape is null)
                throw new KeyNotFoundException($"Il n'existe aucune sous étape avec l'id {id}");

            _repository.Delete(sousEtape);
        }
    }
}
