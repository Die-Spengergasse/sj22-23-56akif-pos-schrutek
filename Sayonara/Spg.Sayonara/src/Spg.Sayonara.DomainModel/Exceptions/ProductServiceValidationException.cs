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

        public static ProductServiceValidationException FromCategoryNotFound()
        {
            return new ProductServiceValidationException("Kategorie wurde nicht gefunden!");
        }
        public static ProductServiceValidationException FromNameExists()
        {
            return new ProductServiceValidationException("Produkt existiert in dieser Kategorie bereits!");
        }
        public static ProductServiceValidationException FromDatenotInFuture()
        {
            return new ProductServiceValidationException("Ablaufdatum ist nicht in der Zukunft!");
        }
    }
}
