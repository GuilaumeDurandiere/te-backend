using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Repositories.Interfaces
{
    public interface IEtapeRepository : IGenericRepository<Etape>
    {
        Task<IEnumerable<Etape>> GetByWorkflowId(int id);
    }
}
