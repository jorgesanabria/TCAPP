using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.TypeData;

namespace TCAPP.DataAccess.Mapping
{
    public class MetaValueTypeEntityTypeConfiguration : IEntityTypeConfiguration<MetaValueType>
    {
        public void Configure(EntityTypeBuilder<MetaValueType> builder)
        {
            builder.ToTable(nameof(MetaValueType));
            builder.HasKey(x => x.Id).HasName("PK_MetaValueType");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("integer(11) AUTO_INCREMENT").ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.ContentFloatMetaValues).WithOne(x => x.MetaValueType).HasForeignKey(x => x.IdMetaValueType).HasConstraintName("FK_ContentFloatMetaValueType_MetaValueType").OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ContentStringMetaValues).WithOne(x => x.MetaValueType).HasForeignKey(x => x.IdMetaValueType).HasConstraintName("FK_ContentStringMetaValueType_MetaValueType").OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ContentBoolMetaValues).WithOne(x => x.MetaValueType).HasForeignKey(x => x.IdMetaValueType).HasConstraintName("FK_ContentBoolMetaValueType_MetaValueType").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
