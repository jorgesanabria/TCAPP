﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("decimal").ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(128)").IsRequired();
            builder.Property(x => x.Created).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).HasColumnName("Updated").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Enabled).HasColumnName("Enabled").HasColumnType("bool").IsRequired();
            builder.Property(x => x.IdUser).HasColumnName("IdUser").HasColumnType("decimal").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Collections).HasForeignKey(x => x.IdUser).HasConstraintName("FK_Collection_User");

            builder.HasMany(x => x.UserContents).WithOne(x => x.Collection).HasForeignKey(x => x.IdCollection).HasConstraintName("FK_UserContent_Collection");
        }
    }
}
