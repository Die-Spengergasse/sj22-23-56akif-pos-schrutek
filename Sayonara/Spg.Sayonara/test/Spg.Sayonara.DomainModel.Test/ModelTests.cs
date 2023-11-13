using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;

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
        Shop newEntity = new Shop(
            "MyShop", 
            "WasWeiﬂIch", 
                new Address("Street1", "4711", "City1", "1324"), 
                new PhoneNumber("0123", "123456789")
            );

        // Act
        SayonaraContext db = new SayonaraContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Shops.Add(newEntity);
        db.SaveChanges();

        // Assert
        Assert.Equal(2, db.Shops.Count());
    }
}