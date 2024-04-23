using Bogus.DataSets;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Application.Test.Helpers;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ShopDto actual = utt.GetFilteredByName("krimskrams");

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
                ServiceReadException ex = Assert.Throws<ServiceReadException>(() => utt.GetFilteredByName("krimskramsxxxx"));
                Assert.Equal($"Shop krimskramsxxxx nicht gefunden!", ex.Message);
            }
        }
    }
}
