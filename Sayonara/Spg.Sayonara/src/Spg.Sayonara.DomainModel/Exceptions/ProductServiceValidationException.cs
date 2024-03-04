using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class ProductServiceValidationException : Exception
    {
        public ProductServiceValidationException()
            : base()
        { }

        public ProductServiceValidationException(string message)
            : base(message)
        { }

        public ProductServiceValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
