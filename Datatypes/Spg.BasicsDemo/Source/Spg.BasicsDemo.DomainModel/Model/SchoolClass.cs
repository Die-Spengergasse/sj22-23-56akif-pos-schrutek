using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BasicsDemo.DomainModel.Model
{
    /// <summary>
    /// Immutable
    /// </summary>
    public class SchoolClass
    {
        //public SchoolClass(string roomNumber)
        //{
        //    RoomNumber = roomNumber;
        //}

        public string RoomNumber { get; init; }
    }
}
