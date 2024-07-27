using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ExcelDataReader;
using ClosedXML.Excel;





namespace optic
{
    public partial class DersIslemleri : Form
    {
        DatabaseConnection db;
        DataCrud data;
        public DersIslemleri(DatabaseConnection db)
        {
            InitializeComponent();
            data = new DataCrud(db);
            this.db = db;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ogrDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ogrDataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(ogrDataGrid_RowPostPaint);
            dersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dersDataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dersDataGrid_RowPostPaint);
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            getirilecekDers.Text = string.Empty;
        }

        private void DersIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void geriButton_Click_1(object sender, EventArgs e)
        {
            Ana_Sayfa form = new Ana_Sayfa();
            form.Show();
            this.Hide();
        }



        private void ogrListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Verileri DataGridView'a yükle
                DataTable dataTable = data.GetogrListDataGrid();
                ogrDataGrid.DataSource = dataTable;
                if (ogrDataGrid.Columns.Count > 0)
                {
                    ogrDataGrid.Columns[0].HeaderText = "Ders Kodu";
                    ogrDataGrid.Columns[1].HeaderText = "Öğrenci No";
                    ogrDataGrid.Columns[2].HeaderText = "Öğrenci İsim";
                    ogrDataGrid.Columns[3].HeaderText = "Öğrenci Soyisim";
                }

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj kutusu göster
                MessageBox.Show(ex.Message);
            }

        }

        private void ogrGetirBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Verileri DataGridView'a yükle
                DataTable dataTable = data.GetOneOgrListDataGrid(ogrGetirTxt.Text);
                ogrDataGrid.DataSource = dataTable;
                if (ogrDataGrid.Columns.Count > 0)
                {
                    ogrDataGrid.Columns[0].HeaderText = "Ders Kodu";
                    ogrDataGrid.Columns[1].HeaderText = "Öğrenci No";
                    ogrDataGrid.Columns[2].HeaderText = "Öğrenci İsim";
                    ogrDataGrid.Columns[3].HeaderText = "Öğrenci Soyisim";
                }

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj kutusu göster
                MessageBox.Show(ex.Message);
            }

        }

        private void ogrEkleGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void ogrExcellBtn_Click(object sender, EventArgs e)
        {
            // Ders kodunu al
            string dersKodu = ogrDersKoduTxt.Text;

            if (string.IsNullOrWhiteSpace(dersKodu))
            {
                MessageBox.Show("Lütfen ders kodunu giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Excel dosyasını seç
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            // Excel dosyasını oku ve DataTable'a aktar
            DataTable dataTable = ReadExcelFile(filePath, dersKodu);

            // Veritabanına aktar
            if (dataTable != null)
            {
                data.InsertDataIntoDatabase(dataTable);
            }

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
                dataTable.Columns[0].ColumnName = "ogrno";
                dataTable.Columns[1].ColumnName = "ogrisim";
                dataTable.Columns[2].ColumnName = "ogrsoyad";

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
                dataTable.Columns[0].ColumnName = "derskodu";
                dataTable.Columns[1].ColumnName = "programadi";
                dataTable.Columns[2].ColumnName = "dersadi";

            }
            return dataTable;

        }



        private void ogrListSil_Click(object sender, EventArgs e)
        {
            // Ders kodunu al
            string dersKodu = ogrDersKoduTxt.Text;

            if (string.IsNullOrWhiteSpace(dersKodu))
            {
                MessageBox.Show("Lütfen ders kodunu giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Veritabanından ders koduna göre kayıtları sil
            data.DeleteRecordsByCourseCode(dersKodu);
        }

        private void ogrDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(ogrDataGrid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


        private void ogrGetirTxt_Click(object sender, EventArgs e)
        {
            ogrGetirTxt.Text = string.Empty;
        }

        private void dersListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Verileri DataGridView'a yükle
                DataTable dataTable = data.GetdersListDataGrid();
                dersDataGrid.DataSource = dataTable;
                if (dersDataGrid.Columns.Count > 0)
                {
                    dersDataGrid.Columns[0].HeaderText = "ID";
                    dersDataGrid.Columns[0].Visible = false;
                    dersDataGrid.Columns[1].HeaderText = "Ders Kodu";
                    dersDataGrid.Columns[2].HeaderText = "Program Adı";
                    dersDataGrid.Columns[3].HeaderText = "Ders Adı";
                }

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj kutusu göster
                MessageBox.Show(ex.Message);
            }
        }

        private void dersGetir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verileri DataGridView'a yükle
                DataTable dataTable = data.GetOneDersDataGrid(getirilecekDers.Text);
                dersDataGrid.DataSource = dataTable;
                if (dersDataGrid.Columns.Count > 0)
                {
                    dersDataGrid.Columns[0].HeaderText = "ID";
                    dersDataGrid.Columns[0].Visible = false;
                    dersDataGrid.Columns[1].HeaderText = "Ders Kodu";
                    dersDataGrid.Columns[2].HeaderText = "Program Adı";
                    dersDataGrid.Columns[3].HeaderText = "Ders Adı";

                }

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj kutusu göster
                MessageBox.Show(ex.Message);
            }
        }

        private void dersEkle_Click(object sender, EventArgs e)
        {

        }

        private void dersExcell_Click(object sender, EventArgs e)
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
                data.InsertOrUpdateCourse(dataTable);
            }
        }

        private void dersSilButton_Click(object sender, EventArgs e)
        {
            // Ders kodunu al
            string dersKodu = getirilecekDers.Text;

            if (string.IsNullOrWhiteSpace(dersKodu))
            {
                MessageBox.Show("Lütfen ders kodunu giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Veritabanından ders koduna göre kayıtları sil
            data.DeleteCourseByCourseCode(dersKodu);

        }

        private void dersDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dersDataGrid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
