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

        public async Task<IEnumerable<SousTheme>> GetByThemeId(int id)
        {
            return await Context.SousThemes
                                .Where(st => st.ThemeId == id)
                                .ToListAsync();
        }
    }
}
