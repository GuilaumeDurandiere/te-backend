using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class ServiceCompetenceConfiguration : IEntityTypeConfiguration<ServiceCompetence>
    {
        public void Configure(EntityTypeBuilder<ServiceCompetence> entity)
        {
            entity.ToTable("ServiceCompetence");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}
