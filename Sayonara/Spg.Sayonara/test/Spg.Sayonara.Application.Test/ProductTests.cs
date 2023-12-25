using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Application.Mock;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

namespace Spg.Sayonara.Application.Test;

public class ProductTests
{
    private SayonaraContext CreateDb()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseSqlite("Data Source=.\\..\\..\\..\\..\\..\\Sayonara_UnitTests.db");

        SayonaraContext db = new SayonaraContext(builder.Options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        return db;
    }

    [Fact]
    public void Product_ShouldCreate_WhenExpiryDate2WeeksInFurture()
    {
        using (SayonaraContext db = CreateDb())
        {
            // Arrange
            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)));

            // Act
            productService.Create("Testname", "TestDescription", new DateTime(2024, 05, 27));

            // Assert
            Assert.Equal(1, db.Products.Count());
        }
    }

    [Fact]
    public void Product_ShouldThrowExeption_WhenExpiryDateNot2WeeksInFurture()
    {
        using (SayonaraContext db = CreateDb())
        {
            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)));

            // Arrange+ Act + Assert
            Assert.Throws<Exception>(() =>
                productService
                    .Create("Testname", "TestDescription", new DateTime(2024, 05, 05)));
        }
    }
}