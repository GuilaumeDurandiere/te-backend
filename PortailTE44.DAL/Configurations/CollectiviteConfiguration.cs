using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class CollectiviteConfiguration : IEntityTypeConfiguration<Collectivite>
    {
        public void Configure(EntityTypeBuilder<Collectivite> entity)
        {
            entity.ToTable("Collectivite");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}
