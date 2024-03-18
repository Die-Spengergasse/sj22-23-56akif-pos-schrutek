using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class GuidService : IGuidService
    {
        public Guid NewGuid()
            => Guid.NewGuid();
    }
}
