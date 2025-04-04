using Entity;

namespace UseCases;

public class ToDoListManager 
{
    private readonly IToDoItemRepository _repository;

    public ToDoListManager(IToDoItemRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ToDoItem> GetListItems()
    {
        return _repository.GetItems();
    }

    public void AddItems(ToDoItem item)
    {
         _repository.Add(item);
    }

    public void UpdateStatus(int id)
    {
        var item = _repository.GetById(id);
        if (item != null)
        {
            item.Status = true;
            _repository.Update(item);
        }
    }
    public void DeleteItem(int id)
    {
        var item = _repository.GetById(id);
        if (item != null)
        {
            _repository.Delete(id);
        }
    }
    
}