using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.DomainModel.Test.Helpers;
using Spg.Sayonara.DomainModel.Validation;
using Spg.Sayonara.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Spg.Sayonara.DomainModel.Test;

public class ModelTests
{
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
        using (SayonaraContext db = DatabaseUtilities.CreateMemoryDb())
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
        using (SayonaraContext db = DatabaseUtilities.CreateMemoryDb())
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
        using (SayonaraContext db = DatabaseUtilities.CreateMemoryDb())
        {
            db.Shops.Add(newShop);
            db.SaveChanges();

            // Assert
            Assert.Equal(1, db.Shops.Count());
            Assert.Equal(2, db.Shops.First().Categories.Count());
        }
    }

    [Fact()]
    public void Shop_ShouldBeFalse_WhenNameTooLong()
    {
        Shop shop = new Shop("asdadda", "asdasdasd", new Address("asdasd", "asdasd", "asdasd", "asdasd"), new PhoneNumber("0664", "78789"));
        shop.Name = "asdasdasdadasdsaasdasdadsadsadssdaasdasdasdasdasdasdasdasdasdasdadsadsadsA";

        Validator<Shop> shopValidator = new Validator<Shop>();
        bool actual = shopValidator.Validate(shop);

        Assert.False(actual);
    }

    [Fact()]
    public void Shop_ShouldBeFalse_WhenNameContainsHomer()
    {
        Shop shop = new Shop("asdadda", "asdasdasd", new Address("asdasd", "asdasd", "asdasd", "asdasd"), new PhoneNumber("0664", "78789"));
        shop.Name = "asdhomer";

        Validator<Shop> shopValidator = new Validator<Shop>();
        bool actual = shopValidator.Validate(shop);

        Assert.False(actual);
    }

    [Fact()]
    public void Shop_ShouldBeTrue()
    {
        Shop shop = new Shop("asdadda", "asdasdasd", new Address("asdasd", "asdasd", "asdasd", "asdasd"), new PhoneNumber("0664", "78789"));
        shop.Name = "asd";

        Validator<Shop> shopValidator = new Validator<Shop>();
        bool actual = shopValidator.Validate(shop);

        Assert.True(actual);
    }

    [Fact()]
    public void Shop_ShouldBeFalse_WhenNameContainsHomerInConstructior()
    {
        Shop shop = new Shop("xxx_homer", "asdasdasd", new Address("asdasd", "asdasd", "asdasd", "asdasd"), new PhoneNumber("0664", "78789"));

        Validator<Shop> shopValidator = new Validator<Shop>();
        bool actual = shopValidator.Validate(shop);

        Assert.False(actual);
    }

    [Fact()]
    public void Shop_ShouldReturnAValidDto()
    {
        // Arrange
        Shop expected = new Shop("xxx_homer", "asdasdasd", new Address("asdasd", "asdasd", "asdasd", "asdasd"), new PhoneNumber("0664", "78789"));
        
        // Act
        ShopDto actual = expected.ToDto();

        // Assert
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.CompanySuffix, actual.CompanySuffix);
        Assert.Equal(expected.Address.City, actual.Address.City);
        Assert.Equal(expected.Address.Street, actual.Address.Street);
        Assert.Equal(expected.Address.HouseNumber, actual.Address.HouseNumber);
    }

    [Fact()]
    public void Shop_ShouldReturnAValidDtoWithoutAddress()
    {
        // Arrange
        Shop expected = new Shop("xxx_homer", "asdasdasd", null, new PhoneNumber("0664", "78789"));

        // Act
        ShopDto actual = expected.ToDto();

        // Assert
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.CompanySuffix, actual.CompanySuffix);
        Assert.Equal(expected.Address?.City, actual.Address?.City);
    }
}