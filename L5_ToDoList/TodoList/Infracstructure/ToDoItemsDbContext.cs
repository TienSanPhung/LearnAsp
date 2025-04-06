namespace Infracstructure;
using Microsoft.EntityFrameworkCore;
using Entity;

public class ToDoItemsDbContext : DbContext
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public ToDoItemsDbContext(DbContextOptions<ToDoItemsDbContext> options)
        : base(options)
    {
    }
    public DbSet<ToDoItem> ToDoItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ToDoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 0, increment: 1); // Tự động tăng từ 0, tăng mỗi lần 1
              
            // Cấu hình các thuộc tính khác nếu cần
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);
            entity.Property(e => e.Status)
                .HasDefaultValue(false);
        });
    }
}