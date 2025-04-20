using Microsoft.AspNetCore.Mvc;

namespace CloneMySession.Controllers;

public class Test : Controller
{
    // GET
    public IActionResult TestSestionContainer()
    {
        var session = HttpContext.GetSession();
        session.SetString("Name", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        session = HttpContext.GetSession();
        var name = session.GetString("Name");
        if(name == "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            return Ok();
        }
        else
        {
            return BadRequest("Session not found");
        }
    }
}