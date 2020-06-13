using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentBoolMetaValueEntityTypeConfiguration : IEntityTypeConfiguration<ContentBoolMetaValue>
    {
        public void Configure(EntityTypeBuilder<ContentBoolMetaValue> builder)
        {
            builder.ToTable(nameof(ContentBoolMetaValue));
            builder.HasKey(x => new { x.IdContent, x.IdMetaValueType }).HasName("FK_ContentBoolMetaValue");

            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.IdMetaValueType).HasColumnName("IdMetaValueType").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("bool").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasOne(x => x.Content).WithMany(x => x.ContentBoolMetaValues).HasForeignKey(x => x.IdContent);
            builder.HasOne(x => x.MetaValueType).WithMany(x => x.ContentBoolMetaValues).HasForeignKey(x => x.IdMetaValueType);
        }
    }
}
