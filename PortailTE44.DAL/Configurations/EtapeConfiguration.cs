using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class EtapeConfiguration : IEntityTypeConfiguration<Etape>
    {
        public void Configure(EntityTypeBuilder<Etape> entity)
        {
            entity.ToTable("Etape");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();
            entity.HasOne(e => e.Workflow)
                  .WithMany(w => w.Etapes)
                  .HasForeignKey(e => e.WorkflowId);
        }
    }
}
