using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class ParentContentEntityTypeConfiguration : IEntityTypeConfiguration<ParentContent>
    {
        public void Configure(EntityTypeBuilder<ParentContent> builder)
        {
            builder.ToTable(nameof(ParentContent));
            builder.HasKey(x => new { x.IdContent, x.IdParentContent }).HasName("PK_ParentContent");

            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("BINARY(16)").IsRequired();
            builder.Property(x => x.IdParentContent).HasColumnName("IdParentContent").HasColumnType("BINARY(16)").IsRequired();

            builder.HasOne(x => x.Content).WithMany(x => x.ParentContents).HasForeignKey(x => x.IdContent).HasConstraintName("FK_ParentContent_Content").OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Parent).WithMany(x => x.ChildrenContents).HasForeignKey(x => x.IdParentContent).HasConstraintName("FK_ParentContent_ChildrenContent").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
