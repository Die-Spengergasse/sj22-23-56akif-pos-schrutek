using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class RepositoryReadException : Exception
    {
        public RepositoryReadException()
            : base()
        { }

        public RepositoryReadException(string message)
            : base(message)
        { }

        public RepositoryReadException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static RepositoryReadException FromNotFound()
        {
            return new RepositoryReadException("Eintrag nicht gefunden!");
        }
    }
}