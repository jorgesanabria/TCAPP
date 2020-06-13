using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.TypeData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentTypeEntityTypeConfiguration : IEntityTypeConfiguration<ContentType>
    {
        public void Configure(EntityTypeBuilder<ContentType> builder)
        {
            builder.ToTable(nameof(ContentType));
            builder.HasKey(x => x.Id).HasName("PK_ContentType");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("decimal").ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.Contents).WithOne(x => x.ContentType).HasForeignKey(x => x.IdContentType);
        }
    }
}
