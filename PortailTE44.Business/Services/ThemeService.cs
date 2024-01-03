using AutoMapper;
using Microsoft.Extensions.Logging;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class ThemeService : GenericService<Theme>, IThemeService
    {
        ILogger<ThemeService> _logger;

        public ThemeService(IGenericRepository<Theme> repository, IMapper mapper, ILogger<ThemeService> logger) : base(repository, mapper)
        {
            _logger = logger;
        }

        public async Task<ThemeResponseDto> Create(ThemeCreatePayloadDto dto)
        {
            Theme theme = _mapper.Map<ThemeCreatePayloadDto, Theme>(dto);
            _repository.Add(theme);
            await _repository.SaveAsync();
            return _mapper.Map<Theme, ThemeResponseDto>(theme);
        }

        public async Task<ThemeResponseDto> Update(ThemeUpdatePayloadDto dto)
        {
            Theme? theme = await _repository.GetByIdAsync(dto.Id);
            if(theme is null)
            {
                _logger.LogInformation($"Le theme avec l'id {dto.Id} n'existe pas");
                throw new KeyNotFoundException($"Le theme avec l'id {dto.Id} n'existe pas");
            }
            theme.Libelle = dto.Libelle;
            theme.Description = dto.Description;
            _repository.Update(theme);
            await _repository.SaveAsync();
            return _mapper.Map<Theme, ThemeResponseDto>(theme);
        }

        public async Task<ThemeResponseDto> GetById(int id)
        {
            Theme? theme = await _repository.GetByIdAsync(id);
            if(theme is null)
            {
                _logger.LogInformation($"Le theme avec l'id {id} n'existe pas");
                throw new KeyNotFoundException($"Le theme avec l'id {id} n'existe pas");
            }
            return _mapper.Map<Theme, ThemeResponseDto>(theme);
        }

        public async Task Delete(int id)
        {
            Theme? theme = await _repository.GetByIdAsync(id);
            if(theme is null)
            {
                _logger.LogInformation($"Le theme avec l'id {id} n'existe pas");
                throw new KeyNotFoundException($"Le theme avec l'id {id} n'existe pas");
            }
            _repository.Delete(theme);
            await _repository.SaveAsync(); 
        }

    }
}

