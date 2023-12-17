using Microsoft.EntityFrameworkCore;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
    public class EtapeRepository : GenericRepository<Etape>, IEtapeRepository
    {
        public EtapeRepository(
            PortailTE44Context context
        ) : base(context)
        {
        }

        public override async Task<Etape?> GetByIdAsync(int id)
        {
            return await Context.Etapes
                                .Include(e => e.SousEtapes)
                                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Etape>> GetByWorkflowsId(int id)
        {
            return await Context.Etapes
                                .Where(e => e.WorkflowId == id)
                                .ToListAsync();
        }
    }
}
