﻿namespace Entity;

public class ToDoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Status { get; set; }
}