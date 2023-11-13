using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Spg.Sayonara.DomainModel.Model
{
    // Eigent sich gut für Value Objects
    public record PhoneNumber(string Prefix, string Number)
    {
        public string FullNumber()
        {
            return $"{Prefix} / {Number}";
        }
    }
}
