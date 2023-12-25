using System.Net.Http.Headers;

namespace Spg.BurgerLaden.Demo
{
    public interface IBurgerBuilder
    {
        IBurgerBuilder AddPatty();
        IBurgerBuilder AddCheese();
        IBurgerBuilder AddSalad();
        IBurgerBuilder AddSauce(Sauces sauce);
        IBurgerBuilder AddTomato();
        decimal Build();
    }
}