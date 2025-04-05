using Entity;
using Infracstructure;
using ToDoList;
using UseCases;
namespace TestProject;

public class UnitTest1
{
    [Fact]
    public void CreateToDoItem_and_Set_Status_Test()
    {
        // Arrange
        var mockListManager = new InMemoryToDoItemsRepositoy();
        var listManager = new ToDoListManager(mockListManager);
        var todoitem = new ToDoItem(){Id = 1 ,Description = "Test unit project",Status = false};
         // Act
        listManager.AddItems(todoitem);
        listManager.UpdateStatus(1);
        // Assert
        Assert.True(listManager.GetListItems().First().Status);
        Assert.Equal("Test unit project",listManager.GetListItems().First().Description);
    }
    [Fact]
    public void DeleteToDoItem_Test()
    {
        // Arrange
        var mockListManager = new InMemoryToDoItemsRepositoy();
        var listManager = new ToDoListManager(mockListManager);
        var todoitem = new ToDoItem(){Id = 1 ,Description = "Test unit project",Status = false};
        // Act
        listManager.AddItems(todoitem);
        listManager.DeleteItem(1);
        // Assert
        Assert.Empty(listManager.GetListItems());
    }
}