using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class ServiceReadException : Exception
    {
        public ServiceReadException()
            : base()
        { }

        public ServiceReadException(string message)
            : base(message)
        { }

        public ServiceReadException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static ServiceReadException FromNotFound(Exception ex)
        {
            return new ServiceReadException("Eintrag nicht gefunden!", ex);
        }
    }
}
