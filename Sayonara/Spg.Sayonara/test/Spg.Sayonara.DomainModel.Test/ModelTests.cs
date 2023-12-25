using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

namespace Spg.Sayonara.DomainModel.Test;

public class ModelTests
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

    /// <summary>
    /// Naming Pattern: Action_Should..._When...
    /// </summary>
    [Fact]
    public void Create_Shop_ShouldSucceed_WhenParametersValid()
    {
        // Arrange
        Shop newShop = new Shop(
            "MyShop", 
            "WasWeiﬂIch", 
                new Address("Street1", "4711", "City1", "1324"), 
                new PhoneNumber("0123", "123456789")
            );

        // Act
        using (SayonaraContext db = CreateDb())
        {
            db.Shops.Add(newShop);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Shops.Count());
        }
    }

    [Fact]
    public void Create_ShopAndCategory_ShouldSucceed_WhenParametersValid()
    {
        // Arrange
        Shop newShop = new Shop(
            "MyShop",
            "WasWeiﬂIch",
                new Address("Street1", "4711", "City1", "1324"),
                new PhoneNumber("0123", "123456789")
            )
            .AddCategory(new Category("Kleidung"));

        // Act
        using (SayonaraContext db = CreateDb())
        {
            db.Shops.Add(newShop);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Shops.Count());
            Assert.Single(db.Shops.First().Categories);
        }
    }

    [Fact]
    public void Create_ShopAndCategories_ShouldSucceed_WhenParametersValid()
    {
        // Arrange
        Shop newShop = new Shop(
            "MyShop",
            "WasWeiﬂIch",
                new Address("Street1", "4711", "City1", "1324"),
                new PhoneNumber("0123", "123456789")
            )
            .AddCategories(new List<Category>() 
            { 
                new Category("Kleidung"), new Category("Technik")
            });

        // Act
        using (SayonaraContext db = CreateDb())
        {
            db.Shops.Add(newShop);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Shops.Count());
            Assert.Equal(2, db.Shops.First().Categories.Count());
        }
    }

}