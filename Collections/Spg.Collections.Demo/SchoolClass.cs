using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Collections.Demo
{
    public enum Colors
    {
        Red, Blue, Green, BlueGreen, GreenYellow
    }

    //public record SchoolClass(string RoomNumber, Student Student);


    public class SchoolClass : EntityBase, IEquatable<SchoolClass>
    {
        public string RoomNumber { get; set; } = string.Empty;

        public IEnumerable<Student> Students { get; set; } = new List<Student>();





        public override bool Equals(object? obj)
        {
            return Equals(obj as SchoolClass);
        }

        public bool Equals(SchoolClass? other)
        {
            return RoomNumber == other?.RoomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomNumber);
        }
    }
}
