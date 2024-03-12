using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.RichTypes
{
    public record FirstName(string Value)
    {
        public bool IsValid()
        {
            if (Value.Contains("homer"))
            {
                return false;
            }
            return true;
        }
    }
}
