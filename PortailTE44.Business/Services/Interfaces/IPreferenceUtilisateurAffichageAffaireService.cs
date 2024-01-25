using PortailTE44.Common.Dtos.PreferenceUtilisateurAffichageAffaire;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IPreferenceUtilisateurAffichageAffaireService
	{
		Task<PreferenceUtilisateurAffichageAffaireResponseDto> Create(PreferenceUtilisateurAffichageAffaireCreatePayloadDto dto);
		Task<PreferenceUtilisateurAffichageAffaireResponseDto> Update(PreferenceUtilisateurAffichageAffaireUpdatePayloadDto dto);
		Task<PreferenceUtilisateurAffichageAffaireResponseDto> Get(int utilisateurId);
		Task Delete(int utilisateurId);
	}
}

