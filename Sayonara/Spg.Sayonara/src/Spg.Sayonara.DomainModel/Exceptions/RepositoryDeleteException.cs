using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Exceptions
{
    public class RepositoryDeleteException : Exception
    {
        public RepositoryDeleteException()
            : base()
        { }

        public RepositoryDeleteException(string message)
            : base(message)
        { }

        public RepositoryDeleteException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
