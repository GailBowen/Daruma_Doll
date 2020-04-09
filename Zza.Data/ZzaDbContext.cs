using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Zza.Data
{
    public class ZzaDbContext : DbContext
    {
        public DbSet<PrincipalPart> PrincipalParts { get; set; }

        public DbSet<Suffix> Suffixes { get; set; }
        public DbSet<NonFiniteSuffix> NonFiniteSuffixes { get; set; }
        public DbSet<VerbalNounSuffix> VerbalNounSuffixes { get; set; }

        public DbSet<Passive> Passives { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
