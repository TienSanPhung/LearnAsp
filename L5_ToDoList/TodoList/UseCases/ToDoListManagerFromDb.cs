using Entity;

namespace UseCases;

public class ToDoListManagerFromDb
{
    private readonly IToDoItemFromDbRepository _repository;

    public ToDoListManagerFromDb(IToDoItemFromDbRepository repository)
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