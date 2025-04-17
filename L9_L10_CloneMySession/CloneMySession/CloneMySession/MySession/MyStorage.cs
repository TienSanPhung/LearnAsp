namespace CloneMySession.MySession;

public class MyStorage : ISessionStorage
{
    private readonly IStorageEngine engine;
    private readonly Dictionary<string,ISession> sessions = new Dictionary<string, ISession>();

    public MyStorage(IStorageEngine engine)
    {
        this.engine = engine;
    }

    public ISession Create()
    {
        var newSession =  new MySession(Guid.NewGuid().ToString("N"), engine);
        sessions[newSession.Id] = newSession;
        return newSession;
    }

    public ISession Get(string id)
    {
        if (sessions.ContainsKey(id))
        {
            return sessions[id];
        }

        return Create();
    }
}