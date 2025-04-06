using Entity;
using Microsoft.EntityFrameworkCore;
using UseCases;

namespace Infracstructure;

public class InDbToDoItemsRepository : IToDoItemFromDbRepository
{
    private readonly ToDoItemsDbContext _dbcontext;

    public InDbToDoItemsRepository(ToDoItemsDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public  IEnumerable<ToDoItem> GetItems()
    {
        return _dbcontext.ToDoItems.AsNoTracking();
    }

    public ToDoItem? GetById(int id)
    {
        return _dbcontext.ToDoItems.Find(id);
    }

    public void Add(ToDoItem item)
    {
        _dbcontext.ToDoItems.Add(item);
        _dbcontext.SaveChanges();
    }

    public void Update(ToDoItem item)
    {
        var i = _dbcontext.ToDoItems.Find(item.Id);
        if (i != null)
        {
            i.Description = item.Description;
            i.Status = item.Status;
            _dbcontext.ToDoItems.Update(i);
            _dbcontext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var i = _dbcontext.ToDoItems.Find(id);
        if (i != null)
        {
            _dbcontext.ToDoItems.Remove(i);
            _dbcontext.SaveChanges();
        }
    }
}