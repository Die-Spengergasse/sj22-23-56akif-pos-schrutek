using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

namespace Spg.Sayonara.Repository.Test.Helpers 
{
    public static class DatabaseUtilities
    {
        public static SayonaraContext CreateDb()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;

            SayonaraContext db = new SayonaraContext(options);
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
                    new PhoneNumber("0123", "123456789"))
                    .AddCategory(GetSeedingCategories().ElementAt(0))
                    .AddCategory(GetSeedingCategories().ElementAt(1))
                    .AddCategory(GetSeedingCategories().ElementAt(2))
                    .AddCategory(GetSeedingCategories().ElementAt(3)),
                new Shop("Online Dings", "KG",
                    new Address("Street2", "1323B", "City1", "1245"),
                    new PhoneNumber("0123", "123456789"))
                    .AddCategory(GetSeedingCategories().ElementAt(4))
                    .AddCategory(GetSeedingCategories().ElementAt(5)),
                new Shop("Krimskrams", "AG",
                    new Address("Street3", "4535C", "City1", "1212"),
                    new PhoneNumber("0123", "123456789"))
                    .AddCategory(GetSeedingCategories().ElementAt(6))
                    .AddCategory(GetSeedingCategories().ElementAt(7))
                    .AddCategory(GetSeedingCategories().ElementAt(8)),
            };
        }

        public static List<Category> GetSeedingCategories()
        {
            return new List<Category>()
            {
                new Category("Kleidung")
                .AddProduct(GetSeedingProducts().ElementAt(0))
                .AddProduct(GetSeedingProducts().ElementAt(2))
                .AddProduct(GetSeedingProducts().ElementAt(3))
                .AddProduct(GetSeedingProducts().ElementAt(5))
                .AddProduct(GetSeedingProducts().ElementAt(6)),
                new Category("Elektronik")
                .AddProduct(GetSeedingProducts().ElementAt(8)),
                new Category("Haushalt"),
                new Category("Mobilfunk")
                .AddProduct(GetSeedingProducts().ElementAt(9))
                .AddProduct(GetSeedingProducts().ElementAt(10))
                .AddProduct(GetSeedingProducts().ElementAt(13)),
                new Category("Getränke")
                .AddProduct(GetSeedingProducts().ElementAt(4))
                .AddProduct(GetSeedingProducts().ElementAt(7))
                .AddProduct(GetSeedingProducts().ElementAt(14)),
                new Category("Kleidung")
                .AddProduct(GetSeedingProducts().ElementAt(1)),
                new Category("Werkzeug")
                .AddProduct(GetSeedingProducts().ElementAt(11))
                .AddProduct(GetSeedingProducts().ElementAt(12)),
                new Category("Garten"),
                new Category("Elektronik")
            };
        }

        public static List<Product> GetSeedingProducts()
        {
            return new List<Product>()
            {
                new Product("Dings", "asddadsdsa", DateTime.Now.AddDays(30)),
                new Product("Scharubenzieher", "qweeqweqweqw", DateTime.Now.AddDays(12)),
                new Product("Telefon", "ascxyyxccxy", DateTime.Now.AddDays(34)),
                new Product("Handy", "cxvxcv", DateTime.Now.AddDays(32)),
                new Product("T-Shirt", "sfdxvccvbccncnb", DateTime.Now.AddDays(18)),
                new Product("Socken", "n dfgbadvsf<sdnmgfhdy v", DateTime.Now.AddDays(92)),
                new Product("Socken", "xcvyfds ", DateTime.Now.AddDays(14)),
                new Product("T-Shirt", "drzjkjhgfhjhfbfvdf", DateTime.Now.AddDays(71)),
                new Product("Stabmixer", "sdfgtkjhhgfewehtfgbfx", DateTime.Now.AddDays(25)),
                new Product("Cocal Cola", "fsewertuizoplkhjgfd", DateTime.Now.AddDays(37)),
                new Product("Bier", "dsafgjhkukjfhdgsadvcx", DateTime.Now.AddDays(88)),
                new Product("Schneeschaufel", "erwzutkghnbvfetrzukjgh", DateTime.Now.AddDays(45)),
                new Product("Blumen", "sertzuiokjhgfdcx", DateTime.Now.AddDays(5)),
                new Product("Wein", "wqertzuiopoiuzhgvcfgnj", DateTime.Now.AddDays(58)),
                new Product("Unterhose", "mnbvfdertzuiokjhgfc", DateTime.Now.AddDays(13)),
            };
        }

        public static List<Customer> GetSeedingCustomers()
        {
            return new List<Customer>()
            {
                new Customer(new Guid("aab9a4d1-75a8-4b2a-b8d4-e0ed0ebf1f80"), Genders.Male, "Hans", "Hofer", new PhoneNumber("0677", "21233456"), new EMail("Hans.Hofer@gmx.at"), "", DateTime.Now, new Address("Wohnstrasse", "12A/45/2/8", "Ort", "1234")),
                new Customer(new Guid("738808ad-ca68-4508-b907-324755dc1c54"), Genders.Male, "Susi", "Mayer", new PhoneNumber("0664", "3241235"), new EMail("Susi123@aon.at"), "", DateTime.Now, new Address("Wohnstrasse", "443-A", "Wien", "3455")),
                new Customer(new Guid("ccea8fc5-079a-4c95-8778-0b515cd4b96c"), Genders.Male, "Luise", "Müller", new PhoneNumber("0670", "1246578"), new EMail("Luise456@gmx.at"), "", DateTime.Now, new Address("Wohnstrasse", "56", "Pöltn", "1234")),
                new Customer(new Guid("e4c00cd3-e94e-4146-9248-c9ff4f71d0a7"), Genders.Male, "Anna", "Theke", new PhoneNumber("0680", "2158963"), new EMail("Anna.Theke@gmx.at"), "", DateTime.Now, new Address("Beethofengasse", "12-C", "Strasshof", "1142")),
                new Customer(new Guid("b86dfdca-0135-4c32-8e2c-e7cda077f741"), Genders.Male, "Rainer", "Zufall", new PhoneNumber("0664", "22358874"), new EMail("Rainer_Zufall@gmail.at"), "", DateTime.Now, new Address("Schubertgasse", "56B", "Klosterneuberg", "2214")),
                new Customer(new Guid("8043741f-d264-4c3b-a0f0-3ff5da6c6d0b"), Genders.Male, "Franz", "Baumeister", new PhoneNumber("0677", "14785236"), new EMail("Baumeister798@gmail.at"), "", DateTime.Now, new Address("Lilienplatz", "123/2/3", "Kirchdorf", "1123")),
                new Customer(new Guid("c718c3e7-fa51-47cb-b105-08e97fa7670c"), Genders.Male, "Monika", "Rauchfangkehrer", new PhoneNumber("0664", "369855222"), new EMail("Rauchfangkehrer123@outlook.at"), "", DateTime.Now, new Address("Dorf", "1", "Bern", "1025")),
            };
        }
    }
}