using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Application.Mock;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Application.Test.Helpers;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

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
            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)), new CategoryRepository(db));
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 05, 27), 1);

            // Act
            productService.Create(newProduct);

            // Assert
            Assert.Equal(1, db.Products.Count());
        }
    }

    [Fact]
    public void Product_ShouldThrowExeption_WhenExpiryDateNot2WeeksInFurture()
    {
        using (SayonaraContext db = CreateDb())
        {
            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)),new CategoryRepository(db));
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 05, 05), 1);

            // Arrange+ Act + Assert
            Assert.Throws<Exception>(() =>
                productService
                    .Create(newProduct));
        }
    }

    [Fact]
    public void ShouldCreate_WhenParametersOk()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)), new CategoryRepository(db));
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 05, 05), 1);

            // Act
            productService.Create(newProduct);

            // Assert
            Assert.Equal(16, db.Products.Count());
        }
    }

    [Fact]
    public void ShouldThrowValidationException_WhenCategoryNotFound()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(db, new FakeDateTimeService(new DateTime(2024, 05, 03)), new CategoryRepository(db));
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 05, 05), 99999);

            // Act + Assert
            Assert.Throws<ProductServiceValidationException>(() => productService.Create(newProduct));
        }
    }
}