using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.DataAccess.Mapping
{
    public class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable(nameof(Image));
            builder.HasKey(x => x.Id).HasName("PK_Image");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("decimal").ValueGeneratedOnAdd();
            builder.Property(x => x.Url).HasColumnName("Url").HasColumnType("varchar(1024)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.Contents).WithOne(x => x.Image).HasForeignKey(x => x.IdImage);
        }
    }
}
