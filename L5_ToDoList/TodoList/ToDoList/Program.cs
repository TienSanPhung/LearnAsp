using Microsoft.EntityFrameworkCore;

namespace ToDoList;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ToDoItemsDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("TodoDbConnection");
            options.UseSqlServer(connectionString);
        });
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IToDoItemRepository,InMemoryToDoItemsRepositoy>();
        builder.Services.AddScoped<IToDoItemFromDbRepository,InDbToDoItemsRepository>();
        builder.Services.AddTransient<ToDoListManager>();
        builder.Services.AddTransient<ToDoListManagerFromDb>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}