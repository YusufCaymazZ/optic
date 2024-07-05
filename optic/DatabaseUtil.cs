using System;
using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private MySqlConnection connection;

    public DatabaseConnection(string server = "127.0.0.1", string database = "optic", string user = "root", string password = "")
    {
        string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};";
        connection = new MySqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        try
        {
            connection.Open();
            Console.WriteLine("Veritabanı bağlantısı başarıyla kuruldu.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Veritabanı bağlantısı sırasında bir hata oluştu: {ex.Message}");
        }
    }

    public void CloseConnection()
    {
        try
        {
            connection.Close();
            Console.WriteLine("Veritabanı bağlantısı başarıyla kapatıldı.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Veritabanı bağlantısını kapatırken bir hata oluştu: {ex.Message}");
        }
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }
}
