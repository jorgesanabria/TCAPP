using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.TypeData;

namespace TCAPP.DataAccess.Mapping
{
    public class TaxonomyEntityTypeConfiguration : IEntityTypeConfiguration<Taxonomy>
    {
        public void Configure(EntityTypeBuilder<Taxonomy> builder)
        {
            builder.ToTable(nameof(Taxonomy));
            builder.HasKey(x => x.Id).HasName("PK_Taxonomy");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("BINARY(16)").ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();
            builder.Property(x => x.Multiple).HasColumnName("Multiple").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.ParentTaxonomies).WithOne(x => x.Taxonomy).HasForeignKey(x => x.IdTaxonomy).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ChildrenTaxonomies).WithOne(x => x.Parent).HasForeignKey(x => x.IdParentTaxonomy).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ContentTaxonomies).WithOne(x => x.Taxonomy).HasForeignKey(x => x.IdTaxonomy).HasConstraintName("FK_ContentTaxonomy_Taxonomy").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
