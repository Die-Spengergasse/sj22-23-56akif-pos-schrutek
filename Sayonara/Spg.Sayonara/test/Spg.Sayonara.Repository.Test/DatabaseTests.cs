using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Test.Helpers;

namespace Spg.Sayonara.Repository.Test;

public class DatabaseTests
{
    [Fact]
    public void ShouldCreateAndSeedDatabase()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            // Arrange
            var shops = DatabaseUtilities.GetSeedingShops();
            db.Shops.AddRange(shops);
            db.Customers.AddRange(DatabaseUtilities.GetSeedingCustomers());

            // Act
            db.SaveChanges();

            // Assert
            Assert.Equal(3, db.Shops.ToList().Count());
            Assert.Equal(4, db.Shops.ToList().ElementAt(0).Categories.Count());
            // Shop 1
            Assert.Equal(5, db.Shops.ToList().ElementAt(0).Categories.ElementAt(0).Products.Count());
            Assert.Equal(1, db.Shops.ToList().ElementAt(0).Categories.ElementAt(1).Products.Count());
            Assert.Equal(0, db.Shops.ToList().ElementAt(0).Categories.ElementAt(2).Products.Count());
            Assert.Equal(3, db.Shops.ToList().ElementAt(0).Categories.ElementAt(3).Products.Count());
            // Shop 2
            Assert.Equal(3, db.Shops.ToList().ElementAt(1).Categories.ElementAt(0).Products.Count());
            Assert.Equal(1, db.Shops.ToList().ElementAt(1).Categories.ElementAt(1).Products.Count());
            // Shop 3
            Assert.Equal(2, db.Shops.ToList().ElementAt(2).Categories.ElementAt(0).Products.Count());
            Assert.Equal(0, db.Shops.ToList().ElementAt(2).Categories.ElementAt(1).Products.Count());
            Assert.Equal(0, db.Shops.ToList().ElementAt(2).Categories.ElementAt(2).Products.Count());

            Assert.Equal(7, db.Customers.ToList().Count());
        }
    }
}