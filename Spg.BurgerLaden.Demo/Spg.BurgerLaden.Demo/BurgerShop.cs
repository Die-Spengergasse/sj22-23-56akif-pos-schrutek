using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BurgerLaden.Demo
{
    // Repository
    public class BurgerShop
    {
        public IBurgerBuilder BurgerBuilder => new MeatBurgerBuilder();

        public void Create()
        { }

        public void Update()
        { }

        public void Delete()
        { }

        //public void GenerateMeatBurger()
        //{
        //    decimal price = new MeatBurgerBuilder()
        //        .AddPatty()
        //        .AddCheese()
        //        .AddPatty()
        //        .AddSalad()
        //        .AddTomato()
        //        .AddTomato()
        //        .AddPatty()
        //        .AddSauce(Sauces.BBQ)
        //        .Build();
        //}
    }
}
