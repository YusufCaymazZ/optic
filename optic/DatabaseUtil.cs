using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=optic;User=root;Password=;",
                ServerVersion.AutoDetect("Server=127.0.0.1;Database=optic;User=root;Password=;"));
            Console.WriteLine("Veritabanı bağlantısı başarıyla kuruldu.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Veritabanı bağlantısı sırasında bir hata oluştu: {ex.Message}");
        }

    }
}


public class User { 
    public int Id { get; set; }
    public string Name { get; set; }
}
