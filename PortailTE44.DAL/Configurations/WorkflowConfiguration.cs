using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
    {
        public void Configure(EntityTypeBuilder<Workflow> entity)
        {
            entity.ToTable("Workflow");
            entity.HasKey(w => w.Id);
            entity.Property(w => w.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}
