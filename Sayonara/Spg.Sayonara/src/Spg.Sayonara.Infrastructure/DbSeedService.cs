using Bogus;
using Bogus.DataSets;
using Microsoft.Extensions.Options;
using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Infrastructure
{
    public class DbSeedService
    {
        private readonly SayonaraContext _db;

        public DbSeedService(SayonaraContext db)
        {
            _db = db;
        }

        public void Seed()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();

            //var shops = new Faker<Shop>()
            //    .Rules((f, s) =>
            //    {
            //        s.Name = f.Company.CompanyName();
            //        // ...
            //    })
            //    .Generate(10)
            //    .ToList();

            var shops = new Faker<Shop>()
                .CustomInstantiator(
                    EntityInstatiators.InstantiateShop
                )
                .Rules((f, s) =>
                {
                    string[] categories = f.Commerce.Categories(1000);
                    s.AddCategories(new Faker<Category>().CustomInstantiator(f =>
                        new Category(f.Random.ArrayElement(categories), s)).Rules((f, c) =>
                    {
                        c.AddProducts(new Faker<Product>().CustomInstantiator(f =>
                            new Product(
                                f.Commerce.ProductName(),
                                f.Commerce.ProductDescription(),
                                f.Date.Between(DateTime.Now.AddDays(10), DateTime.Now.AddDays(120))))
                            .Rules((f, p) =>
                            {
                            })
                            .Generate(20));
                    })
                    .Generate(10));
                })
                .Generate(50);

            _db.Shops.AddRange(shops);
            _db.SaveChanges();
        }
    }
}