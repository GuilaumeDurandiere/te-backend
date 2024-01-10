using Microsoft.EntityFrameworkCore;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
    public class SousThemeRepository : GenericRepository<SousTheme>, ISousThemeRepository
    {
        public SousThemeRepository(
            PortailTE44Context context
        ) : base(context)
        {
        }

        public override async Task<SousTheme?> GetByIdAsync(int id)
        {
            return await Context.SousThemes
                                .Include(st => st.Workflow)
                                .Include(st => st.RefTypeOffre)
                                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<SousTheme>> GetByThemeId(int id)
        {
            return await Context.SousThemes
                                .Where(st => st.ThemeId == id)
                                .Include(st => st.RefTypeOffre)
                                .Include(st => st.SousThemeCollectivites)
                                .ToListAsync();
        }
    }
}
