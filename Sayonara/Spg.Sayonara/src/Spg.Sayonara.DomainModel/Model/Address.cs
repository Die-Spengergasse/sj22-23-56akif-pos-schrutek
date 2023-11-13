using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public record Address(string Street, string HouseNumber, string City, string Zipcode);

    //public class Address
    //{
    //    // TODO: Constructor
    //    public string Street { get; } = string.Empty;
    //    public string HouseNumber { get; } = string.Empty;
    //    public string City { get; } = string.Empty;
    //    public string Zipcode { get; } = string.Empty;
    //}
}
