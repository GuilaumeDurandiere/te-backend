using AutoMapper;
using PortailTE44.Common.Dtos.Affaire;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
	public class AffaireProfile : Profile
	{
		public AffaireProfile()
		{
			CreateMap<AffaireCreatePayloadDto, Affaire>();
			CreateMap<Affaire, AffaireResponseDto>();
		}
	}
}

