﻿using MySql.Data.MySqlClient;
using optic;
using System.Data;

public class DataCrud
{
    private DatabaseConnection dbConnection;
    
    public DataCrud(DatabaseConnection dbConnection)
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
            string query = $"INSERT INTO optictxt (ogr_num, ogr_isim, ders1, ders2, ders3, ders4, ders5, ders6, cevap1, cevap2, cevap3, cevap4, cevap5, cevap6, oturum, grup, kitapcik, durum) " +
               $"VALUES (@ogr_num, @ogr_isim, @ders1, @ders2, @ders3, @ders4, @ders5, @ders6, @cevap1, @cevap2, @cevap3, @cevap4, @cevap5, @cevap6, @oturum, @grup, @kitapcik, @durum)";


            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT
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
            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Kullanıcı ekleme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }
    //opticTur Tablosu
    public void AddOptic(string opticTur, int ogrNumBas=0, int ogrNumBit = 0, int ogrAdBas = 0, int ogrAdBit = 0,
    int d1Bas = 0, int d1Bit = 0, int d2Bas = 0, int d2Bit = 0, int d3Bas = 0, int d3Bit = 0, int d4Bas = 0, int d4Bit = 0,
    int d5Bas = 0, int d5Bit = 0, int d6Bas = 0, int d6Bit = 0, int c1Bas = 0, int c1Bit = 0, int c2Bas = 0, int c2Bit = 0,
    int c3Bas = 0, int c3Bit = 0, int c4Bas = 0, int c4Bit = 0, int c5Bas = 0, int c5Bit = 0, int c6Bas = 0, int c6Bit = 0,
    int oturumBas = 0, int oturumBit = 0, int grupBas = 0, int grupBit = 0, int kitapcikBas = 0, int kitapcikBit = 0,
    int durumBas = 0, int durumBit = 0)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = $"INSERT INTO optictur (opticTur, ogrNumBas, ogrNumBit, ogrAdBas, ogrAdBit, " +
                $"d1Bas, d1Bit, d2Bas, d2Bit, d3Bas, d3Bit, d4Bas, d4Bit, d5Bas, d5Bit, d6Bas, d6Bit, " +
                $"c1Bas, c1Bit, c2Bas, c2Bit, c3Bas, c3Bit, c4Bas, c4Bit, c5Bas, c5Bit, c6Bas, c6Bit, " +
                $"oturumBas, oturumBit, grupBas, grupBit, kitapcikBas, kitapcikBit, durumBas, durumBit) " +
                $"VALUES (@opticTur, @ogrNumBas, @ogrNumBit, @ogrAdBas, @ogrAdBit, @d1Bas, @d1Bit, @d2Bas, @d2Bit, @d3Bas, @d3Bit, " +
                $"@d4Bas, @d4Bit, @d5Bas, @d5Bit, @d6Bas, @d6Bit, @c1Bas, @c1Bit, @c2Bas, @c2Bit, @c3Bas, @c3Bit, @c4Bas, @c4Bit, " +
                $"@c5Bas, @c5Bit, @c6Bas, @c6Bit, @oturumBas, @oturumBit, @grupBas, @grupBit, @kitapcikBas, @kitapcikBit, @durumBas, @durumBit)";

            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            cmd.Parameters.AddWithValue("@opticTur", opticTur);
            cmd.Parameters.AddWithValue("@ogrNumBas", ogrNumBas);
            cmd.Parameters.AddWithValue("@ogrNumBit", ogrNumBit);
            cmd.Parameters.AddWithValue("@ogrAdBas", ogrAdBas);
            cmd.Parameters.AddWithValue("@ogrAdBit", ogrAdBit);
            cmd.Parameters.AddWithValue("@d1Bas", d1Bas);
            cmd.Parameters.AddWithValue("@d1Bit", d1Bit);
            cmd.Parameters.AddWithValue("@d2Bas", d2Bas);
            cmd.Parameters.AddWithValue("@d2Bit", d2Bit);
            cmd.Parameters.AddWithValue("@d3Bas", d3Bas);
            cmd.Parameters.AddWithValue("@d3Bit", d3Bit);
            cmd.Parameters.AddWithValue("@d4Bas", d4Bas);
            cmd.Parameters.AddWithValue("@d4Bit", d4Bit);
            cmd.Parameters.AddWithValue("@d5Bas", d5Bas);
            cmd.Parameters.AddWithValue("@d5Bit", d5Bit);
            cmd.Parameters.AddWithValue("@d6Bas", d6Bas);
            cmd.Parameters.AddWithValue("@d6Bit", d6Bit);
            cmd.Parameters.AddWithValue("@c1Bas", c1Bas);
            cmd.Parameters.AddWithValue("@c1Bit", c1Bit);
            cmd.Parameters.AddWithValue("@c2Bas", c2Bas);
            cmd.Parameters.AddWithValue("@c2Bit", c2Bit);
            cmd.Parameters.AddWithValue("@c3Bas", c3Bas);
            cmd.Parameters.AddWithValue("@c3Bit", c3Bit);
            cmd.Parameters.AddWithValue("@c4Bas", c4Bas);
            cmd.Parameters.AddWithValue("@c4Bit", c4Bit);
            cmd.Parameters.AddWithValue("@c5Bas", c5Bas);
            cmd.Parameters.AddWithValue("@c5Bit", c5Bit);
            cmd.Parameters.AddWithValue("@c6Bas", c6Bas);
            cmd.Parameters.AddWithValue("@c6Bit", c6Bit);
            cmd.Parameters.AddWithValue("@oturumBas", oturumBas);
            cmd.Parameters.AddWithValue("@oturumBit", oturumBit);
            cmd.Parameters.AddWithValue("@grupBas", grupBas);
            cmd.Parameters.AddWithValue("@grupBit", grupBit);
            cmd.Parameters.AddWithValue("@kitapcikBas", kitapcikBas);
            cmd.Parameters.AddWithValue("@kitapcikBit", kitapcikBit);
            cmd.Parameters.AddWithValue("@durumBas", durumBas);
            cmd.Parameters.AddWithValue("@durumBit", durumBit);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Optik kaydı ekleme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    //sonuclar tablosu
    public void AddSonuc(string ogr_num, string ogr_isim, string net, string puan, string cevap, string oturum, 
        string grup, string ders_kodu, string girmedi)
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

            string query = "UPDATE optictxt SET " + string.Join(", ", updates) + " WHERE ogr_num = @ogr_num";
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






    public List<string> GetAllStuds()
    {
        List<string> data = new List<string>();

        try
        {
            dbConnection.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM optictxt WHERE " +
                " ogr_num IN (SELECT ogr_num FROM optictxt GROUP BY ogr_num HAVING COUNT(*) > 1);", dbConnection.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 1; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        data.Add(reader.GetString(i));
                    }
                    else
                    {
                        data.Add(string.Empty); // Null değerler yerine boş string ekleniyor
                    }
                }
            }
            reader.Close();
        }
        catch (Exception ex)
        {   
            MessageBox.Show($"Kullanıcıları getirirken bir hata oluştu: {ex.Message}");
        }
        finally
        {   
            dbConnection.CloseConnection( );
        }

        return data;
    }

    public List<int> GetIntColumns(string opticTur)
    {
        List<int> results = new List<int>();
        try
        {
            dbConnection.OpenConnection();
            // Burada int sütunları manuel olarak belirtiyoruz.
            string query = "SELECT ogrNumBas, ogrNumBit, ogrAdBas, ogrAdBit, d1Bas, d1Bit, d2Bas, " +
                "d2Bit, d3Bas, d3Bit, d4Bas, d4Bit, d5Bas, d5Bit, d6Bas, d6Bit, c1Bas, c1Bit, c2Bas, " +
                "c2Bit, c3Bas, c3Bit, c4Bas, c4Bit, c5Bas, c5Bit, c6Bas, c6Bit, oturumBas, oturumBit, " +
                "grupBas, grupBit, kitapcikBas, kitapcikBit, durumBas, durumBit " +
                "FROM optictur WHERE opticTur = @opticTur";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            cmd.Parameters.AddWithValue("@opticTur", opticTur);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(reader.GetInt32("ogrNumBas"));
                results.Add(reader.GetInt32("ogrNumBit"));
                results.Add(reader.GetInt32("ogrAdBas"));
                results.Add(reader.GetInt32("ogrAdBit"));
                results.Add(reader.GetInt32("d1Bas"));
                results.Add(reader.GetInt32("d1Bit"));
                results.Add(reader.GetInt32("d2Bas"));
                results.Add(reader.GetInt32("d2Bit"));
                results.Add(reader.GetInt32("d3Bas"));
                results.Add(reader.GetInt32("d3Bit"));
                results.Add(reader.GetInt32("d4Bas"));
                results.Add(reader.GetInt32("d4Bit"));
                results.Add(reader.GetInt32("d5Bas"));
                results.Add(reader.GetInt32("d5Bit"));
                results.Add(reader.GetInt32("d6Bas"));
                results.Add(reader.GetInt32("d6Bit"));
                results.Add(reader.GetInt32("c1Bas"));
                results.Add(reader.GetInt32("c1Bit"));
                results.Add(reader.GetInt32("c2Bas"));
                results.Add(reader.GetInt32("c2Bit"));
                results.Add(reader.GetInt32("c3Bas"));
                results.Add(reader.GetInt32("c3Bit"));
                results.Add(reader.GetInt32("c4Bas"));
                results.Add(reader.GetInt32("c4Bit"));
                results.Add(reader.GetInt32("c5Bas"));
                results.Add(reader.GetInt32("c5Bit"));
                results.Add(reader.GetInt32("c6Bas"));
                results.Add(reader.GetInt32("c6Bit"));
                results.Add(reader.GetInt32("oturumBas"));
                results.Add(reader.GetInt32("oturumBit"));
                results.Add(reader.GetInt32("grupBas"));
                results.Add(reader.GetInt32("grupBit"));
                results.Add(reader.GetInt32("kitapcikBas"));
                results.Add(reader.GetInt32("kitapcikBit"));
                results.Add(reader.GetInt32("durumBas"));
                results.Add(reader.GetInt32("durumBit"));
            }
            reader.Close();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Veri çekme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
        return results;
    }


    public List<string> GetOpticTurValues()
    {
        List<string> opticTurValues = new List<string>();
        try
        {
            dbConnection.OpenConnection();
            string query = "SELECT opticTur FROM optictur";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                opticTurValues.Add(reader["opticTur"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
        return opticTurValues;
    }

    public void InsertDataIntoDatabase(DataTable dataTable)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = @"
                INSERT INTO ogrlist ( ogr_no, ogr_isim, ogr_soyad)
                VALUES (@ogr_no, @ogr_isim, @ogr_soyad)
                ON DUPLICATE KEY UPDATE
                ogr_isim = VALUES(ogr_isim),
                ogr_soyad = VALUES(ogr_soyad)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT
           

            foreach (DataRow row in dataTable.Rows)
            {
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ogr_no", row["ogrno"]);
                    cmd.Parameters.AddWithValue("@ogr_isim", row["ogrisim"]);
                    cmd.Parameters.AddWithValue("@ogr_soyad", row["ogrsoyad"]);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Veriler başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dbConnection.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void DeleteRecordsByCourseCode(string dersKodu)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = "DELETE FROM ogrlist WHERE ders_kodu = @ders_kodu";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT
            cmd.Parameters.AddWithValue("@ders_kodu", dersKodu);
            int affectedRows = cmd.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                MessageBox.Show($"{affectedRows} kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Belirtilen ders koduna ait kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dbConnection.CloseConnection();


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            throw;
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public DataTable GetogrListDataGrid()
    {
        string query = "SELECT * FROM ogrlist"; // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin

        DataTable dataTable = new DataTable();

        try
        {
            dbConnection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    // Verileri DataTable'a doldurun
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dataTable;
    }

    public DataTable GetOneOgrListDataGrid(String num)
    {
        string query = $"SELECT * FROM ogrlist WHERE ogr_no={num}"; // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin

        DataTable dataTable = new DataTable();

        try
        {
            dbConnection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    // Verileri DataTable'a doldurun
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dataTable;
    }



    public void InsertOrUpdateCourse(DataTable dataTable)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = @"
                INSERT INTO dersler (dersKod, program, ders )
                VALUES (@derskodu, @programadi, @dersadi)
                ON DUPLICATE KEY UPDATE
                dersKod = VALUES(dersKod),
                program = VALUES(program),
                ders = VALUES(ders)";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT

            foreach (DataRow row in dataTable.Rows)
            {
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@derskodu", row["ogrno"]);
                    cmd.Parameters.AddWithValue("@programadi", row["ogrisim"]);
                    cmd.Parameters.AddWithValue("@dersadi", row["ogrsoyad"]);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Veriler başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dbConnection.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public void DeleteCourseByCourseCode(string dersKodu)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = "DELETE FROM dersler WHERE dersKod = @ders_kodu";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT
            cmd.Parameters.AddWithValue("@ders_kodu", dersKodu);
            int affectedRows = cmd.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                MessageBox.Show($"{affectedRows} kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Belirtilen ders koduna ait kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dbConnection.CloseConnection();


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            throw;
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }


    public DataTable GetOneDersDataGrid(String num)
    {
        string query = $"SELECT * FROM dersler WHERE dersKod={num}"; // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin

        DataTable dataTable = new DataTable();

        try
        {
            dbConnection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    // Verileri DataTable'a doldurun
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dataTable;
    }

    public DataTable GetdersListDataGrid()
    {
        string query = "SELECT * FROM dersler"; // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin

        DataTable dataTable = new DataTable();

        try
        {
            dbConnection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    // Verileri DataTable'a doldurun
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dataTable;
    }

    public void AddOneOgr(string ogrNum, string ogrAd, string ogrsoyad)
    {
        dbConnection.OpenConnection();
        string query = @"
                INSERT INTO ogrlist ( ogr_no, ogr_isim, ogr_soyad)
                VALUES ( @ogr_no, @ogr_isim, @ogr_soyad)
                ON DUPLICATE KEY UPDATE
                ogr_isim = VALUES(ogr_isim),
                ogr_soyad = VALUES(ogr_soyad)";
        MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()); // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin
        try
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ogr_no", ogrNum);
            cmd.Parameters.AddWithValue("@ogr_isim", ogrAd);
            cmd.Parameters.AddWithValue("@ogr_soyad", ogrsoyad);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

    }

    public void UpdateOneTxt(string eskiOgrNum, string newOgrNum = null, string newOgrIsim = null,
                      string ders1 = null, string ders2 = null, string ders3 = null,
                      string ders4 = null, string ders5 = null, string ders6 = null,
                      string cevap1 = null, string cevap2 = null, string cevap3 = null,
                      string cevap4 = null, string cevap5 = null, string cevap6 = null,
                      string oturum = null, string grup = null, string kitapcik = null,
                      string durum = null)
    {
        try
        {
            dbConnection.OpenConnection();

            // Dinamik olarak güncelleme sorgusunu oluşturuyoruz
            List<string> updates = new List<string>();
            MySqlCommand cmd = new MySqlCommand();

            // Belirtilen parametreleri güncellenen sütunlar listesine ekliyoruz
            AddUpdateParameter(cmd, updates, "@newOgrNum", "ogr_num", newOgrNum);
            AddUpdateParameter(cmd, updates, "@newOgrIsim", "ogr_isim", newOgrIsim);
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

            // Güncelleme sorgusu
            string query = "UPDATE optictxt SET " + string.Join(", ", updates) + " WHERE ogr_num = @eskiOgrNum";
            cmd.CommandText = query;
            cmd.Connection = dbConnection.GetConnection();

            // Eski öğrenci numarasını parametre olarak ekliyoruz
            cmd.Parameters.AddWithValue("@eskiOgrNum", eskiOgrNum);

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


    public Student GetStudentByOgrNum(string eskiOgrNum)
    {
        Student student = null;

        try
        {
            dbConnection.OpenConnection();
            string query = "SELECT * FROM optictxt WHERE ogr_num = @eskiOgrNum";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            cmd.Parameters.AddWithValue("@eskiOgrNum", eskiOgrNum);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    student = new Student
                    {
                        OgrNum = reader["ogr_num"].ToString(),
                        OgrIsim = reader["ogr_isim"].ToString(),
                        Ders1 = reader["ders1"].ToString(),
                        Ders2 = reader["ders2"].ToString(),
                        Ders3 = reader["ders3"].ToString(),
                        Ders4 = reader["ders4"].ToString(),
                        Ders5 = reader["ders5"].ToString(),
                        Ders6 = reader["ders6"].ToString(),
                        Cevap1 = reader["cevap1"].ToString(),
                        Cevap2 = reader["cevap2"].ToString(),
                        Cevap3 = reader["cevap3"].ToString(),
                        Cevap4 = reader["cevap4"].ToString(),
                        Cevap5 = reader["cevap5"].ToString(),
                        Cevap6 = reader["cevap6"].ToString(),
                        Oturum = reader["oturum"].ToString(),
                        Grup = reader["grup"].ToString(),
                        Kitapcik = reader["kitapcik"].ToString(),
                        Durum = reader["durum"].ToString()
                    };
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Öğrenci bilgilerini getirirken bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return student;
    }


    public void InsertAnsIntoDatabase(DataTable dataTable)
    {
        try
        {
            dbConnection.OpenConnection();
            string query = @"
                INSERT INTO cevapanahtarı (ders_kodu, ders_adi, cevap, kitapcik)
                VALUES (@ders_kodu, @ders_adi, @cevap, @kitapcik)
                ON DUPLICATE KEY UPDATE
                ders_kodu = VALUES(ders_kodu),
                ders_adi = VALUES(ders_adi),
                kitapcik = VALUES(kitapcik)
                ";
            //kitapcik = VALUES(kitapcik)
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());//SYNTAXI DÜZELT

            foreach (DataRow row in dataTable.Rows)
            {
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ders_kodu", row["ders_kodu"]);
                    cmd.Parameters.AddWithValue("@ders_adi", row["ders_adi"]);
                    cmd.Parameters.AddWithValue("@cevap", row["cevap"].ToString().ToUpper());
                    if(dataTable.Columns.Count>3)
                    {
                        cmd.Parameters.AddWithValue("@kitapcik", row["kitapcik".ToString().ToUpper()]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@kitapcik", null);
                    }
                    
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Veriler başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dbConnection.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetCevapListDataGrid()
    {
        string query = "SELECT * FROM cevapanahtarı"; // Tablo adı veya sorguyu ihtiyacınıza göre değiştirin

        DataTable dataTable = new DataTable();

        try
        {
            dbConnection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    // Verileri DataTable'a doldurun
                    adapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda Exception fırlat
            throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }

        return dataTable;
    }

    public List<String> GetDersKoduData()
    {
        List<string> ders_kodu = new List<string>();
        try
        {
            dbConnection.OpenConnection();
            string query = "SELECT ders_kodu FROM cevapanahtarı";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ders_kodu.Add(reader["ders_kodu"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Veri çekme sırasında bir hata oluştu: {ex.Message}");
        }
        finally
        {
            dbConnection.CloseConnection();
        }
        return ders_kodu;
    }

    public void GuncelleOgrIsimleri()
    {
        try
        {

            // ogrlist tablosundan öğrenci numarası, isim ve soyisim bilgilerini al
            string query = "SELECT ogr_no, ogr_isim, ogr_soyad FROM ogrlist";
            DataTable ogrListTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection()))
            {
                adapter.Fill(ogrListTable);
            }

            // Her öğrenci için isim ve soyisim bilgilerini güncelle
            foreach (DataRow row in ogrListTable.Rows)
            {
                string ogrNo = row["ogr_no"].ToString();
                string ogrIsim = row["ogr_isim"].ToString();
                string ogrSoyad = row["ogr_soyad"].ToString();
                string tamIsim = $"{ogrIsim} {ogrSoyad}";

                // ogrenci_sonuclari tablosunda ogr_isim sütununu güncelle
                string updateOgrenciSonuclariQuery = @"
                UPDATE ogrenci_sonuclari 
                SET ogr_isim = @tamIsim 
                WHERE ogr_num = @ogrNo";

                using (MySqlCommand cmd = new MySqlCommand(updateOgrenciSonuclariQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@tamIsim", tamIsim);
                    cmd.Parameters.AddWithValue("@ogrNo", ogrNo);
                    cmd.ExecuteNonQuery();
                }

                // optictxt tablosunda ogr_isim sütununu güncelle
                string updateOpticTxtQuery = @"
                UPDATE optictxt 
                SET ogr_isim = @tamIsim 
                WHERE ogr_num = @ogrNo";

                using (MySqlCommand cmd = new MySqlCommand(updateOpticTxtQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@tamIsim", tamIsim);
                    cmd.Parameters.AddWithValue("@ogrNo", ogrNo);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Öğrenci isimleri başarıyla güncellendi.");
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("MySQL Hatası: " + ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Genel Hata: " + ex.Message);
        }
        finally
        {
            dbConnection.CloseConnection();
        }
    }

    public void updateCourse(string dersKodu, string prgram, string ders)
    {
        try
        {
            // Veritabanı bağlantısını aç
            dbConnection.OpenConnection();

            // Önce veri var mı kontrol et
            string checkQuery = "SELECT COUNT(*) FROM dersler WHERE dersKod = @dersKod";
            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, dbConnection.GetConnection()))
            {
                checkCmd.Parameters.AddWithValue("@dersKod", dersKodu);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                // Eğer veri yoksa ekle
                if (count == 0)
                {
                    string insertQuery = @"
                    INSERT INTO dersler (dersKod, program, ders) 
                    VALUES (@dersKod, @program, @dersAdi)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, dbConnection.GetConnection()))
                    {
                        // Parametreleri ekle
                        insertCmd.Parameters.AddWithValue("@dersKod", dersKodu);
                        insertCmd.Parameters.AddWithValue("@program", prgram);
                        insertCmd.Parameters.AddWithValue("@dersAdi", ders);

                        // Sorguyu çalıştır
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ders başarıyla eklendi.");
                }
                else
                {
                    MessageBox.Show("Bu ders zaten mevcut.");
                }
            }
        }
        catch (MySqlException ex)
        {
            // MySQL hatalarını yakala
            MessageBox.Show("MySQL Hatası: " + ex.Message);
            if (ex.InnerException != null)
            {
                MessageBox.Show("İç Hata: " + ex.InnerException.Message);
            }
        }
        catch (Exception ex)
        {
            // Diğer hataları yakala
            MessageBox.Show("Genel Hata: " + ex.Message);
            if (ex.InnerException != null)
            {
                MessageBox.Show("İç Hata: " + ex.InnerException.Message);
            }
        }
        finally
        {
            // Bağlantıyı kapat
            dbConnection.CloseConnection();
        }
    }






















    // UpdateUser ve DeleteUser yöntemlerini ekleyebilirsiniz
}
