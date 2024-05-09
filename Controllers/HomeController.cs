using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiddlewareNet8.Models;

namespace MiddlewareNet8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

     [HttpPost]
    public IActionResult PostData()
    {
        _logger.LogInformation("Received a POST request.");

        // Process the POST request (e.g., perform some action)

        return View(); // Return 200 OK response
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
