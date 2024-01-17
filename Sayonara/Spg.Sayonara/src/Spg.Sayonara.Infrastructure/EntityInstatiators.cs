using Bogus;
using Spg.Sayonara.DomainModel.Model;

namespace Spg.Sayonara.Infrastructure
{
    public class EntityInstatiators
    {
        public static Shop InstantiateShop(Faker f)
        {
            return new Shop(
                f.Company.CompanyName(),
                f.Company.CompanySuffix(),
                new Address(f.Address.StreetName(), f.Address.BuildingNumber(), f.Address.City(), f.Address.ZipCode()),
                new PhoneNumber(f.Random.Int(1111, 9999).ToString(), f.Phone.PhoneNumber())
                );
        }
    }
}
