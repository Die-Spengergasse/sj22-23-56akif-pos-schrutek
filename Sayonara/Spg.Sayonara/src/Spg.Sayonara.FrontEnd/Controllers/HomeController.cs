using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Spg.Sayonara.FrontEnd.Models;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

namespace Spg.Sayonara.FrontEnd.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SayonaraContext _db;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(
        ILogger<HomeController> logger, 
        SayonaraContext db, 
        IStringLocalizer<HomeController> localizer)
    {
        _logger = logger;
        _db = db;
        _localizer = localizer;

        new DbSeedService(db)
            .Seed();
    }

    public IActionResult Index()
    {
        ViewData["Greeting"] = _localizer["Greeting"];

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
