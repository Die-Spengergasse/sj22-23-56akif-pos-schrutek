using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BurgerLaden.Demo
{
    public class MeatBurgerBuilder : IBurgerBuilder
    {
        private decimal _burgerSettings = 0;

        private List<string> _products;

        //ctor

        public IBurgerBuilder AddCheese()
        {
            //_products = _products.Where(p => p.Name.Contains(""));

            _burgerSettings = _burgerSettings + 1.2M;
            return this;
        }

        public IBurgerBuilder AddPatty()
        {
            _burgerSettings = _burgerSettings + 3.5M;
            return this;
        }

        public IBurgerBuilder AddSalad()
        {
            _burgerSettings = _burgerSettings + 0.1M;
            return this;
        }

        public IBurgerBuilder AddSauce(Sauces sauce)
        {
            _burgerSettings = _burgerSettings + 0.5M;
            return this;
        }

        public IBurgerBuilder AddTomato()
        {
            _burgerSettings = _burgerSettings + 1.4M;
            return this;
        }

        public decimal Build()
        {
            return _burgerSettings;
        }
    }
}
