namespace HttpContext_HttpRequest_HttpRespone.Helpers;

public static class RequestExtension
{
    public static string GetDebugIf(this HttpRequest request)
    {
        return $"{request.Scheme}://{request.Host}";
    }
}