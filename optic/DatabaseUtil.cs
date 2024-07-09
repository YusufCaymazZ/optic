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
            this.connection.Open();        }
        catch (Exception ex)
        {
            MessageBox.Show($"Veritabanı bağlantısı sırasında bir hata oluştu: \n {ex.Message}");
        }
    }

    public void CloseConnection()
    {
        try
        {
            this.connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Veritabanı bağlantısını kapatırken bir hata oluştu: \n{ex.Message}");
        }
    }

    public MySqlConnection GetConnection()
    {
        return this.connection;
    }
}
