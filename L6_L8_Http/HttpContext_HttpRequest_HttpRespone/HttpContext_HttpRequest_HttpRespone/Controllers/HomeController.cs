using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HttpContext_HttpRequest_HttpRespone.Models;
using HttpContext_HttpRequest_HttpRespone.Helpers;

namespace HttpContext_HttpRequest_HttpRespone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Id: {Id} from {rq}", HttpContext.TraceIdentifier,Request.GetDebugIf());
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