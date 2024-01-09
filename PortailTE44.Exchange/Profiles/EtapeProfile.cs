using AutoMapper;
using PortailTE44.Common.Dtos.Etape;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class EtapeProfile : Profile
    {
        public EtapeProfile()
        {
            CreateMap<EtapeCreatePayloadDto, Etape>();
            CreateMap<EtapeUpdatePayloadDto, Etape>();
            CreateMap<Etape, EtapeResponseDto>();
            CreateMap<Etape, EtapeDuplicatePayloadDto>();
            CreateMap<EtapeDuplicatePayloadDto, Etape>();
        }
    }
}
