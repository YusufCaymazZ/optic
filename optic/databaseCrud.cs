using System;
using MySql.Data.MySqlClient;

public class UserRepository
{
    private DatabaseConnection dbConnection;

    public UserRepository(DatabaseConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }

    public void AddUser(string name)
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Users (Name) VALUES (@name)", dbConnection.GetConnection());
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Kullanıcı başarıyla eklendi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kullanıcı ekleme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public void GetAllUsers()
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Users", dbConnection.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kullanıcıları getirirken bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    // UpdateUser ve DeleteUser yöntemlerini ekleyebilirsiniz
}
