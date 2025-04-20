namespace CloneMySession.MySession;

public static class MySessionRegistrationExtensions
{
    public static IServiceCollection AddMySession(this IServiceCollection services)
    {
        services.AddSingleton<IStorageEngine>(services =>
        {
            var path = Path.Combine(services.GetRequiredService<IHostEnvironment>().ContentRootPath, "Sessions");
            Directory.CreateDirectory(path);
            return new FileManagerSession(path);
        });
        services.AddSingleton<ISessionStorage, MyStorage>();
        services.AddScoped<MySessionScopedContainer>();
        return services;
    }
}