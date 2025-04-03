using Microsoft.AspNetCore.Mvc;

namespace CoAcAtRo.Controllers;

public class ProductController : Controller
{
    // GET
    [Route("/p/{id:int}")]
    public IActionResult Index(int id)
    {
        return View("Index", id.ToString() + " (int)");
    }
    [Route("/p/{id?}")]
    public IActionResult Index(string id)
    {
        return View("Index", id + "(string)");
    }
}