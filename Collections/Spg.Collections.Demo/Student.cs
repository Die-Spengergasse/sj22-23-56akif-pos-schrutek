using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Collections.Demo
{
    //public record Student(Colors SelectedColor, string FirstName, string Lastname, string? PhoneNumber);

    public class Student : EntityBase
    {
        public Colors SelectedColor { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public void DoSomething()
        {
        }
    }
}
