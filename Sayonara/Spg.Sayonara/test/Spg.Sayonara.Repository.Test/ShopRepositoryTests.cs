using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository.Test
{
    public class ShopRepositoryTests
    {
        [Fact()]
        public void ShouldGetAllThreeShops()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ShopRepository(db)
                    .FilterBuilder
                    .Build();

                // Assert
                Assert.Equal(3, actual.Count());
            }
        }

        [Fact()]
        public void ShouldFilterOneShop_WhenLowerCase()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ShopRepository(db)
                    .FilterBuilder
                    .ApplyNameContainsFilter("dings")
                    .Build();

                // Assert
                Assert.Single(actual);
            }
        }

        [Fact()]
        public void ShouldFilterOneShop_WhenMixedCase()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ShopRepository(db)
                    .FilterBuilder
                    .ApplyNameContainsFilter("Dings")
                    .Build();

                // Assert
                Assert.Single(actual);
            }
        }
    }
}
