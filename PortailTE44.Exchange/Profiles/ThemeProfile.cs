using AutoMapper;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<Theme, ThemeBaseDto>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.BytesToBase64(src.Icone)));
            CreateMap<ThemeCreatePayloadDto, Theme>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.Base64ToBytes(src.Icone)));
            CreateMap<ThemeUpdatePayloadDto, Theme>().ForMember(dest => dest.Icone, opt => opt.MapFrom(src => ConvertHelper.Base64ToBytes(src.Icone)));
            CreateMap<Theme, ThemeLightResponseDto>().IncludeBase<Theme, ThemeBaseDto>();
            CreateMap<Theme, ThemeResponseDto>().IncludeBase<Theme, ThemeBaseDto>();
        }
    }
}

