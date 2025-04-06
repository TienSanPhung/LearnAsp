﻿using Entity;

namespace UseCases;

public interface IToDoItemFromDbRepository
{
    IEnumerable<ToDoItem> GetItems();
    ToDoItem? GetById(int id);
    void Add(ToDoItem item);
    void Update(ToDoItem item);
    void Delete(int id);
}