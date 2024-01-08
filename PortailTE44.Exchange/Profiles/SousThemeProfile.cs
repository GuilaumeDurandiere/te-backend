using AutoMapper;
using PortailTE44.Common.Dtos.SousTheme;
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
		}
	}
}

