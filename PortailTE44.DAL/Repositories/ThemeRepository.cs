using Microsoft.EntityFrameworkCore;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
	public class ThemeRepository : GenericRepository<Theme>, IThemeRepository
	{
		public ThemeRepository(PortailTE44Context context) : base(context)
		{
		}

        public override async Task<Theme?> GetByIdAsync(int id)
        {
            return await Context.Themes
                                .Include(t => t.SousThemes)
                                    .ThenInclude(st => st.Workflow)
                                .Include(t => t.SousThemes)
                                    .ThenInclude(st => st.RefTypeOffre)
                                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

