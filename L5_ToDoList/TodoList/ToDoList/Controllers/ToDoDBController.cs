using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class ToDoDbController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ToDoListManagerFromDb _listManager;
    

    public ToDoDbController(ToDoListManagerFromDb listManager,ILogger<HomeController> logger)
    {
        _listManager = listManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var todolistItem = _listManager.GetListItems();
        return View(new TodolistViewModel(){Item = todolistItem.Select(it => new Item()
            {
                Id = it.Id,
                Description = it.Description,
                Status = it.Status
            })
        });
       
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }
    [HttpPost]
    public IActionResult Create(Item item)
    {
        _listManager.AddItems(new ToDoItem()
        {
            Description = item.Description,
            Status = false
        });
        _logger.LogInformation("Created new item");
        return RedirectToAction("Index");
    }
    [HttpPut]
    public IActionResult UpdateStatus(int id)
    {
        _listManager.UpdateStatus(id);
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult DeleteItem(int id)
    {
        _listManager.DeleteItem(id);
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}