using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class Customer : Person, IFindableByGuid, IFindableByEMail, IFindableByLastName
    {
        public string Username { get; set; } = string.Empty;
        public DateTime RegistrationDateTime { get; set; }
        public Address Address { get; set; } = default!;

        protected Customer()
        { }
        public Customer(Guid guid, Genders gender, string firstName, string lastName, PhoneNumber phoneNumber, EMail eMail,
            string username, DateTime registrationDateTime, Address address)
            : base(guid, gender, firstName, lastName, phoneNumber, eMail)
        {
            Username = username;
            RegistrationDateTime = registrationDateTime;
            Address = address;
        }
    }
}
