using Entity;
using UseCases;

namespace Infracstructure;

public class InMemoryToDoItemsRepositoy : IToDoItemRepository
{
    private readonly List<ToDoItem> _item;
    public InMemoryToDoItemsRepositoy()
    {
        _item = [];
    }

    public IEnumerable<ToDoItem> GetItems()
    {
        return _item;
    }

    public ToDoItem? GetById(int id)
    {
        return _item.FirstOrDefault(i => i.Id == id);
    }

    public void Add(ToDoItem item)
    {
        _item.Add(item);
    }

    public void Update(ToDoItem item)
    {
        var existItem = _item.FirstOrDefault(i => i.Id == item.Id);
        if (existItem != null)
        {
            existItem.Description = item.Description;
            existItem.Status = item.Status;
        }
    }

    public void Delete(int id)
    {
        var item = _item.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _item.Remove(item);
        }
        
    }
}