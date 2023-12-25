using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now =>
            DateTime.Now;
    }
}
