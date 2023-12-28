using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
    public class WorkflowRepository : GenericRepository<Workflow>, IWorkflowRepository
    {
        ILogger<WorkflowRepository> _logger;

        public WorkflowRepository(
            PortailTE44Context context,
            ILogger<WorkflowRepository> logger
        ) : base(context)
        {
            _logger = logger;
        }

        public override async Task<Workflow?> GetByIdAsync(int id)
        {
            return await Context.Workflows
                                .Include(w => w.Etapes)
                                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
