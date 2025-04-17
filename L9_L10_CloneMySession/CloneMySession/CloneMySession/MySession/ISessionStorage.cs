namespace CloneMySession.MySession;

public interface ISessionStorage
{
    ISession Create();
    ISession Get(string id);
}