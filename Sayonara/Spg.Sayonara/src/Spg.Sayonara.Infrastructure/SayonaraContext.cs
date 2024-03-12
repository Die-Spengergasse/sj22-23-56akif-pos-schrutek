using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Infrastructure
{
    // 1. Von DbContext erben
    public class SayonaraContext : DbContext
    {
        // 2. Sets abbilden (Mapping)
        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        // ...
        public DbSet<Customer> Customers => Set<Customer>();

        public SayonaraContext()
        { }

        public SayonaraContext(DbContextOptions options) 
            : base(options)
        { }

        // 3. Methoden
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ACHTUNG!!!!!!!!!!!
                optionsBuilder.UseSqlite("Data Source=.\\..\\..\\..\\..\\..\\Sayonara.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shop>().HasKey(s => new { s.Id, s.Name }); // Wäre die Syntax für einen zusammengestzten PK.

            modelBuilder.Entity<Shop>().ToTable(nameof(Shop));

            //modelBuilder.Entity<Product>().HasKey(p => p.Name); // Wenn Name als PK

            modelBuilder
                .Entity<Shop>()
                .Property(x => x.Name)
                .HasColumnName("S_Name")
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder.Entity<Shop>().OwnsOne(s => s.Address);
            modelBuilder.Entity<Shop>().OwnsOne(s => s.PhoneNumber);

            modelBuilder.Entity<Customer>().OwnsOne(s => s.Address);
            modelBuilder.Entity<Customer>().OwnsOne(s => s.PhoneNumber);
            modelBuilder.Entity<Customer>().OwnsOne(s => s.EMail);

            modelBuilder.Entity<Shop>().Ignore(s => s.IsValid);

            // kann man tun, sollte man aber nicht. Ausnahme: EF Core verlangt es
            //modelBuilder.Entity<Shop>().HasMany(s => s.Categories).WithOne(c => c.ShopNavigation);

            // kann man tun, sollte man aber nicht. (Convention over Configuration)
            //modelBuilder.Entity<Shop>().HasKey(s => s.Id);
            // TODO: Implementation
        }
    }
}
