using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    public class AffaireConfiguration : IEntityTypeConfiguration<Affaire>
    {
        public void Configure(EntityTypeBuilder<Affaire> entity)
        {
            entity.ToTable("Affaire");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}

