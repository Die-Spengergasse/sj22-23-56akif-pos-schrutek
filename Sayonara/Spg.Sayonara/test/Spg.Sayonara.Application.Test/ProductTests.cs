using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.Application.Mock;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.Application.Test.Helpers;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
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
    public void ShouldCreate_WhenParametersOk()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            // Arrange
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(
                new FakeDateTimeService(new DateTime(2024, 05, 03)),
                new CategoryRepository(db),
                new ProductRepository(db),
                new ProductRepository(db),
                new GuidServiceMock());
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 06, 05), 1);

            // Act
            ProductDto actual = productService.Create(newProduct);

            // Assert
            Assert.Equal(16, db.Products.Count());
            Assert.Equal("Testname", actual.Name);
            Assert.Equal("TestDescription", actual.Description);
            Assert.Equal(new DateTime(2024, 06, 05), actual.ExpiryDate);
            Assert.Equal(new Guid("07d39349-fe02-4b68-a2ad-4841a048f52f"), actual.Guid);
        }
    }

    [Fact]
    public void ShouldThrowValidationException_WhenCategoryNotFound()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            // Arrange
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(
                new FakeDateTimeService(new DateTime(2024, 05, 03)),
                new CategoryRepository(db),
                new ProductRepository(db),
                new ProductRepository(db),
                new GuidServiceMock());
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 05, 05), 99999);

            // Act + Assert
            ProductServiceValidationException ex = Assert.Throws<ProductServiceValidationException>(() => productService.Create(newProduct));
            Assert.Equal("Kategorie wurde nicht gefunden!", ex.Message);
        }
    }

    [Fact]
    public void ShouldThrowValidationException_WhenNameByCategoryNOTunique()
    {
        using (SayonaraContext db = DatabaseUtilities.CreateDb())
        {
            // Arrange
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(
                new FakeDateTimeService(new DateTime(2024, 05, 03)),
                new CategoryRepository(db),
                new ProductRepository(db),
                new ProductRepository(db),
                new GuidServiceMock());
            CreateProductCommand newProduct = new CreateProductCommand("Telefon", "Telefon Description", new DateTime(2024, 05, 05), 1);

            // Act + Assert
            ProductServiceValidationException ex = Assert.Throws<ProductServiceValidationException>(() => productService.Create(newProduct));
            Assert.Equal("Produkt existiert in dieser Kategorie bereits!", ex.Message);
        }
    }

    [Fact]
    public void Product_ShouldThrowExeption_WhenExpiryDateNot2WeeksInFurture()
    {
        using (SayonaraContext db = CreateDb())
        {
            // Arrange
            db.Shops.AddRange(DatabaseUtilities.GetSeedingShops());
            db.SaveChanges();

            ProductService productService = new ProductService(
                new FakeDateTimeService(new DateTime(2024, 05, 03)),
                new CategoryRepository(db),
                new ProductRepository(db),
                new ProductRepository(db),
                new GuidServiceMock());
            CreateProductCommand newProduct = new CreateProductCommand("Testname", "TestDescription", new DateTime(2024, 03, 05), 1);

            // Act + Assert
            ProductServiceValidationException ex = Assert.Throws<ProductServiceValidationException>(() => productService.Create(newProduct));
            Assert.Equal("Ablaufdatum ist nicht in der Zukunft!", ex.Message);
        }
    }
}