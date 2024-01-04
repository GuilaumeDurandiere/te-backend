using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class SousEtapeConfiguration : IEntityTypeConfiguration<SousEtape>
    {
        public void Configure(EntityTypeBuilder<SousEtape> entity)
        {
            entity.ToTable("SousEtape");
            entity.HasKey(se => se.Id);
            entity.Property(se => se.Id)
                  .ValueGeneratedOnAdd();
            entity.HasOne(se => se.Etape)
                  .WithMany(e => e.SousEtapes)
                  .HasForeignKey(e => e.EtapeId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
