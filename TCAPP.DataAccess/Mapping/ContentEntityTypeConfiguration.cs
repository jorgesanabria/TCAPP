using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.DataAccess.Mapping
{
    public class ContentEntityTypeConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable(nameof(Content));
            builder.HasKey(x => x.Id).HasName("Content_PK");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("decimal").ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar(1024)").IsRequired(false);
            builder.Property(x => x.IdContentType).HasColumnName("IdContentType").HasColumnType("decimal").IsRequired();
            builder.Property(x => x.IdImage).HasColumnName("IdImage").HasColumnType("decimal").IsRequired(false);
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasOne(x => x.ContentType).WithMany(x => x.Contents).HasForeignKey(x => x.IdContentType).HasConstraintName("FK_Content_ContentType");
            builder.HasOne(x => x.Image).WithMany(x => x.Contents).HasForeignKey(x => x.IdImage).HasConstraintName("FK_Content_Image");

            builder.HasMany(x => x.ParentContents).WithOne(x => x.Content).HasForeignKey(x => x.IdContent);
            builder.HasMany(x => x.ChildrenContents).WithOne(x => x.Parent).HasForeignKey(x => x.IdParentContent);

            builder.HasMany(x => x.ContentTaxonomies).WithOne(x => x.Content).HasForeignKey(x => x.IdContent).HasConstraintName("FK_ContentTaxonomy_Content");
            builder.HasMany(x => x.UserContents).WithOne(x => x.Content).HasForeignKey(x => x.IdContent).HasConstraintName("FK_UserContent_Content");
            builder.HasMany(x => x.ContentFloatMetaValues).WithOne(x => x.Content).HasForeignKey(x => x.IdContent).HasConstraintName("FK_ContentFloatMetaValue_Content");
            builder.HasMany(x => x.ContentBoolMetaValues).WithOne(x => x.Content).HasForeignKey(x => x.IdContent).HasConstraintName("FK_ContentBoolMetaValue_Content");
            builder.HasMany(x => x.ContentStringMetaValues).WithOne(x => x.Content).HasForeignKey(x => x.IdContent).HasConstraintName("FK_ContentStringMetaValue_Content");
        }
    }
}
