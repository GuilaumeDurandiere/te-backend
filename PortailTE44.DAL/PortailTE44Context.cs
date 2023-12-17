using Microsoft.EntityFrameworkCore;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL
{
    public partial class PortailTE44Context : DbContext
    {
        protected readonly string _connectionString;
        public PortailTE44Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Workflow> Workflows { get; set; } = default!;
        public virtual DbSet<Etape> Etapes { get; set; } = default!;
        public virtual DbSet<SousEtape> SousEtapes { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured && _connectionString != null)
            {
                options.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortailTE44Context).Assembly);
    }
}
