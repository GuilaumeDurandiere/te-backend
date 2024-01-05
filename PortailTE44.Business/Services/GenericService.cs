using AutoMapper;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, new()
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
     
        public GenericService(IGenericRepository<TEntity> repository,
                              IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}

