using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Linq.Demo
{
    public class StudentDto
    {
        public StudentDto(string firstName)
        {
            FirstName = firstName;
        }

        public string FirstName { get; set; }
    }
}
