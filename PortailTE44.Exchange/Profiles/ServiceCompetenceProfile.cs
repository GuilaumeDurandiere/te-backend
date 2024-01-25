using AutoMapper;
using PortailTE44.Common.Dtos.ServiceCompetence;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class ServiceCompetenceProfile : Profile
    {
        public ServiceCompetenceProfile()
        {
            CreateMap<ServiceCompetence, ServiceCompetenceResponseDto>();
        }
    }
}
