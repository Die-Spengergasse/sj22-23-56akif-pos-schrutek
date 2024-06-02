using Spg.Sayonara.Application.Test.Helpers;
using Spg.Sayonara.Application.UseCases.Shop.Queries;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Test
{
    public class FilterParameterTests
    {
        [Fact()]
        public void Should_GetOneShopStartsWithS()
        {
            using (SayonaraContext db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
                db.SaveChanges();

                NameStartsWithFilterParameter utt = new NameStartsWithFilterParameter("name sw s");

                ShopRepository shopRepository = new ShopRepository(db);
                var builder = shopRepository.FilterBuilder;

                // Act
                builder = utt.Compile(builder);

                // Assert
                Assert.Equal(1, builder.Build().Count());
            }
        }
    }
}
