using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Affaire;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class AffaireService : GenericService<Affaire>, IAffaireService
	{
		public AffaireService(IGenericRepository<Affaire> repository,
            IMapper mapper) : base(repository, mapper)
		{
		}

        public async Task<AffaireResponseDto> Create(AffaireCreatePayloadDto dto)
        {
            Affaire affaire = _mapper.Map<AffaireCreatePayloadDto, Affaire>(dto);
            affaire.NumAffaire = "TestNumAffaire0001";
            affaire.DateCreation = DateTime.Now;
            _repository.Add(affaire);
            await _repository.SaveAsync();
            return _mapper.Map<Affaire, AffaireResponseDto>(affaire);
        }
    }
}

