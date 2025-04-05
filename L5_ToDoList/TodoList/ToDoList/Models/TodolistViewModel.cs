namespace ToDoList.Models;

public class TodolistViewModel
{
    public required IEnumerable<Item> Item { init; get; }
} 