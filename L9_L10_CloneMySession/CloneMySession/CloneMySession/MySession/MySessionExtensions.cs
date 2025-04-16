namespace CloneMySession.MySession;

public static class MySessionExtensions
{
    public static ISession GetSession(this HttpContext context)
    {
        return context.Session;
    }
}