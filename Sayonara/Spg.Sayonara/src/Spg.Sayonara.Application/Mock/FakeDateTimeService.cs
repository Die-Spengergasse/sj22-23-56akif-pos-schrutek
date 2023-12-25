using Spg.Sayonara.Application.Servcies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Mock
{
    public class FakeDateTimeService : IDateTimeService
    {
        private readonly DateTime _fakeDateTime;

        public FakeDateTimeService(DateTime fakeDateTime)
        {
            _fakeDateTime = fakeDateTime;
        }
        public DateTime Now
            => _fakeDateTime; //new DateTime(2023, 05, 03); // festgelegtes Datum X
    }
}
