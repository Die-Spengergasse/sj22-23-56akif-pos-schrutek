using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.Application.Servcies;
using Spg.Sayonara.DomainModel.Interfaces;

namespace Spg.Sayonara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        // API-Design
        // <- URI -------------------------------------------------------...
        // https://www.myshop.at/users?filterbyname=huber&state=activated&ysdadasd=asddas&asdasdasd=asddasd&....
        // <-------------------><----><----------------------------------...
        //         URL           PATH            QUERY-(String)
        //
        // * Methoden (Verbs)
        // GET:     https://www.myshop.at/users         .. Lifert alle User
        // GET:     https://www.myshop.at/users/4711    .. Liefert den User mit ID 4711
        // GET:     https://www.myshop.at/users?filterbyname=huber&page=12&size10
        // GET:     https://www.myshop.at/users/4711/shoppingcarts          .. Liefert alle Warenkörbe eines bestimmten Users
        // GET:     https://www.myshop.at/users/4711/shoppingcarts/1234     .. Liefert einen Warenkorb eines bestimmten Users
        // GET:     https://www.myshop.at/users/4711/shoppingcarts/1234/... ..
        // POST:    https://www.myshop.at/users         .. Legt EINEN User an
        // PUT:     https://www.myshop.at/users/4711    .. Aktualisiert den User 4711 mit allen Daten
        // PATCH:   https://www.myshop.at/users/4711    .. Aktualisiert bestimmte Daten
        // DELETE:  https://www.myshop.at/users/4711    .. Löscht den User 4711
        //
        // * Status Codes
        // 200 OK
        // 201 Created
        // 400 Bad Request
        // 404 Not Found
        // 500 Internal Server Error
        // ...

        // Microsoft Learn dazu:
        // https://learn.microsoft.com/de-de/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api
        // https://learn.microsoft.com/de-de/aspnet/web-api/overview/web-api-routing-and-actions/create-a-rest-api-with-attribute-routing

        private readonly IReadOnlyShopService _shopService;

        public ShopsController(IReadOnlyShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_shopService.GetAll());
        }

        [HttpGet("fast")]
        public IActionResult GetFastAll()
        {
            return Ok(_shopService.GetAll());
        }
    }
}
