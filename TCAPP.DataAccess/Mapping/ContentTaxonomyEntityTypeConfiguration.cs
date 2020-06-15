using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentTaxonomyEntityTypeConfiguration : IEntityTypeConfiguration<ContentTaxonomy>
    {
        public void Configure(EntityTypeBuilder<ContentTaxonomy> builder)
        {
            builder.ToTable(nameof(ContentTaxonomy));
            builder.HasKey(x => new { x.IdContent, x.IdTaxonomy }).HasName("PK_ContentTaxonomy");

            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("integer(11)").IsRequired();
            builder.Property(x => x.IdTaxonomy).HasColumnName("IdTaxonomy").HasColumnType("integer(11)").IsRequired();

            builder.HasOne(x => x.Content).WithMany(x => x.ContentTaxonomies).HasForeignKey(x => x.IdContent).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Taxonomy).WithMany(x => x.ContentTaxonomies).HasForeignKey(x => x.IdTaxonomy).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
