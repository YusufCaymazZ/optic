using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace optic
{
    public partial class DersKodlarınıEkle : Form
    {
        DatabaseConnection db;
        DataCrud data;
        
        public DersKodlarınıEkle(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
            PopulateComboBox(dKoduCombo);
            PopulateCevaplar(cevapCombo);
            PopulateKitapcik(kitapcikCombo);
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            // ComboBox değerlerini al
            string kitapcik = kitapcikCombo.Text;
            string cevap = cevapCombo.Text;
            string dersKodu = dKoduCombo.Text;

            // Cevap türünün son rakamını belirle
            if (string.IsNullOrEmpty(cevap) || cevap.Length < 6) // örn. "cevap1"
            {
                MessageBox.Show("Cevap seçiminizi kontrol edin.");
                return;
            }

            string dersNumarasi = cevap.Substring(cevap.Length - 1); // cevap1, cevap2, ... -> 1, 2, ...

            // DatabaseConnection sınıfından bir örnek oluştur
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                // Veritabanı bağlantısını aç
                dbConnection.OpenConnection();

                // Veritabanında güncelleme yapacak sorgu
                string updateQuery = $@"
            UPDATE optictxt
            SET ders{dersNumarasi} = @dersKodu
            WHERE kitapcik = @kitapcik AND
                  cevap{dersNumarasi} IS NOT NULL";

                using (var cmd = new MySqlCommand(updateQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@dersKodu", dersKodu);
                    cmd.Parameters.AddWithValue("@kitapcik", kitapcik);

                    // Sorguyu çalıştır
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek veri bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: \n{ex.Message}");
            }
            finally
            {
                // Veritabanı bağlantısını kapat
                dbConnection.CloseConnection();
            }
        }

        public void PopulateComboBox(ComboBox comboBox)
        {
            List<string> ders_kodlari = data.GetDersKoduData();
            comboBox.Items.Clear();
            foreach (var value in ders_kodlari)
            {
                comboBox.Items.Add(value);
            }
        }

        public void PopulateCevaplar(ComboBox comboBox)
        {
            List<string> cevaplar = new List<string>();
            cevaplar.Add("cevap1");
            cevaplar.Add("cevap2");
            cevaplar.Add("cevap3");
            cevaplar.Add("cevap4");
            cevaplar.Add("cevap5");
            cevaplar.Add("cevap6");

            foreach (var value in cevaplar)
            {
                comboBox.Items.Add(value);
            }
        }

        public void PopulateKitapcik(ComboBox comboBox)
        {
            List<string> kitapcik = new List<string>();
            kitapcik.Add("A");
            kitapcik.Add("B");
            foreach (var value in kitapcik)
            {
                comboBox.Items.Add(value);
            }
        }
    }
}
