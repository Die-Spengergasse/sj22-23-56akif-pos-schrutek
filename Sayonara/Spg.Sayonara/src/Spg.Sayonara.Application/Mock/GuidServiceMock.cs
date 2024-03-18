using Spg.Sayonara.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Mock
{
    public class GuidServiceMock : IGuidService
    {
        public Guid NewGuid()
            => new Guid("07d39349-fe02-4b68-a2ad-4841a048f52f");
    }
}
