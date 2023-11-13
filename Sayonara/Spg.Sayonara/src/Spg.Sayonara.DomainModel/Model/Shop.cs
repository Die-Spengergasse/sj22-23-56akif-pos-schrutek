using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Model
{
    public class Shop 
    {
        public Shop(
            string name, 
            string companySuffix, 
            Address? address, 
            PhoneNumber phoneNumber)
        {
            Name = name;
            CompanySuffix = companySuffix;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        // Wirklich nur, weil EF Core das braucht
        private Shop()
        { }

        public int Id { get; set; } // PK, wird von der DB erstellt
        public string Name { get; set; } = string.Empty;
        public string CompanySuffix { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; } = default!;
        
        //public EMail EMail { get; set; } // kommt später, weil Set<EMail>
    }
}
