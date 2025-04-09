using Microsoft.AspNetCore.Mvc;

namespace HttpContext_HttpRequest_HttpRespone.Controllers;

public class ResponseDemoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Test()
    {
        Response.Headers.Append("X-MyHeader", "MyValue");
        FileInfo file = new FileInfo("wwwroot/images/aspnet.png");
        Response.ContentType = "text/html";
        Response.ContentLength = file.Length;
        using (var fileStream = file.OpenRead())
        {
            await fileStream.CopyToAsync(Response.Body);
        }
        return Ok();
    }
}