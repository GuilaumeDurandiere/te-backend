using System;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.DAL.Repositories
{
	public class SousThemeRepository : GenericRepository<SousTheme>, ISousThemeRepository
    {
		public SousThemeRepository(PortailTE44Context context) : base(context)
		{
		}
	}
}

