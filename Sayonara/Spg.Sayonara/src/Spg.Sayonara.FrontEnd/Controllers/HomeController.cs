using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.FrontEnd.Models;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;

namespace Spg.Sayonara.FrontEnd.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SayonaraContext _db;

    public HomeController(ILogger<HomeController> logger, SayonaraContext db)
    {
        _logger = logger;
        _db = db;

        new DbSeedService(db)
            .Seed();
    }

    public IActionResult Index()
    {
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
