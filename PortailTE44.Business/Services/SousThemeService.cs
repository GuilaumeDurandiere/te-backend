using AutoMapper;
using Microsoft.Extensions.Logging;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class SousThemeService : GenericService<SousTheme>, ISousThemeService
    {
        ILogger<SousThemeService> _logger;
        public SousThemeService(IGenericRepository<SousTheme> repository, IMapper mapper, ILogger<SousThemeService> logger) : base(repository, mapper)
        {
            _logger = logger;
        }

        public async Task<SousThemeResponseDto> Create(SousThemeCreatePayloadDto dto)
        {
            SousTheme sousTheme = _mapper.Map<SousThemeCreatePayloadDto, SousTheme>(dto);
            _repository.Add(sousTheme);
            await _repository.SaveAsync();
            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task<SousThemeResponseDto> Update(SousThemeUpdatePayloadDto dto)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(dto.Id);
            if(sousTheme is null)
            {
                _logger.LogInformation($"Il n'existe aucun sous thème avec l'id {dto.Id}");
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {dto.Id}");
            }
            _repository.Update(sousTheme);
            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task<SousThemeResponseDto> GetById(int id)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(id);
            if(sousTheme is null)
            {
                _logger.LogInformation($"Il n'existe aucun sous thème avec l'id {id}");
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {id}");
            }
            return _mapper.Map<SousTheme, SousThemeResponseDto>(sousTheme);
        }

        public async Task Delete(int id)
        {
            SousTheme? sousTheme = await _repository.GetByIdAsync(id);
            if(sousTheme is null)
            {
                _logger.LogInformation($"Il n'existe aucun sous thème avec l'id {id}");
                throw new KeyNotFoundException($"Il n'existe aucun sous thème avec l'id {id}");
            }
            _repository.Delete(sousTheme);
            await _repository.SaveAsync();
        }
    }
}

