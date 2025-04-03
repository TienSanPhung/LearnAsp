namespace CoAcAtRo.Services;

public interface IUser
{
    void AddUser(string name);
    void RemoveUser(string name);
    IEnumerable<string> Users { get; }
}