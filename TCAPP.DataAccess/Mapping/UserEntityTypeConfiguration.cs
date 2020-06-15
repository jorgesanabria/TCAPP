using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.DataAccess.Mapping
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(x => x.Id).HasName("PK_User");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("integer(11) AUTO_INCREMENT").ValueGeneratedNever();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar(64)").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("varchar(512)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar(512)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();

            builder.HasMany(x => x.UserContents).WithOne(x => x.User).HasForeignKey(x => x.IdUser).HasConstraintName("FK_UserContent_User").OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Collections).WithOne(x => x.User).HasForeignKey(x => x.IdUser).HasConstraintName("FK_Collection_User").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
