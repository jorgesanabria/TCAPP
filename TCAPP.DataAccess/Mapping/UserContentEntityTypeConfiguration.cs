﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCAPP.Domain.RelationalData;

namespace TCAPP.DataAccess.Mapping
{
    public class UserContentEntityTypeConfiguration : IEntityTypeConfiguration<UserContent>
    {
        public void Configure(EntityTypeBuilder<UserContent> builder)
        {
            builder.ToTable(nameof(UserContent));
            builder.HasKey(x => new { x.IdUser, x.IdContent, x.IdContentRelationType }).HasName("PK_UserContent");

            builder.Property(x => x.IdUser).HasColumnName("IdUser").HasColumnType("BINARY(16)").IsRequired();
            builder.Property(x => x.IdContent).HasColumnName("IdContent").HasColumnType("BINARY(16)").IsRequired();
            builder.Property(x => x.IdContentRelationType).HasColumnName("IdContentRelationType").HasColumnType("integer(11)").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UserContents).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Content).WithMany(x => x.UserContents).HasForeignKey(x => x.IdContent).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ContentRelationType).WithMany(x => x.UserContents).HasForeignKey(x => x.IdContentRelationType).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
