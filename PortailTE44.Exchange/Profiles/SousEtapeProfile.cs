using AutoMapper;
using PortailTE44.Common.Dtos.SousEtapes;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class SousEtapeProfile : Profile
    {
        public SousEtapeProfile()
        {
            CreateMap<SousEtapeCreatePayloadDto, SousEtape>();
            CreateMap<SousEtape, SousEtapeResponseDto>();
            CreateMap<SousEtape, SousEtapeCreateOrUpdatePayloadDto>();
            CreateMap<SousEtapeCreateOrUpdatePayloadDto, SousEtapeUpdatePayloadDto>();
            CreateMap<SousEtapeDuplicatePayloadDto, SousEtape>();
            CreateMap<SousEtape, SousEtapeDuplicatePayloadDto>();
        }
    }
}
