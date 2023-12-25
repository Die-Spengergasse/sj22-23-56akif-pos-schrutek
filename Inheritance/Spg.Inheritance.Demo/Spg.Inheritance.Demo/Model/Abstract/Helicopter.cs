using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Inheritance.Demo.Model.Abstract
{
    public class Helicopter : FlightDevice
    {
        public Helicopter()
            : base(4)
        { }

        public override void Start()
        {
            Console.WriteLine("Senkrecht nach oben");
        }

        public override void Land()
        {
            Console.WriteLine("Senkrecht nach unten");
        }
    }
}
