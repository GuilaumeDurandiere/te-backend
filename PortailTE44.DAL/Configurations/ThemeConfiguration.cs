using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> entity)
        {
            entity.ToTable("Theme");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}

