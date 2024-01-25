using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.PreferenceUtilisateurAffichageAffaire;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
	public class PreferenceUtilisateurAffichageAffaireService : GenericService<PreferenceUtilisateurAffichageAffaire>,  IPreferenceUtilisateurAffichageAffaireService
	{
        
		public PreferenceUtilisateurAffichageAffaireService(IGenericRepository<PreferenceUtilisateurAffichageAffaire> repository,
            IMapper mapper): base(repository, mapper)
		{
        }

        public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Create(PreferenceUtilisateurAffichageAffaireCreatePayloadDto dto)
        {
            PreferenceUtilisateurAffichageAffaire entity = _mapper.Map<PreferenceUtilisateurAffichageAffaireCreatePayloadDto, PreferenceUtilisateurAffichageAffaire>(dto);
            _repository.Add(entity);
            await _repository.SaveAsync();
            return _mapper.Map<PreferenceUtilisateurAffichageAffaire, PreferenceUtilisateurAffichageAffaireResponseDto>(entity);
        }

        public async Task Delete(int utilisateurId)
        {
            PreferenceUtilisateurAffichageAffaire? entity = await _repository.GetByIdAsync(utilisateurId);
            if (entity is null)
                throw new KeyNotFoundException($"Il n'existe pas de préférence pour l'utilisateur id : {utilisateurId}");
            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Get(int utilisateurId)
        {
            PreferenceUtilisateurAffichageAffaire? entity = await _repository.GetByIdAsync(utilisateurId);
            if (entity is null)
                throw new KeyNotFoundException($"Il n'existe pas de préférence pour l'utilisateur id : {utilisateurId}");
            return _mapper.Map<PreferenceUtilisateurAffichageAffaire, PreferenceUtilisateurAffichageAffaireResponseDto>(entity);
        }

        public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Update(PreferenceUtilisateurAffichageAffaireUpdatePayloadDto dto)
        {
            PreferenceUtilisateurAffichageAffaire? entity = await _repository.GetByIdAsync(dto.UtilisateurId);
            if (entity is null)
                throw new KeyNotFoundException($"Il n'existe pas de préférence pour l'utilisateur id : {dto.UtilisateurId}");

            _repository.Update(entity);
            await _repository.SaveAsync();
            return _mapper.Map<PreferenceUtilisateurAffichageAffaire, PreferenceUtilisateurAffichageAffaireResponseDto>(entity);
        }
    }
}

