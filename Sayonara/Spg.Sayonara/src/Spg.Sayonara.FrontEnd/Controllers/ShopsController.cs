using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.DomainModel.Model;

namespace Spg.Sayonara.FrontEnd.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            //List<Shop> model = _shopService.GetAll().ToList();
            return View(new List<Shop>());
        }
    }
}
