using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoAcAtRo.Models;
using CoAcAtRo.Services;

namespace CoAcAtRo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUser _user;
    public HomeController(ILogger<HomeController> logger, IUser user)
    {
        this._user = user;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult User()
    {
        _logger.LogInformation("get user - method: {m}",Request.Method);
        return Content( "User: " + string.Join(",",_user.Users) );
    }
    [HttpPost]
    public IActionResult User(string name)
    {
        Validation(name);
        _user.AddUser(name);
        _logger.LogInformation("add user: {u} - method: {m}", name,Request.Method);
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteUser(string name)
    {
        Validation(name);
        _user.RemoveUser(name);
        _logger.LogInformation("remove user: {u} - method: {m}", name,Request.Method);
        return Ok();
    }

    private void Validation(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
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