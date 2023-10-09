using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Collections.Demo.InterfacesDemo
{
    public class JoboJet : IUfo
    {
        public int Seats { get; set; }

        public void Landing()
        {
            // Aufsetzten, Schubumkehr, ...
        }

        public void TakeOff()
        {
            Console.WriteLine("Beschleunigen auf 300kmh");
        }
    }
}
