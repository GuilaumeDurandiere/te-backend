using AutoMapper;
using PortailTE44.Common.Dtos.SousTheme;
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
            CreateMap<SousTheme, SousThemeOffreResponseDto>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.BytesToBase64(src.Icone)))
                                                             .ForMember(dest => dest.Accessible, opt => opt.MapFrom(src => OffreAccessible(src)));
        }

        private bool OffreAccessible(SousTheme sousTheme)
        {
            return sousTheme.AccessibleATous || (sousTheme.SousThemeCollectivites != null && sousTheme.SousThemeCollectivites.Any());
        }
    }
}

