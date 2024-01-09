using AutoMapper;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.Common.Enums;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class SousThemeProfile : Profile
    {
        public SousThemeProfile()
        {
            CreateMap<SousThemeCreatePayloadDto, SousTheme>();
            CreateMap<SousThemeUpdatePayloadDto, SousTheme>();
            CreateMap<SousTheme, SousThemeResponseDto>();
            CreateMap<SousThemeCreateOrUpdatePayloadDto, SousTheme>();
            //NICH TEST
            CreateMap<SousTheme, SousThemeOffreResponseDto>().ForMember(dest => dest.TypeOffre, opt => opt.MapFrom(src => TypeOffre(src)));
        }

        private string TypeOffre(SousTheme sousTheme)
        {
            if (sousTheme.DemandeSimple)
                return TypeOffreEnum.FORMULAIRE_SIMPLIFIE.ToString();
            else if (!string.IsNullOrWhiteSpace(sousTheme.LienExterne))
                return TypeOffreEnum.LIEN_EXTERNE.ToString();
            else if (!sousTheme.AccessibleATous && (sousTheme.SousThemeCollectivites == null || !sousTheme.SousThemeCollectivites.Any()))
                //NICH virer ce cas de l'enum
                return TypeOffreEnum.OFFRE_NON_SOUSCRITE.ToString();
            if (sousTheme.HorsTravaux)
                return TypeOffreEnum.DEMANDE_HORS_TRAVAUX.ToString();
            else
                return TypeOffreEnum.DEMANDE_TRAVAUX.ToString();
        }
    }
}

