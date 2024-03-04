using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Repository.Test
{
    public class CategoryRepositoryTests
    {
        [Fact()]
        public void ShouldGetOneCategory_WhenIdIsGiven()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                Category? actual = new CategoryRepository(db).GetCategoryOrDefault(5);

                // Assert
                Assert.Equal("Getränke", actual!.Name);
            }
        }

        [Fact()]
        public void ShouldGetNull_WhenIdIsWrong()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                Category? actual = new CategoryRepository(db).GetCategoryOrDefault(99999);

                // Assert
                Assert.Null(actual);
            }
        }

        [Fact()]
        public void GetCategory_JustForFun_ShouldGetOneCategory_WhenIdIsGiven()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                // Act
                Category? actual = new CategoryRepository(db).GetCategoryOrDefault(5);

                // Assert
                Assert.Equal("Getränke", actual!.Name);
            }
        }
    }
}
