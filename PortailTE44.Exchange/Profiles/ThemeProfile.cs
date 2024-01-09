using AutoMapper;
using PortailTE44.Common.Dtos.Theme;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
	public class ThemeProfile : Profile
	{
		public ThemeProfile()
		{
			CreateMap<ThemeCreatePayloadDto, Theme>();
			CreateMap<ThemeUpdatePayloadDto, Theme>();
			CreateMap<Theme, ThemeLightResponseDto>();
            CreateMap<Theme, ThemeResponseDto>();
        }
    }
}

