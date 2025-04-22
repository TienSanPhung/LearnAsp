using Microsoft.AspNetCore.Mvc;

namespace CloneMySession.Controllers;

public class UnitController : Controller
{
   
    // GET
    public IActionResult TestContainer()
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
    public async Task<IActionResult> SetSessionValue(string key, string value)
    {
        var session = HttpContext.GetSession();
        await session.LoadAsync();
        session.SetString(key,value);
        await session.CommitAsync();
        return Ok();
    }
    public async Task<IActionResult> GetSessionValue(string key)
    {
        var session = HttpContext.GetSession();
        await session.LoadAsync();
        var value = session.GetString(key);
        return Ok(value);
    }
}