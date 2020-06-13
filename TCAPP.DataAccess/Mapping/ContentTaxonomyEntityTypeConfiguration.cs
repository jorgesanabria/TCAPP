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
            builder.HasKey(x => new { x.IdContent, x.IdTaxonomy }).HasName("FK_ContentTaxonomy");

            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.IdTaxonomy).HasColumnName("IdTaxonomy").HasColumnType("decimal").IsRequired();

            builder.HasOne(x => x.Content).WithMany(x => x.ContentTaxonomies).HasForeignKey(x => x.IdContent);
            builder.HasOne(x => x.Taxonomy).WithMany(x => x.ContentTaxonomies).HasForeignKey(x => x.IdTaxonomy);
        }
    }
}
