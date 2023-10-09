using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Collections.Demo.InterfacesDemo
{
    public class Helicopter : IUfo
    {
        public int Seats { get; set; }

        public void Landing()
        {
            // Senkrecht down
        }

        public void TakeOff()
        {
            Console.WriteLine("Senkrecht up");
        }
    }
}
