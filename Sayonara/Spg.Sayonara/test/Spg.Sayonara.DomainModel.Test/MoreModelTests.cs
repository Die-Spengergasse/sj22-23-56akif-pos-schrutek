using Spg.Sayonara.DomainModel.Test.Helpers;
using Spg.Sayonara.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Test
{
    public class MoreModelTests
    {
        [Fact()]
        public void ShouldCreateAndSeedDatabase()
        {
            using (UnitTestContext db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                var shops = DatabaseUtilities.GetSeedingShops();
                var categories = DatabaseUtilities.GetSeedingCategories(shops);
                var products = DatabaseUtilities.GetSeedingProducts(categories);

                // Act
                db.Shops.AddRange(shops);
                db.Categories.AddRange(categories);
                db.Products.AddRange(products);
                db.SaveChanges();

                // Assert
                Assert.Equal(3, db.Shops.Count());
                Assert.Equal(9, db.Categories.Count());
                Assert.Equal(15, db.Products.Count());
            }
        }

        [Fact()]
        public void ShouldCreateAndSeedDatabaseWithBogus()
        {
            using (UnitTestContext db = DatabaseUtilities.CreateDb())
            {
                // Act
                new DbSeedService(db).Seed();

                // Assert
                Assert.Equal(50, db.Shops.Count());
            }
        }
    }
}