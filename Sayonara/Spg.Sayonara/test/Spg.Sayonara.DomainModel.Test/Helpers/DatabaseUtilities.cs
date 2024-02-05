using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

namespace Spg.Sayonara.DomainModel.Test.Helpers
{
    public static class DatabaseUtilities
    {
        public static UnitTestContext CreateDb()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;

            UnitTestContext db = new UnitTestContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        public static List<Shop> GetSeedingShops()
        {
            return new List<Shop>()
            {
                new Shop("Super Shop", "GMBH",
                    new Address("Street1", "4711A", "City1", "6512"),
                    new PhoneNumber("0123", "123456789")),
                new Shop("Online Dings", "KG",
                    new Address("Street2", "1323B", "City1", "1245"),
                    new PhoneNumber("0123", "123456789")),
                new Shop("Krimskrams", "AG",
                    new Address("Street3", "4535C", "City1", "1212"),
                    new PhoneNumber("0123", "123456789")),
            };
        }

        public static List<Category> GetSeedingCategories(List<Shop> shops)
        {
            return new List<Category>()
            {
                new Category("Kleidung", shops.ElementAt(0)),
                new Category("Elektronik", shops.ElementAt(0)),
                new Category("Haushalt", shops.ElementAt(0)),
                new Category("Mobilfunk", shops.ElementAt(0)),
                new Category("Getränke", shops.ElementAt(1)),
                new Category("Kleidung", shops.ElementAt(1)),
                new Category("Werkzeug", shops.ElementAt(2)),
                new Category("Garten", shops.ElementAt(2)),
                new Category("Elektronik", shops.ElementAt(2))
            };
        }

        public static List<Product> GetSeedingProducts(List<Category> categories)
        {
            return new List<Product>()
            {
                new Product("Dings", "asddadsdsa", DateTime.Now.AddDays(30), categories.ElementAt(0)),
                new Product("Scharubenzieher", "qweeqweqweqw", DateTime.Now.AddDays(12), categories.ElementAt(0)),
                new Product("Telefon", "ascxyyxccxy", DateTime.Now.AddDays(34), categories.ElementAt(2)),
                new Product("Handy", "cxvxcv", DateTime.Now.AddDays(32), categories.ElementAt(4)),
                new Product("T-Shirt", "sfdxvccvbccncnb", DateTime.Now.AddDays(18), categories.ElementAt(0)),
                new Product("Socken", "n dfgbadvsf<sdnmgfhdy v", DateTime.Now.AddDays(92), categories.ElementAt(0)),
                new Product("Socken", "xcvyfds ", DateTime.Now.AddDays(14), categories.ElementAt(4)),
                new Product("T-Shirt", "drzjkjhgfhjhfbfvdf", DateTime.Now.AddDays(71), categories.ElementAt(4)),
                new Product("Stabmixer", "sdfgtkjhhgfewehtfgbfx", DateTime.Now.AddDays(25), categories.ElementAt(1)),
                new Product("Cocal Cola", "fsewertuizoplkhjgfd", DateTime.Now.AddDays(37), categories.ElementAt(3)),
                new Product("Bier", "dsafgjhkukjfhdgsadvcx", DateTime.Now.AddDays(88), categories.ElementAt(3)),
                new Product("Schneeschaufel", "erwzutkghnbvfetrzukjgh", DateTime.Now.AddDays(45), categories.ElementAt(8)),
                new Product("Blumen", "sertzuiokjhgfdcx", DateTime.Now.AddDays(5), categories.ElementAt(5)),
                new Product("Wein", "wqertzuiopoiuzhgvcfgnj", DateTime.Now.AddDays(58), categories.ElementAt(8)),
                new Product("Unterhose", "mnbvfdertzuiokjhgfc", DateTime.Now.AddDays(13), categories.ElementAt(8)),
            };
        }
    }
}