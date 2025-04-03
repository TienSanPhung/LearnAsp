namespace CoAcAtRo.Services;

public class User : IUser
{
    private readonly List<string> _user = [];

    public void RemoveUser(string name)
    {
        if (_user.Contains(name))
        {
            _user.Remove(name);
        }
        
    }

    public IEnumerable<string> Users => _user;
    public void AddUser(string name)
    {
        _user.Add(name);
    }
}