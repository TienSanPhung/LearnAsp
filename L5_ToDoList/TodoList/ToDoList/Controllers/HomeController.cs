using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ToDoListManager _listManager;
    

    public HomeController(ToDoListManager listManager,ILogger<HomeController> logger)
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
        var currentID = _listManager.GetListItems().Count();
        _listManager.AddItems(new ToDoItem()
        {
            Id = currentID ++,
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