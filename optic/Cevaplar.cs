using ExcelDataReader;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Data.Common;
using System.Threading;

namespace optic
{
    public partial class Cevaplar : Form
    {
        DatabaseConnection db;
        DataCrud data;
        private DataTable dataTable;
        private DataTable answerKeyTable;

        public Cevaplar(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            PopulateComboBox(comboBox1);
            this.db = db;



        }

        private void Cevaplar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void geriButton_Click(object sender, EventArgs e)
        {
            DatabaseConnection connection = new DatabaseConnection();
            sinav_islemleri form = new sinav_islemleri(connection);
            form.Show();
            this.Hide();
        }

        private void cevapAnahtariListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Verileri DataGridView'a yükle
                DataTable dataTable = data.GetCevapListDataGrid();
                dataGridView1.DataSource = dataTable;
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "Ders Kodu";
                    dataGridView1.Columns[1].HeaderText = "Ders Adı";
                    dataGridView1.Columns[2].HeaderText = "Cevap Anahtarı";
                }

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj kutusu göster
                throw ex;
            }
        }

        private void cevapAnahtari_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            // Excel dosyasını oku ve DataTable'a aktar
            DataTable dataTable = ReadExcelFile(filePath);

            // Veritabanına aktar
            if (dataTable != null)
            {
                data.InsertAnsIntoDatabase(dataTable);
            }
            cevapAnahtariListele_Click(sender, e);
            PopulateComboBox(comboBox1);
        }

        private DataTable ReadExcelFile(string filePath, string dersKodu = null)
        {
            DataTable dataTable = new DataTable();
            if (dersKodu != null)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = false
                            }
                        });

                        dataTable = result.Tables[0];
                    }
                }

                // Sütun adlarını manuel olarak ayarla
                dataTable.Columns[0].ColumnName = "ders_kodu";
                dataTable.Columns[1].ColumnName = "ders_adi";
                dataTable.Columns[2].ColumnName = "cevap";

                // Ders kodu sütununu ekle
                dataTable.Columns.Add("derskodu", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    row["derskodu"] = dersKodu;
                }
            }
            else
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = false
                            }
                        });

                        dataTable = result.Tables[0];
                    }
                }

                // Sütun adlarını manuel olarak ayarla
                dataTable.Columns[0].ColumnName = "ders_kodu";
                dataTable.Columns[1].ColumnName = "ders_Adi";
                dataTable.Columns[2].ColumnName = "cevap";

            }
            return dataTable;

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
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

        private void buttonListele_Click(object sender, EventArgs e)
        {

            try
            {
                var selectedDers = comboBox1.SelectedItem.ToString();
                if (selectedDers != null)
                {
                    string query = $"SELECT * FROM optictxt WHERE ders1 = '{selectedDers}' OR ders2 = '{selectedDers}' OR ders3 = '{selectedDers}'" +
                $" OR ders4 = '{selectedDers}' OR ders5 = '{selectedDers}' OR ders6 = '{selectedDers}'";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            // Verileri DataTable'a doldurun
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                    dataGridView1.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Lütfen önce dersi seçiniz.");

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message} \n Lütfen önce dersi seçiniz.(Elle yazmayınız.)");

            }



        }




        private void dKoduChck_CheckedChanged(object sender, EventArgs e)
        {
            if (dKoduChck.Checked)
            {
                DialogResult result = MessageBox.Show("Bu işlemi yapmanız diğer veritabanlarını silecektir.", "Onay", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //Burada veritabanları silinmeli

                    DatabaseConnection connection = new DatabaseConnection();
                    DersKodlarınıEkle form = new DersKodlarınıEkle(connection);
                    form.ShowDialog();

                }
                else
                {
                    dKoduChck.Checked = false;

                }

            }
        }

        private void DbSil_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM ogrlist;" +
                "DELETE FROM optictxt;";

            try
            {
                db.OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Başarıyla silindi.", "Veritabanı Tabloları", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        /*private void sonuc_hesapla_Click(object sender, EventArgs e)
{
try
{
// Veritabanı bağlantısını aç
DatabaseConnection dbConnection = new DatabaseConnection();
dbConnection.OpenConnection();

// Verileri getir
DataTable optictxtData = GetTableData(dbConnection.GetConnection(), "SELECT * FROM optictxt");
DataTable cevapanahtariData = GetTableData(dbConnection.GetConnection(), "SELECT * FROM cevapanahtarı");

// Sonuçları hesapla
DataTable resultTable = CalculateResults(optictxtData, cevapanahtariData);

// Sonuçları veritabanına kaydet
SaveResults(dbConnection.GetConnection(), resultTable);

// Veritabanı bağlantısını kapat
dbConnection.CloseConnection();

MessageBox.Show("Sonuçlar başarıyla hesaplandı ve kaydedildi.");
}
catch (Exception ex)
{
throw ex;
}

}
DataTable GetTableData(MySqlConnection connection, string query)
{
MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
DataTable table = new DataTable();
adapter.Fill(table);
return table;
}

DataTable CalculateResults(DataTable optictxtData, DataTable cevapanahtariData)
{   
DataTable table = new DataTable();

return table;
}

void SaveResults(MySqlConnection connection, DataTable results)
{
foreach (DataRow row in results.Rows)
{
string query = @"
INSERT INTO ogrenci_sonuclari (ogr_num, ogr_isim, doğru, yanlış, bos, net, puan, durum) 
VALUES (@ogr_num, @ogr_isim, @doğru, @yanlış, @bos, @net, @puan, @durum)
ON DUPLICATE KEY UPDATE 
doğru = VALUES(doğru), 
yanlış = VALUES(yanlış), 
bos = VALUES(bos), 
net = VALUES(net), 
puan = VALUES(puan), 
durum = VALUES(durum);";

using (MySqlCommand command = new MySqlCommand(query, connection))
{
command.Parameters.AddWithValue("@ogr_num", row["ogr_num"]);
command.Parameters.AddWithValue("@ogr_isim", row["ogr_isim"]);
command.Parameters.AddWithValue("@doğru", row["doğru"]);
command.Parameters.AddWithValue("@yanlış", row["yanlış"]);
command.Parameters.AddWithValue("@bos", row["bos"]);
command.Parameters.AddWithValue("@net", row["net"]);
command.Parameters.AddWithValue("@puan", row["puan"]);
command.Parameters.AddWithValue("@durum", row["durum"]);

command.ExecuteNonQuery();
}
}
}*/

    }
}
