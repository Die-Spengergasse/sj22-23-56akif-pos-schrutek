using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Collections.Demo.InterfacesDemo
{
    public interface IUfo
    {
        public int Seats { get; set; }

        public void TakeOff();

        public void Landing();
    }
}
