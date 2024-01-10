using AutoMapper;
using PortailTE44.Common.Dtos.RefTypeOffre;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class RefTypeOffreProfile : Profile
    {
        public RefTypeOffreProfile()
        {
            CreateMap<RefTypeOffre, RefTypeOffreDto>();
        }
    }
}
