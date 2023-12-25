using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BurgerLaden.Demo
{
    public class VeggieBurgerBuilder : IBurgerBuilder
    {
        public IBurgerBuilder AddCheese()
        {
            throw new NotImplementedException();
        }

        public IBurgerBuilder AddPatty()
        {
            throw new NotImplementedException();
        }

        public IBurgerBuilder AddSalad()
        {
            throw new NotImplementedException();
        }

        public IBurgerBuilder AddSauce()
        {
            throw new NotImplementedException();
        }

        public IBurgerBuilder AddSauce(Sauces sauce)
        {
            throw new NotImplementedException();
        }

        public IBurgerBuilder AddTomato()
        {
            throw new NotImplementedException();
        }

        public decimal Build()
        {
            throw new NotImplementedException();
        }
    }
}
