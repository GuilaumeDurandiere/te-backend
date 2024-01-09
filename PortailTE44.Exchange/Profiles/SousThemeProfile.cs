using AutoMapper;
using PortailTE44.Common.Dtos.SousTheme;
using PortailTE44.Common.Enums;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class SousThemeProfile : Profile
    {
        public SousThemeProfile()
        {
            CreateMap<SousThemeCreatePayloadDto, SousTheme>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.Base64ToBytes(src.Icone)));
            CreateMap<SousThemeUpdatePayloadDto, SousTheme>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.Base64ToBytes(src.Icone)));
            CreateMap<SousThemeCreateOrUpdatePayloadDto, SousTheme>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.Base64ToBytes(src.Icone)));
            CreateMap<SousTheme, SousThemeResponseDto>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.BytesToBase64(src.Icone)));
            CreateMap<SousTheme, SousThemeOffreResponseDto>().ForMember(dest => dest.TypeOffre, opt => opt.MapFrom(src => TypeOffre(src)));
        }

        private string TypeOffre(SousTheme sousTheme)
        {
            if (sousTheme.DemandeSimple)
                return TypeOffreEnum.FORMULAIRE_SIMPLIFIE.ToString();
            else if (!string.IsNullOrWhiteSpace(sousTheme.LienExterne))
                return TypeOffreEnum.LIEN_EXTERNE.ToString();
            //    //NICH virer ce cas de l'enum
            //else if (!sousTheme.AccessibleATous && (sousTheme.SousThemeCollectivites == null || !sousTheme.SousThemeCollectivites.Any()))
            //    return TypeOffreEnum.OFFRE_NON_SOUSCRITE.ToString();
            if (sousTheme.HorsTravaux)
                return TypeOffreEnum.DEMANDE_HORS_TRAVAUX.ToString();
            else
                return TypeOffreEnum.DEMANDE_TRAVAUX.ToString();
        }
    }
}

