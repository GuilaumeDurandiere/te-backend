using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class SousThemeCollectiviteConfiguration : IEntityTypeConfiguration<SousThemeCollectivite>
    {
        public void Configure(EntityTypeBuilder<SousThemeCollectivite> entity)
        {
            entity.ToTable("SousThemeCollectivite");
            entity.HasKey(stc => stc.Id);
            entity.Property(stc => stc.Id)
                  .ValueGeneratedOnAdd();
            entity.HasOne(stc => stc.SousTheme)
                  .WithMany(st => st.SousThemeCollectivites)
                  .HasForeignKey(stc => stc.SousThemeId);
            entity.HasOne(stc => stc.Collectivite)
                  .WithMany(c => c.SousThemeCollectivites)
                  .HasForeignKey(stc => stc.CollectiviteId);
        }
    }
}
