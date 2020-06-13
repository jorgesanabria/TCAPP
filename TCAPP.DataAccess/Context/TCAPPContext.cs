using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TCAPP.DataAccess.Mapping;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;
using TCAPP.Domain.TypeData;

namespace TCAPP.DataAccess.Context
{
    public class TCAPPContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContentRelationType> ContentRelationTypes { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<MetaValueType> MetaValueTypes { get; set; }
        public DbSet<Taxonomy> Taxonomies { get; set; }
        public DbSet<ContentBoolMetaValue> ContentBoolMetaValues { get; set; }
        public DbSet<ContentFloatMetaValue> ContentFloatMetaValues { get; set; }
        public DbSet<ContentStringMetaValue> ContentStringMetaValues { get; set; }
        public DbSet<ContentTaxonomy> ContentTaxonomies { get; set; }
        public DbSet<ParentContent> ParentContents { get; set; }
        public DbSet<ParentTaxonomy> ParentTaxonomies { get; set; }
        public DbSet<UserContent> UserContents { get; set; }
        public TCAPPContext(DbContextOptions<TCAPPContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CollectionEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentBoolMetaValueEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentFloatMetaValueEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentRelationTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentStringMetaValeuEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentTaxonomyEntityTypeConfiguration());
            builder.ApplyConfiguration(new ContentTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ImageEntityTypeConfiguration());
            builder.ApplyConfiguration(new MetaValueTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new ParentContentEntityTypeConfiguration());
            builder.ApplyConfiguration(new ParentTaxonomyEntityTypeConfiguration());
            builder.ApplyConfiguration(new TaxonomyEntityTypeConfiguration());
            builder.ApplyConfiguration(new UserContentEntityTypeConfiguration());
            builder.ApplyConfiguration(new UserEntityTypeConfiguration());

            //builder.HasDefaultSchema("TCAPP");
        }
    }
}
