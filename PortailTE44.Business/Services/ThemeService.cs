﻿using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class ThemeService : GenericService<Theme>, IThemeService
    {
        public ThemeService(IThemeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ThemeResponseDto> Create(ThemeCreatePayloadDto dto)
        {//NICH TODO : check le type et la taille des fichiers
            Theme theme = _mapper.Map<ThemeCreatePayloadDto, Theme>(dto);
            _repository.Add(theme);
            await _repository.SaveAsync();
            return _mapper.Map<Theme, ThemeResponseDto>(theme);
        }

        public async Task<ThemeLightResponseDto> Update(ThemeUpdatePayloadDto dto)
        {//NICH TODO : check le type et la taille des fichiers
            Theme? theme = await _repository.GetByIdAsync(dto.Id);
            if (theme is null)
                throw new KeyNotFoundException($"Le theme avec l'id {dto.Id} n'existe pas");

            theme.Libelle = dto.Libelle;
            theme.Description = dto.Description;
            theme.Icone = ConvertHelper.Base64ToBytes(dto.Icone);
            _repository.Update(theme);
            await _repository.SaveAsync();
            return _mapper.Map<Theme, ThemeLightResponseDto>(theme);
        }

        public async Task<ThemeResponseDto> GetById(int id)
        {
            Theme? theme = await _repository.GetByIdAsync(id);
            if (theme is null)
                throw new KeyNotFoundException($"Le theme avec l'id {id} n'existe pas");

            return _mapper.Map<Theme, ThemeResponseDto>(theme);
        }

        public async Task Delete(int id)
        {
            Theme? theme = await _repository.GetByIdAsync(id);
            if (theme is null)
                throw new KeyNotFoundException($"Le theme avec l'id {id} n'existe pas");

            _repository.Delete(theme);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ThemeLightResponseDto>> GetAll()
        {
            IEnumerable<Theme> themes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Theme>, IEnumerable<ThemeLightResponseDto>>(themes);
        }

        public PaginatedList<ThemeResponseDto> GetAllPaginated(int size, int page)
        {
            IQueryable<Theme> themes = _repository.GetAll();
            IQueryable<Theme> results = themes.Skip((page - 1) * size).Take(size);
            return new PaginatedList<ThemeResponseDto>
            {
                Results = _mapper.Map<IEnumerable<Theme>, IEnumerable<ThemeResponseDto>>(results),
                Total = themes.Count(),
                PageIndex = page,
                PageSize = size,
            };
        }
    }
}

