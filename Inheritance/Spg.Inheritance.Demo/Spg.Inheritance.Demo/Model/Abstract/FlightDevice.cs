using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Inheritance.Demo.Model.Abstract
{
    public abstract class FlightDevice
    {
        public int Passengers { get; set; }

        protected FlightDevice(int passengers)
        {
            Passengers = passengers;
        }

        public void PrintPassengers()
        {
            Console.WriteLine($"{Passengers} Passagiere");
        }

        public abstract void Start();

        public abstract void Land();
    }
}
