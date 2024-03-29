﻿using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class SousThemeService : GenericService<SousTheme>, ISousThemeService
    {
        protected readonly ISousThemeRepository _sousThemeRepository;
        public SousThemeService(ISousThemeRepository sousThemeRepository, IMapper mapper) : base(sousThemeRepository, mapper)
        {
            _sousThemeRepository = sousThemeRepository;
        }

        public async Task<SousThemeResponseDto> Create(SousThemeCreateOrUpdatePayloadDto dto)
        {
            SousTheme sousTheme = _mapper.Map<SousThemeCreateOrUpdatePayloadDto, SousTheme>(dto);
            _repository.Add(sousTheme);
            await _repository.SaveAsync();
            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task<SousThemeResponseDto> Update(SousThemeUpdatePayloadDto dto)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(dto.Id);
            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.Id}");

            sousTheme.Libelle = dto.Libelle;
            sousTheme.Description = dto.Description;
            sousTheme.LienExterne = dto.LienExterne;
            sousTheme.MailReferent = dto.MailReferent;
            sousTheme.AccessibleATous = dto.AccessibleATous;
            sousTheme.Couleur = dto.Couleur;
            sousTheme.Icone = ConvertHelper.Base64ToBytes(dto.Icone);
            sousTheme.WorkflowTravauxSimplifie = dto.WorkflowTravauxSimplifie.HasValue && dto.WorkflowTravauxSimplifie.Value;
            sousTheme.WorkflowId = dto.WorkflowId;
            sousTheme.RefTypeOffreId = dto.RefTypeOffreId;
            _repository.Update(sousTheme);
            await _repository.SaveAsync();
            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task<SousThemeResponseDto> GetById(int id)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(id);
            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {id}");

            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task Delete(int id)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(id);
            if (sousTheme is null)
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {id}");

            _repository.Delete(sousTheme);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<SousThemeOffreResponseDto>> GetByThemeId(int id)
        {
            IEnumerable<SousTheme> sousThemes = await _sousThemeRepository.GetByThemeId(id);
            return _mapper.Map<IEnumerable<SousTheme>, IEnumerable<SousThemeOffreResponseDto>>(sousThemes);
        }
    }
}

