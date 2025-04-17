namespace CloneMySession.MySession;

public static class MySessionExtensions
{
    private const string SessionIdCookieName = "MY_SESSION_ID";
    public static ISession GetSession(this HttpContext context)
    {
        var SessionId = context.Request.Cookies[SessionIdCookieName];
        if (SessionIdFormatValid(SessionId))
        {
          var session = context.RequestServices.GetRequiredService<ISessionStorage>().Get(SessionId);
          context.Response.Cookies.Append(SessionIdCookieName, session.Id);
          return session;
        }
        else
        {
            var session = context.RequestServices.GetRequiredService<ISessionStorage>().Create();
            context.Response.Cookies.Append(SessionIdCookieName, session.Id);
            return session;
        }

    }

    private static bool SessionIdFormatValid(string? sessionId)
    {
        return !string.IsNullOrEmpty(sessionId) && Guid.TryParse(sessionId, out var _);
    }
}