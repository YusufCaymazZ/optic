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
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

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

                if (dataTable.Columns[3] != null)
                {
                    dataTable.Columns[3].ColumnName = "kitapcik";
                }

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
                if (dataTable.Columns.Count > 3)
                {
                    dataTable.Columns[3].ColumnName = "kitapcik";
                }


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
                DialogResult result = MessageBox.Show("Bu işlemi yapmanız diğer veritabanlarını silmeyi unutmayınız. Aksi durumda karışıklığa sebep olabilir.", "Onay", MessageBoxButtons.OKCancel);
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
                "DELETE FROM optictxt;" +
                "DELETE FROM ogrenci_sonuclari;" +
                "DELETE FROM ozelsinav;" +
                "DELETE FROM cevapanahtarı;" +
                "DELETE FROM dersler;";

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

        private void sonuc_hesapla_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Veritabanına İşleniyor.\n Bunu kapattıktan sonra diğer mesaj kutusuna kadar bekleyiniz.");
                db.OpenConnection();

                // Tüm öğrencileri optictxt tablosundan al
                string allStudentsQuery = "SELECT * FROM optictxt";
                DataTable allStudentsTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(allStudentsQuery, db.GetConnection()))
                {
                    adapter.Fill(allStudentsTable);
                }

                // Cevap anahtarlarını al
                string cevapAnahtariQuery = "SELECT * FROM cevapanahtarı";
                DataTable cevapAnahtariTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cevapAnahtariQuery, db.GetConnection()))
                {
                    adapter.Fill(cevapAnahtariTable);
                }

                foreach (DataRow studentRow in allStudentsTable.Rows)
                {
                    string studentId = studentRow["ogr_num"].ToString();
                    string studentName = studentRow["ogr_isim"].ToString();
                    string studentDurum = studentRow["durum"].ToString();
                    string[] dersKodlari = { "ders1", "ders2", "ders3", "ders4", "ders5", "ders6" };
                    string[] cevapKodlari = { "cevap1", "cevap2", "cevap3", "cevap4", "cevap5", "cevap6" };

                    for (int i = 0; i < 6; i++)
                    {
                        string dersKodu = studentRow[dersKodlari[i]].ToString();
                        string ogrenciCevap = studentRow[cevapKodlari[i]].ToString();

                        // Cevap anahtarını cevapanahtar tablosundan al
                        DataRow[] anahtarRows = cevapAnahtariTable.Select($"ders_kodu = '{dersKodu}'");
                        if (anahtarRows.Length > 0)
                        {
                            string cevapAnahtari = anahtarRows[0]["cevap"].ToString();
                            int dogruSayisi = 0;
                            int yanlisSayisi = 0;
                            int bosSayisi = 0;
                            int uzunluk = cevapAnahtari.Length;

                            for (int j = 0; j < uzunluk; j++)
                            {
                                char ogrenciCevapKarakteri = j < ogrenciCevap.Length ? ogrenciCevap[j] : ' ';
                                char anahtarCevapKarakteri = cevapAnahtari[j];

                                if (ogrenciCevapKarakteri == anahtarCevapKarakteri)
                                {
                                    dogruSayisi++;
                                }
                                else if (ogrenciCevapKarakteri == ' ')
                                {
                                    bosSayisi++;
                                }
                                else
                                {
                                    yanlisSayisi++;
                                }
                            }

                            double net = dogruSayisi - (yanlisSayisi / 4.0); // 4 yanlış 1 doğruyu götürüyor
                            double dersPuan = (dogruSayisi / (double)uzunluk) * 100;
                            studentDurum = studentDurum == "E" ? "Girmedi" : studentDurum;
                            // Verileri ogrenci_sonuclari tablosuna ekle
                            string insertQuery = @"
    INSERT INTO ogrenci_sonuclari (ogr_num, ogr_isim, ders, ogr_cevap, doğru, yanlış, bos, net, puan, ders_kod, durum)
    VALUES (@ogr_num, @ogr_isim, @ders, @ogr_cevap, @doğru, @yanlış, @bos, @net, @puan, @ders_kod, @durum)
    ON DUPLICATE KEY UPDATE 
        ogr_isim = VALUES(ogr_isim), 
        ogr_cevap = VALUES(ogr_cevap), 
        doğru = VALUES(doğru), 
        yanlış = VALUES(yanlış), 
        bos = VALUES(bos), 
        net = VALUES(net), 
        puan = VALUES(puan), 
        durum = VALUES(durum)";


                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, db.GetConnection()))
                            {
                                cmd.Parameters.AddWithValue("@ogr_num", studentId);
                                cmd.Parameters.AddWithValue("@ogr_isim", studentName);
                                cmd.Parameters.AddWithValue("@ders", dersKodu);
                                cmd.Parameters.AddWithValue("@ogr_cevap", ogrenciCevap);
                                cmd.Parameters.AddWithValue("@doğru", dogruSayisi);
                                cmd.Parameters.AddWithValue("@yanlış", yanlisSayisi);
                                cmd.Parameters.AddWithValue("@bos", bosSayisi);
                                cmd.Parameters.AddWithValue("@net", dogruSayisi);
                                cmd.Parameters.AddWithValue("@puan", dersPuan);
                                cmd.Parameters.AddWithValue("@ders_kod", dersKodu);
                                cmd.Parameters.AddWithValue("@durum", studentDurum);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                data.GuncelleOgrIsimleri();
                MessageBox.Show("Veritabanına işleme tamamlandı.");
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
                db.CloseConnection();
            }
        }



        private void yosHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Veritabanına İşleniyor.\n Bunu kapattıktan sonra diğer mesaj kutusuna kadar bekleyiniz.");
                db.OpenConnection();

                // Tüm öğrencileri optictxt tablosundan al
                string allStudentsQuery = "SELECT * FROM optictxt";
                DataTable allStudentsTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(allStudentsQuery, db.GetConnection()))
                {
                    adapter.Fill(allStudentsTable);
                }

                // Cevap anahtarlarını al
                string cevapAnahtariQuery = "SELECT * FROM cevapanahtarı";
                DataTable cevapAnahtariTable = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cevapAnahtariQuery, db.GetConnection()))
                {
                    adapter.Fill(cevapAnahtariTable);
                }

                foreach (DataRow studentRow in allStudentsTable.Rows)
                {
                    string studentId = studentRow["ogr_num"].ToString();
                    string studentName = studentRow["ogr_isim"].ToString();
                    string[] dersKodlari = { "ders1", "ders2", "ders3", "ders4", "ders5", "ders6" };
                    string[] cevapKodlari = { "cevap1", "cevap2", "cevap3", "cevap4", "cevap5", "cevap6" };

                    int[] dogruSayilari = new int[6];
                    int[] yanlisSayilari = new int[6];
                    int[] bosSayilari = new int[6];
                    int[] toplamCevapSayilari = new int[6];
                    double toplamPuan = 0;
                    int dersSayisi = 0;

                    for (int i = 0; i < 6; i++)
                    {
                        string dersKodu = studentRow[dersKodlari[i]].ToString();
                        string ogrenciCevap = studentRow[cevapKodlari[i]].ToString();

                        // Cevap anahtarını cevapanahtar tablosundan al
                        DataRow[] anahtarRows = cevapAnahtariTable.Select($"ders_kodu = '{dersKodu}' AND kitapcik = '{studentRow["kitapcik"]}'");
                        if (anahtarRows.Length > 0)
                        {
                            string cevapAnahtari = anahtarRows[0]["cevap"].ToString();
                            int uzunluk = cevapAnahtari.Length;

                            for (int j = 0; j < uzunluk; j++)
                            {
                                char ogrenciCevapKarakteri = j < ogrenciCevap.Length ? ogrenciCevap[j] : ' ';
                                char anahtarCevapKarakteri = cevapAnahtari[j];

                                if (ogrenciCevapKarakteri == anahtarCevapKarakteri)
                                {
                                    dogruSayilari[i]++;
                                }
                                else if (ogrenciCevapKarakteri == ' ')
                                {
                                    bosSayilari[i]++;
                                }
                                else
                                {
                                    yanlisSayilari[i]++;
                                }
                            }

                            // Her ders için puanı hesapla ve toplam puana ekle
                            double dersPuan = (dogruSayilari[i] / (double)uzunluk) * 100;
                            toplamPuan += dersPuan;
                            dersSayisi++;
                            toplamCevapSayilari[i] = dogruSayilari[i] + yanlisSayilari[i] + bosSayilari[i];
                        }
                        else
                        {
                            bosSayilari[i] += ogrenciCevap.Length; // Cevap anahtarı yoksa tüm cevapları boş say
                        }
                    }

                    // Ortalama puanı hesapla
                    double ortalamaPuan = dersSayisi > 0 ? toplamPuan / dersSayisi : 0;

                    // Verileri ozelsinav tablosuna ekle
                    string insertQuery = @"
                    INSERT INTO ozelsinav (ogr_num, ogr_isim, ders1, ders1d, ders1y, ders1b, ders1n, 
                                            ders2, ders2d, ders2y, ders2b, ders2n, puan) 
                    VALUES (@ogr_num, @ogr_isim, @ders1, @ders1d, @ders1y, @ders1b, @ders1n, 
                            @ders2, @ders2d, @ders2y, @ders2b, @ders2n, @puan)";


                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@ogr_num", studentId);
                        cmd.Parameters.AddWithValue("@ogr_isim", studentName);
                        cmd.Parameters.AddWithValue("@ders1", studentRow[dersKodlari[0]].ToString());
                        cmd.Parameters.AddWithValue("@ders1d", dogruSayilari[0]);
                        cmd.Parameters.AddWithValue("@ders1y", yanlisSayilari[0]);
                        cmd.Parameters.AddWithValue("@ders1b", bosSayilari[0]);
                        cmd.Parameters.AddWithValue("@ders1n", (double)dogruSayilari[0] * 1.25); // Doğru cevap sayısını 1.25 ile çarp
                        cmd.Parameters.AddWithValue("@ders2", studentRow[dersKodlari[1]].ToString());
                        cmd.Parameters.AddWithValue("@ders2d", dogruSayilari[1]);
                        cmd.Parameters.AddWithValue("@ders2y", yanlisSayilari[1]);
                        cmd.Parameters.AddWithValue("@ders2b", bosSayilari[1]);
                        cmd.Parameters.AddWithValue("@ders2n", (double)dogruSayilari[1] * 1.25); // Doğru cevap sayısını 1.25 ile çarp
                        cmd.Parameters.AddWithValue("@puan", ortalamaPuan);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Veritabanına işleme tamamlandı.");
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
                db.CloseConnection();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null || textBox1.Text == "Sınav dosyası adı")
            {
                MessageBox.Show("Lütfen önce Excel dosya adını giriniz.");
            }
            else
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderDialog.SelectedPath;
                        string fileName = "" + textBox1.Text + ".xlsx";
                        string filePath = System.IO.Path.Combine(folderPath, fileName);

                        try
                        {
                            db.OpenConnection();
                            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ozelsinav", db.GetConnection());
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                            {
                                WorkbookPart workbookPart = document.AddWorkbookPart();
                                workbookPart.Workbook = new Workbook();
                                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                                worksheetPart.Worksheet = new Worksheet(new SheetData());

                                Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                                Sheet sheet = new Sheet()
                                {
                                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                                    SheetId = 1,
                                    Name = "Sheet1"
                                };
                                sheets.Append(sheet);

                                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                                // Sütun başlıklarını ekleyin
                                Row headerRow = new Row();
                                foreach (DataColumn column in dt.Columns)
                                {
                                    Cell cell = new Cell
                                    {
                                        DataType = CellValues.String,
                                        CellValue = new CellValue(column.ColumnName)
                                    };
                                    headerRow.AppendChild(cell);
                                }
                                sheetData.AppendChild(headerRow);

                                // Verileri ekleyin
                                foreach (DataRow dtRow in dt.Rows)
                                {
                                    Row newRow = new Row();
                                    foreach (var item in dtRow.ItemArray)
                                    {
                                        Cell cell = new Cell
                                        {
                                            DataType = CellValues.String,
                                            CellValue = new CellValue(item.ToString())
                                        };
                                        newRow.AppendChild(cell);
                                    }
                                    sheetData.AppendChild(newRow);
                                }

                                workbookPart.Workbook.Save();
                            }

                            MessageBox.Show("Veriler Excel dosyasına başarıyla kaydedildi.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                        finally
                        {
                            db.CloseConnection();
                        }
                    }
                }
            
            }
        }

        private void sonucCikti_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Lütfen bir yol belirtiniz.");
                // Klasör seçimi için FolderBrowserDialog açılır
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderBrowserDialog.SelectedPath;

                        db.OpenConnection();

                        // Ders kodlarını ve eşleşen program-ders bilgilerini al
                        string dersKodlariQuery = @"
                    SELECT c.ders_kodu, d.program, d.ders 
                    FROM cevapanahtarı c
                    JOIN dersler d ON c.ders_kodu = d.dersKod";
                        DataTable dersKodlariTable = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(dersKodlariQuery, db.GetConnection()))
                        {
                            adapter.Fill(dersKodlariTable);
                        }

                        foreach (DataRow row in dersKodlariTable.Rows)
                        {
                            string dersKodu = row["ders_kodu"].ToString();
                            string program = row["program"].ToString();
                            string dersAdi = row["ders"].ToString();
                            string fileName = $"{program}-{dersAdi}.xlsx";
                            string filePath = Path.Combine(selectedPath, fileName);

                            // Ders koduna göre ogrenci_sonuclari tablosundaki verileri al
                            string ogrenciSonuclariQuery = @"
                        SELECT ogr_num, ogr_isim, ders, ogr_cevap, doğru, yanlış, bos, net, puan, ders_kod, durum 
                        FROM ogrenci_sonuclari
                        WHERE ders_kod = @ders_kodu";
                            DataTable ogrenciSonuclariTable = new DataTable();
                            using (MySqlCommand cmd = new MySqlCommand(ogrenciSonuclariQuery, db.GetConnection()))
                            {
                                cmd.Parameters.AddWithValue("@ders_kodu", dersKodu);
                                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                                {
                                    adapter.Fill(ogrenciSonuclariTable);
                                }
                            }

                            // Excel dosyası oluşturulması
                            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                            {
                                WorkbookPart workbookPart = document.AddWorkbookPart();
                                workbookPart.Workbook = new Workbook();
                                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                                SheetData sheetData = new SheetData();
                                worksheetPart.Worksheet = new Worksheet(sheetData);

                                // Başlık satırını oluştur
                                Row headerRow = new Row();
                                foreach (DataColumn column in ogrenciSonuclariTable.Columns)
                                {
                                    Cell cell = new Cell
                                    {
                                        CellValue = new CellValue(column.ColumnName),
                                        DataType = CellValues.String
                                    };
                                    headerRow.AppendChild(cell);
                                }
                                sheetData.AppendChild(headerRow);

                                // Verileri satırlara ekle
                                foreach (DataRow dataRow in ogrenciSonuclariTable.Rows)
                                {
                                    Row newRow = new Row();
                                    foreach (var item in dataRow.ItemArray)
                                    {
                                        Cell cell = new Cell
                                        {
                                            CellValue = new CellValue(item.ToString()),
                                            DataType = CellValues.String
                                        };
                                        newRow.AppendChild(cell);
                                    }
                                    sheetData.AppendChild(newRow);
                                }

                                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                                stylesPart.Stylesheet = new Stylesheet();
                                stylesPart.Stylesheet.Save();

                                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                                Sheet sheet = new Sheet
                                {
                                    Id = workbookPart.GetIdOfPart(worksheetPart),
                                    SheetId = 1,
                                    Name = dersAdi
                                };
                                sheets.Append(sheet);

                                workbookPart.Workbook.Save();
                            }
                        }

                        MessageBox.Show("Sonuçlar başarılı bir şekilde Excel dosyalarına aktarıldı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        
    }
}

