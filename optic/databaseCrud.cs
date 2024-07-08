using System;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System.IO;
public class UserRepository
{
    private DatabaseConnection dbConnection;

    public UserRepository(DatabaseConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }
    //optic_txt tablosu
    public void AddTxt(string ogr_num,string ogr_isim, string ders1, string ders2, string ders3, string ders4, string ders5, string ders6,
        string cevap1, string cevap2, string cevap3, string cevap4, string cevap5, string cevap6, string oturum, string grup, string kitapcik, string durum)
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO optic_txt (ogr_num,ogr_isim,ders1,ders2,ders3,ders4,ders5,ders6, cevap1, cevap2, cevap3, cevap4, cevap5, cevap6" +
                $"oturum, grup, kitapcik, durum) VALUES (@ogr_num,@ogr_isim,@ders1,@ders2,@ders3,@ders4,@ders5,@ders6,@cevap1,@cevap1,@cevap1,@cevap1,@cevap1,@cevap1,@oturum,@grup,@kitapcik, @durum)", dbConnection.GetConnection());//SYNTAXI DÜZELT
            cmd.Parameters.AddWithValue("@ogr_num", ogr_num);
            cmd.Parameters.AddWithValue("@ogr_isim", ogr_isim);
            cmd.Parameters.AddWithValue("@ders1", ders1);
            cmd.Parameters.AddWithValue("@ders2", ders2);
            cmd.Parameters.AddWithValue("@ders3", ders3);
            cmd.Parameters.AddWithValue("@ders4", ders4);
            cmd.Parameters.AddWithValue("@ders5", ders5);
            cmd.Parameters.AddWithValue("@ders6", ders6);
            cmd.Parameters.AddWithValue("@cevap1", cevap1);
            cmd.Parameters.AddWithValue("@cevap2", cevap2);
            cmd.Parameters.AddWithValue("@cevap3", cevap3);
            cmd.Parameters.AddWithValue("@cevap4", cevap4);
            cmd.Parameters.AddWithValue("@cevap5", cevap5);
            cmd.Parameters.AddWithValue("@cevap6", cevap6);
            cmd.Parameters.AddWithValue("@oturum", oturum);
            cmd.Parameters.AddWithValue("@grup", grup);
            cmd.Parameters.AddWithValue("@kitapcik", kitapcik);
            cmd.Parameters.AddWithValue("@durum", durum);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı başarıyla eklendi.");
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
    //sonuclar tablosu
    public void AddSonuc(string ogr_num, string ogr_isim, string net, string puan, string cevap, string oturum, string grup, string ders_kodu, string girmedi)
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO sonuclar (ogr_num, ogr_isim, net, puan, cevap, oturum, grup, ders_kodu, girmedi) " +
                       "VALUES (@ogr_num, @ogr_isim, @net, @puan, @cevap, @oturum, @grup, @ders_kodu, @girmedi)", dbConnection.GetConnection());  //SYNTAXI DÜZELT                                                                                                                                      
            cmd.Parameters.AddWithValue("@ogr_num", ogr_num);
            cmd.Parameters.AddWithValue("@ogr_isim", ogr_isim);
            cmd.Parameters.AddWithValue("@net", net);
            cmd.Parameters.AddWithValue("@puan", puan);
            cmd.Parameters.AddWithValue("@cevap", cevap);
            cmd.Parameters.AddWithValue("@oturum", oturum);
            cmd.Parameters.AddWithValue("@grup", grup);
            cmd.Parameters.AddWithValue("@ders_kodu", ders_kodu);
            cmd.Parameters.AddWithValue("@girmedi", girmedi);
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

    //dersler tablosu
    public void AddDers(string ders_kod, string program, string ders)
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO dersler (ders_kod,program,ders) VALUES (@ders_kod,@program,@ders)", dbConnection.GetConnection());  //SYNTAXI DÜZELT
            cmd.Parameters.AddWithValue("@ders_kod", ders_kod);
            cmd.Parameters.AddWithValue("@program", program);
            cmd.Parameters.AddWithValue("@ders", ders);
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
    // ogr_list tablosu
    public void AddOgrList(string ders_kodu, string ogr_no, string ogr_isim)
    {
        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO ogr_list (ders_kodu,ogr_no,ogr_isim) VALUES (@ders_kodu,@ogr_no,@ogr_isim)", dbConnection.GetConnection());  //SYNTAXI DÜZELT
            cmd.Parameters.AddWithValue("@ders_kodu", ders_kodu);
            cmd.Parameters.AddWithValue("@ogr_no", ogr_no);
            cmd.Parameters.AddWithValue("@ogr_isim", ogr_isim);
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



    public void UpdateTxt(string ogr_num, string ogr_isim = null, string ders1 = null, string ders2 = null, string ders3 = null,
                      string ders4 = null, string ders5 = null, string ders6 = null, string cevap1 = null,
                      string cevap2 = null, string cevap3 = null, string cevap4 = null, string cevap5 = null,
                      string cevap6 = null, string oturum = null, string grup = null, string kitapcik = null,
                      string durum = null)
    {
        try
        {
            dbConnection.OpenConnection();

            // Dinamik olarak güncelleme sorgusunu oluşturuyoruz
            List<string> updates = new List<string>();
            MySqlCommand cmd = new MySqlCommand();

            // Belirtilen parametreleri güncellenen sütunlar listesine ekliyoruz
            AddUpdateParameter(cmd, updates, "@ogr_isim", "ogr_isim", ogr_isim);
            AddUpdateParameter(cmd, updates, "@ders1", "ders1", ders1);
            AddUpdateParameter(cmd, updates, "@ders2", "ders2", ders2);
            AddUpdateParameter(cmd, updates, "@ders3", "ders3", ders3);
            AddUpdateParameter(cmd, updates, "@ders4", "ders4", ders4);
            AddUpdateParameter(cmd, updates, "@ders5", "ders5", ders5);
            AddUpdateParameter(cmd, updates, "@ders6", "ders6", ders6);
            AddUpdateParameter(cmd, updates, "@cevap1", "cevap1", cevap1);
            AddUpdateParameter(cmd, updates, "@cevap2", "cevap2", cevap2);
            AddUpdateParameter(cmd, updates, "@cevap3", "cevap3", cevap3);
            AddUpdateParameter(cmd, updates, "@cevap4", "cevap4", cevap4);
            AddUpdateParameter(cmd, updates, "@cevap5", "cevap5", cevap5);
            AddUpdateParameter(cmd, updates, "@cevap6", "cevap6", cevap6);
            AddUpdateParameter(cmd, updates, "@oturum", "oturum", oturum);
            AddUpdateParameter(cmd, updates, "@grup", "grup", grup);
            AddUpdateParameter(cmd, updates, "@kitapcik", "kitapcik", kitapcik);
            AddUpdateParameter(cmd, updates, "@durum", "durum", durum);

            if (updates.Count == 0)
            {
                throw new ArgumentException("En az bir alan güncellenmelidir.");
            }

            string query = "UPDATE optic_txt SET " + string.Join(", ", updates) + " WHERE ogr_num = @ogr_num";
            cmd.CommandText = query;
            cmd.Connection = dbConnection.GetConnection();

            cmd.Parameters.AddWithValue("@ogr_num", ogr_num);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Kullanıcı bilgilerini güncelleme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    private void AddUpdateParameter(MySqlCommand cmd, List<string> updates, string parameterName, string columnName, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            updates.Add($"{columnName} = {parameterName}");
            cmd.Parameters.AddWithValue(parameterName, value);
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
