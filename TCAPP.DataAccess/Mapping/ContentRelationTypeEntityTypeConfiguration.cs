using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.TypeData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentRelationTypeEntityTypeConfiguration : IEntityTypeConfiguration<ContentRelationType>
    {
        public void Configure(EntityTypeBuilder<ContentRelationType> builder)
        {
            builder.ToTable(nameof(ContentRelationType));
            builder.HasKey(x => x.Id).HasName("PK_ContentRelationType");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("integer(11) AUTO_INCREMENT").ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.UserContents).WithOne(x => x.ContentRelationType).HasForeignKey(x => x.IdContentRelationType).HasConstraintName("FK_UserContent_ContentRelationType").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
