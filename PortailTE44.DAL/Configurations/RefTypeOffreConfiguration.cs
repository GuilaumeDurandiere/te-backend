using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortailTE44.DAL.Entities;

namespace PortailTE44.DAL.Configurations
{
    internal class RefTypeOffreConfiguration : IEntityTypeConfiguration<RefTypeOffre>
    {
        public void Configure(EntityTypeBuilder<RefTypeOffre> entity)
        {
            entity.ToTable("RefTypeOffre");
            entity.HasKey(rto => rto.Id);
            entity.Property(rto => rto.Id)
                  .ValueGeneratedOnAdd();
        }
    }
}
