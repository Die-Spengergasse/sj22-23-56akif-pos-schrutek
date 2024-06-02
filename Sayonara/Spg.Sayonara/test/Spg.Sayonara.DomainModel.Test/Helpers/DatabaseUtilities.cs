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
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlite("Data Source=.\\..\\..\\..\\..\\..\\Sayonara_Real.db");

            UnitTestContext db = new UnitTestContext(builder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        public static UnitTestContext CreateMemoryDb()
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
                new Product(new Guid("a89c54c7-f555-486a-8f0e-1d2cda561e94"), "Dings", "asddadsdsa", DateTime.Now.AddDays(30)),
                new Product(new Guid("dde4870a-6750-44d8-8799-aee44215920b"), "Scharubenzieher", "qweeqweqweqw", DateTime.Now.AddDays(12)),
                new Product(new Guid("fe6f32b9-726c-4c12-90ce-2b31aa2ffa18"), "Telefon", "ascxyyxccxy", DateTime.Now.AddDays(34)),
                new Product(new Guid("7dc48a39-b0f7-4977-8932-d65aa0972eab"), "Handy", "cxvxcv", DateTime.Now.AddDays(32)),
                new Product(new Guid("5f220e1d-d79c-4469-8c8d-34166665194c"), "T-Shirt", "sfdxvccvbccncnb", DateTime.Now.AddDays(18)),
                new Product(new Guid("39febbf7-3e23-4f9f-8917-04fb95ce445a"), "Socken", "n dfgbadvsf<sdnmgfhdy v", DateTime.Now.AddDays(92)),
                new Product(new Guid("e3e6fc6e-b3a9-4ffb-b886-66e013091321"), "Socken", "xcvyfds ", DateTime.Now.AddDays(14)),
                new Product(new Guid("34dba03b-7128-4291-ad56-948d42059c40"), "T-Shirt", "drzjkjhgfhjhfbfvdf", DateTime.Now.AddDays(71)),
                new Product(new Guid("46fa2d4a-6ea7-4cc4-972c-85459e0d3ebb"), "Stabmixer", "sdfgtkjhhgfewehtfgbfx", DateTime.Now.AddDays(25)),
                new Product(new Guid("14fabcf8-d7a3-437d-bad9-76ded5a99490"), "Cocal Cola", "fsewertuizoplkhjgfd", DateTime.Now.AddDays(37)),
                new Product(new Guid("eb777cc4-07c6-4886-a6c8-7cc196572fa5"), "Bier", "dsafgjhkukjfhdgsadvcx", DateTime.Now.AddDays(88)),
                new Product(new Guid("656be11b-b063-4ef9-85f6-9149aeb19e6a"), "Schneeschaufel", "erwzutkghnbvfetrzukjgh", DateTime.Now.AddDays(45)),
                new Product(new Guid("d58bfc81-fea3-436a-86a8-f76e40b55a26"), "Blumen", "sertzuiokjhgfdcx", DateTime.Now.AddDays(5)),
                new Product(new Guid("74521024-cc4c-41b8-aa58-59892aebfdef"), "Wein", "wqertzuiopoiuzhgvcfgnj", DateTime.Now.AddDays(58)),
                new Product(new Guid("20e5274d-35d7-48bc-9ad0-ce0b6469be82"), "Unterhose", "mnbvfdertzuiokjhgfc", DateTime.Now.AddDays(13)),
            };
        }
    }
}