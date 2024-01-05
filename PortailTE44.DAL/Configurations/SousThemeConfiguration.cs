using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
	internal class SousThemeConfiguration : IEntityTypeConfiguration<SousTheme>
    {
        public void Configure(EntityTypeBuilder<SousTheme> entity)
        {
            entity.ToTable("SousTheme");
            entity.HasKey(st => st.Id);
            entity.Property(st => st.Id)
                  .ValueGeneratedOnAdd();
            entity.HasOne(st => st.Theme)
                  .WithMany(t => t.SousThemes)
                  .HasForeignKey(st => st.ThemeId);
        }
    }
}

