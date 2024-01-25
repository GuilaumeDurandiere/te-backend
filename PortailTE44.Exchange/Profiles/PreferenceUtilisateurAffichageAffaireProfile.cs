using AutoMapper;
using PortailTE44.Common.Dtos.PreferenceUtilisateurAffichageAffaire;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
	public class PreferenceUtilisateurAffichageAffaireProfile : Profile
	{
		public PreferenceUtilisateurAffichageAffaireProfile()
		{
			CreateMap<PreferenceUtilisateurAffichageAffaire, PreferenceUtilisateurAffichageAffaireResponseDto>();
			CreateMap<PreferenceUtilisateurAffichageAffaireCreatePayloadDto, PreferenceUtilisateurAffichageAffaire>();
			CreateMap<PreferenceUtilisateurAffichageAffaireUpdatePayloadDto, PreferenceUtilisateurAffichageAffaire>();
		}
	}
}

