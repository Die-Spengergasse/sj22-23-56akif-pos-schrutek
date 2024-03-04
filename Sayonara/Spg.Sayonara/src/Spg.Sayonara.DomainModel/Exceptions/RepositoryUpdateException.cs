using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class RepositoryUpdateException : Exception
    {
        public RepositoryUpdateException()
            : base()
        { }

        public RepositoryUpdateException(string message)
            : base(message)
        { }

        public RepositoryUpdateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}