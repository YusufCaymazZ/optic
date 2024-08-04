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
                MessageBox.Show(ex.Message);
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
            
            catch(Exception ex) {
                MessageBox.Show($"Bir hata oluştu: {ex.Message} \n Lütfen önce dersi seçiniz.(Elle yazmayınız.)");

            }



        }


    }
}
