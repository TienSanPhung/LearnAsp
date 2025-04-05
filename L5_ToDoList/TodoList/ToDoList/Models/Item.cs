namespace ToDoList.Models;

public class Item
{
    public int Id { get; set; }
    public required string Description { get; set; } = string.Empty;
    public bool Status { get; set; }
}