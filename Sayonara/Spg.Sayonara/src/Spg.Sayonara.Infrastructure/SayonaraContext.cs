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
        //public DbSet<Customer> Customers => Set<Customer>();
        //public DbSet<Product> Products => Set<Product>();

        // 3. Methoden
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=.\\..\\..\\..\\Sayonara.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().ToTable(nameof(Shop));

            modelBuilder.Entity<Shop>().OwnsOne(s => s.Address);
            modelBuilder.Entity<Shop>().OwnsOne(s => s.PhoneNumber);
            // TODO: Implementation
        }
    }
}
