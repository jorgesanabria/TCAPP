using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class ParentTaxonomyEntityTypeConfiguration : IEntityTypeConfiguration<ParentTaxonomy>
    {
        public void Configure(EntityTypeBuilder<ParentTaxonomy> builder)
        {
            builder.ToTable(nameof(ParentTaxonomy));
            builder.HasKey(x => new { x.IdTaxonomy, x.IdParentTaxonomy }).HasName("PK_ParentTaxonomy");

            builder.Property(x => x.IdTaxonomy).HasColumnName("IdTaxonomy").HasColumnType("integer(11)").IsRequired();
            builder.Property(x => x.IdParentTaxonomy).HasColumnName("IdParentTaxonomy").HasColumnType("integer(11)").IsRequired();

            builder.HasOne(x => x.Taxonomy).WithMany(x => x.ParentTaxonomies).HasForeignKey(x => x.IdTaxonomy).HasConstraintName("FK_ParentTaxonomy_Taxonomy").OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Parent).WithMany(x => x.ChildrenTaxonomies).HasForeignKey(x => x.IdParentTaxonomy).HasConstraintName("FK_ParentTaxonomy_ChildrenTaxonomy").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
