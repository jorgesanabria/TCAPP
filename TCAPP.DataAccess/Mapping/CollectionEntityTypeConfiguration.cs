using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.DataAccess.Mapping
{
    public class CollectionEntityTypeConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable(nameof(Collection));
            builder.HasKey(x => x.Id).HasName("PK_Collecton");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("integer(11) AUTO_INCREMENT").ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();
            builder.Property(x => x.IdUser).HasColumnName("IdUser").HasColumnType("integer(11)").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Collections).HasForeignKey(x => x.IdUser).HasConstraintName("FK_Collection_User").OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UserContents).WithOne(x => x.Collection).HasForeignKey(x => x.IdCollection).HasConstraintName("FK_UserContent_Collection").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
