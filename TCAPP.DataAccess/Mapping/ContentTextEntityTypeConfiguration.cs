using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentTextEntityTypeConfiguration : IEntityTypeConfiguration<ContentTextMetaValue>
    {
        public void Configure(EntityTypeBuilder<ContentTextMetaValue> builder)
        {
            builder.ToTable(nameof(ContentTextMetaValue));
            builder.HasKey(x => new { x.IdContent, x.IdMetaValueType }).HasName("PK_ContentTextMetaValue");

            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("integer(11)").IsRequired();
            builder.Property(x => x.IdMetaValueType).HasColumnName("IdMetaValueType").HasColumnType("integer(11)").IsRequired();
            builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("text").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasOne(x => x.Content).WithMany(x => x.ContentTextMetaValues).HasForeignKey(x => x.IdContent).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MetaValueType).WithMany(x => x.ContentTextMetaValues).HasForeignKey(x => x.IdMetaValueType).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
