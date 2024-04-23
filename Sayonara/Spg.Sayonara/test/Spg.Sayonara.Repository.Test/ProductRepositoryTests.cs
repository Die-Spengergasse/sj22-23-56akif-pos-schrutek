using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository.Test
{
    public class ProductRepositoryTests
    {
        [Fact()]
        public void ShouldGetAllFifteenProducts()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ProductRepository(db)
                    .FilterBuilder
                    .Build();

                // Assert
                Assert.Equal(15, actual.Count());
            }
        }

        [Fact()]
        public void ShouldFilterProductsContainingT_WhenLowerCase()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ProductRepository(db)
                    .FilterBuilder
                    .ApplyNameContainsFilter("t")
                    .Build();

                // Assert
                Assert.Equal(5, actual.Count());
            }
        }

        [Fact()]
        public void ShouldFilterProductsContainingT_WhenMixedCase()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ProductRepository(db)
                    .FilterBuilder
                    .ApplyNameContainsFilter("T")
                    .Build();

                // Assert
                Assert.Equal(5, actual.Count());
            }
        }

        [Fact()]
        public void Should_GetOneShopByGuid()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                var actual = new ProductRepository(db).GetByGuid(new Guid("fe6f32b9-726c-4c12-90ce-2b31aa2ffa18"));

                // Assert
                Assert.Equal(new Guid("fe6f32b9-726c-4c12-90ce-2b31aa2ffa18"), actual.Guid);
                Assert.Equal("Telefon", actual.Name);
            }
        }
    }
}
