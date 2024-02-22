﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.Application.Servcies;

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



        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_shopService.GetAll());
        }

        [HttpGet()]
        public IActionResult GetFastAll()
        {
            return Ok(_shopService.GetAll());
        }
    }
}