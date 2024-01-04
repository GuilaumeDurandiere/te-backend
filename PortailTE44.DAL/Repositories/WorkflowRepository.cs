using Microsoft.EntityFrameworkCore;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
    public class WorkflowRepository : GenericRepository<Workflow>, IWorkflowRepository
    {

        public WorkflowRepository(
            PortailTE44Context context
        ) : base(context)
        {
        }

        public override async Task<Workflow?> GetByIdAsync(int id)
        {
            return await Context.Workflows
                                .Include(w => w.Etapes)
                                .ThenInclude(e => e.SousEtapes)
                                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
