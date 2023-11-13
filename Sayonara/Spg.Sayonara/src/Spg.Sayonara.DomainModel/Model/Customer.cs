using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class Customer
    {
        public string Username { get; set; } = string.Empty;
        public DateTime RegistrationDateTime { get; set; }
        public Address Address { get; set; } = default!;
    }
}
