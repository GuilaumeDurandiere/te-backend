using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
    public class EtapeRepository : GenericRepository<Etape>, IEtapeRepository
    {
        ILogger<EtapeRepository> _logger;

        public EtapeRepository(
            PortailTE44Context context,
            ILogger<EtapeRepository> logger
        ) : base(context)
        {
            _logger = logger;
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
