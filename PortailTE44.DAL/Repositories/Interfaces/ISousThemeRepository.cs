﻿using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Repositories.Interfaces
{
    public interface ISousThemeRepository : IGenericRepository<SousTheme>
    {
        Task<IEnumerable<SousTheme>> GetByThemeId(int id);
    }
}
