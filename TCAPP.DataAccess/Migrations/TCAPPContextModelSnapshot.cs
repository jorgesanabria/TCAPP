﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCAPP.DataAccess.Context;

namespace TCAPP.DataAccess.Migrations
{
    [DbContext(typeof(TCAPPContext))]
    partial class TCAPPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TCAPP.Domain.ConcreteData.Content", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<int>("IdContentType")
                        .HasColumnName("IdContentType")
                        .HasColumnType("integer(11)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("Content_PK");

                    b.HasIndex("IdContentType");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("TCAPP.Domain.ConcreteData.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(512)");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(512)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentBoolMetaValue", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdMetaValueType")
                        .HasColumnName("IdMetaValueType")
                        .HasColumnType("integer(11)");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.Property<bool>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("bool");

                    b.HasKey("IdContent", "IdMetaValueType")
                        .HasName("PK_ContentBoolMetaValue");

                    b.HasIndex("IdMetaValueType");

                    b.ToTable("ContentBoolMetaValue");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentFloatMetaValue", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdMetaValueType")
                        .HasColumnName("IdMetaValueType")
                        .HasColumnType("integer(11)");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("integer(11)");

                    b.HasKey("IdContent", "IdMetaValueType")
                        .HasName("PK_ContentFloatMetaValue");

                    b.HasIndex("IdMetaValueType");

                    b.ToTable("ContentFloatMetaValue");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentStringMetaValue", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdMetaValueType")
                        .HasColumnName("IdMetaValueType")
                        .HasColumnType("integer(11)");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasColumnType("varchar(1024)");

                    b.HasKey("IdContent", "IdMetaValueType")
                        .HasName("PK_ContentFloatMetaValue");

                    b.HasIndex("IdMetaValueType");

                    b.ToTable("ContentStringMetaValue");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentTaxonomy", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdTaxonomy")
                        .HasColumnName("IdTaxonomy")
                        .HasColumnType("integer(11)");

                    b.HasKey("IdContent", "IdTaxonomy")
                        .HasName("PK_ContentTaxonomy");

                    b.HasIndex("IdTaxonomy");

                    b.ToTable("ContentTaxonomy");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentTextMetaValue", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdMetaValueType")
                        .HasColumnName("IdMetaValueType")
                        .HasColumnType("integer(11)");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasColumnType("text");

                    b.HasKey("IdContent", "IdMetaValueType")
                        .HasName("PK_ContentTextMetaValue");

                    b.HasIndex("IdMetaValueType");

                    b.ToTable("ContentTextMetaValue");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ParentContent", b =>
                {
                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdParentContent")
                        .HasColumnName("IdParentContent")
                        .HasColumnType("integer(11)");

                    b.HasKey("IdContent", "IdParentContent")
                        .HasName("PK_ParentContent");

                    b.HasIndex("IdParentContent");

                    b.ToTable("ParentContent");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ParentTaxonomy", b =>
                {
                    b.Property<int>("IdTaxonomy")
                        .HasColumnName("IdTaxonomy")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdParentTaxonomy")
                        .HasColumnName("IdParentTaxonomy")
                        .HasColumnType("integer(11)");

                    b.HasKey("IdTaxonomy", "IdParentTaxonomy")
                        .HasName("PK_ParentTaxonomy");

                    b.HasIndex("IdParentTaxonomy");

                    b.ToTable("ParentTaxonomy");
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.UserContent", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("IdUser")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdContent")
                        .HasColumnName("IdContent")
                        .HasColumnType("integer(11)");

                    b.Property<int>("IdContentRelationType")
                        .HasColumnName("IdContentRelationType")
                        .HasColumnType("integer(11)");

                    b.HasKey("IdUser", "IdContent", "IdContentRelationType")
                        .HasName("PK_UserContent");

                    b.HasIndex("IdContent");

                    b.HasIndex("IdContentRelationType");

                    b.ToTable("UserContent");
                });

            modelBuilder.Entity("TCAPP.Domain.TypeData.ContentRelationType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_ContentRelationType");

                    b.ToTable("ContentRelationType");
                });

            modelBuilder.Entity("TCAPP.Domain.TypeData.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_ContentType");

                    b.ToTable("ContentType");
                });

            modelBuilder.Entity("TCAPP.Domain.TypeData.MetaValueType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_MetaValueType");

                    b.ToTable("MetaValueType");
                });

            modelBuilder.Entity("TCAPP.Domain.TypeData.Taxonomy", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer(11) AUTO_INCREMENT");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("Enabled")
                        .HasColumnName("Enabled")
                        .HasColumnType("bool");

                    b.Property<bool>("Multiple")
                        .HasColumnName("Multiple")
                        .HasColumnType("bool");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnName("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_Taxonomy");

                    b.ToTable("Taxonomy");
                });

            modelBuilder.Entity("TCAPP.Domain.ConcreteData.Content", b =>
                {
                    b.HasOne("TCAPP.Domain.TypeData.ContentType", "ContentType")
                        .WithMany("Contents")
                        .HasForeignKey("IdContentType")
                        .HasConstraintName("FK_Content_ContentType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentBoolMetaValue", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ContentBoolMetaValues")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ContentBoolMetaValue_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.MetaValueType", "MetaValueType")
                        .WithMany("ContentBoolMetaValues")
                        .HasForeignKey("IdMetaValueType")
                        .HasConstraintName("FK_ContentBoolMetaValueType_MetaValueType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentFloatMetaValue", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ContentFloatMetaValues")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ContentFloatMetaValue_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.MetaValueType", "MetaValueType")
                        .WithMany("ContentFloatMetaValues")
                        .HasForeignKey("IdMetaValueType")
                        .HasConstraintName("FK_ContentFloatMetaValueType_MetaValueType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentStringMetaValue", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ContentStringMetaValues")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ContentStringMetaValue_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.MetaValueType", "MetaValueType")
                        .WithMany("ContentStringMetaValues")
                        .HasForeignKey("IdMetaValueType")
                        .HasConstraintName("FK_ContentStringMetaValueType_MetaValueType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentTaxonomy", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ContentTaxonomies")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ContentTaxonomy_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.Taxonomy", "Taxonomy")
                        .WithMany("ContentTaxonomies")
                        .HasForeignKey("IdTaxonomy")
                        .HasConstraintName("FK_ContentTaxonomy_Taxonomy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ContentTextMetaValue", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ContentTextMetaValues")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ContentTextMetaValue_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.MetaValueType", "MetaValueType")
                        .WithMany("ContentTextMetaValues")
                        .HasForeignKey("IdMetaValueType")
                        .HasConstraintName("FK_ContentTextMetaValue_MetaValueType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ParentContent", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("ParentContents")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_ParentContent_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Parent")
                        .WithMany("ChildrenContents")
                        .HasForeignKey("IdParentContent")
                        .HasConstraintName("FK_ParentContent_ChildrenContent")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.ParentTaxonomy", b =>
                {
                    b.HasOne("TCAPP.Domain.TypeData.Taxonomy", "Parent")
                        .WithMany("ChildrenTaxonomies")
                        .HasForeignKey("IdParentTaxonomy")
                        .HasConstraintName("FK_ParentTaxonomy_ChildrenTaxonomy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.Taxonomy", "Taxonomy")
                        .WithMany("ParentTaxonomies")
                        .HasForeignKey("IdTaxonomy")
                        .HasConstraintName("FK_ParentTaxonomy_Taxonomy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCAPP.Domain.RelationalData.UserContent", b =>
                {
                    b.HasOne("TCAPP.Domain.ConcreteData.Content", "Content")
                        .WithMany("UserContents")
                        .HasForeignKey("IdContent")
                        .HasConstraintName("FK_UserContent_Content")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.TypeData.ContentRelationType", "ContentRelationType")
                        .WithMany("UserContents")
                        .HasForeignKey("IdContentRelationType")
                        .HasConstraintName("FK_UserContent_ContentRelationType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCAPP.Domain.ConcreteData.User", "User")
                        .WithMany("UserContents")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_UserContent_User")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
