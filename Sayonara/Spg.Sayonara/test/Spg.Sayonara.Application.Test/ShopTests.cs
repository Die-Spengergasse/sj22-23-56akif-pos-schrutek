using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Application.Test.Helpers;
using Spg.Sayonara.Application.UseCases.Shop.Queries;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

namespace Spg.Sayonara.Application.Test
{
    public class ShopTests
    {
        [Fact]
        public void Should_GetKrimskramsShop()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                ShopService utt = new ShopService(new ShopRepository(db));

                // Act
                ShopDto actual = utt.GetFiltered(new GetShopsQuery("krimskrams", "", DateTime.Now)).Last();

                // Assert
                Assert.Equal("Krimskrams", actual.Name);
                Assert.Equal("AG", actual.CompanySuffix);
            }
        }

        [Fact]
        public void Should_NOTGetKrimskramsShop_WhenInvalidName()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                ShopService utt = new ShopService(new ShopRepository(db));

                // Act + Assert
                ServiceReadException ex = Assert.Throws<ServiceReadException>(
                    () => utt.GetFiltered(new GetShopsQuery("krimskramsxxxx", "", DateTime.Now)));
                Assert.Equal($"Shop krimskramsxxxx nicht gefunden!", ex.Message);
            }
        }

        [Fact()]
        public void Should_FilterShopsStartsWithS()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                GetShopsFilteredModel request = new GetShopsFilteredModel(new GetShopsFilteredQuery("name sw s", ""));

                GetShopsFilteredHandler utt = new GetShopsFilteredHandler(new ShopRepository(db));

                // Act
                var actual = utt.Handle(request, CancellationToken.None);

                // Assert
                Assert.Equal(1, actual.Result.Count());
            }
        }
    }
}
