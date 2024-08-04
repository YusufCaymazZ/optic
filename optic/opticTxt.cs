using System.IO;
using System.Text;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Collections.Generic;

namespace optic
{
    public partial class opticTxt : Form
    {
        List<int> dt = new List<int>();
        private string opticTuru;
        private int ogrnumBasi = 0;
        private int ogrisimBasi = 0;
        private int ders1Basi = 0;
        private int ders2Basi = 0;
        private int ders3Basi = 0;
        private int ders4Basi = 0;
        private int ders5Basi = 0;
        private int ders6Basi = 0;
        private int cevap1Basi = 0;
        private int cevap2Basi = 0;
        private int cevap3Basi = 0;
        private int cevap4Basi = 0;
        private int cevap5Basi = 0;
        private int cevap6Basi = 0;
        private int oturumBasi = 0;
        private int grupBasi = 0;
        private int kitapcikBasi = 0;
        private int durumBasi = 0;

        private int ogrnumBiti = 0;
        private int ogrisimBiti = 0;
        private int ders1Biti = 0;
        private int ders2Biti = 0;
        private int ders3Biti = 0;
        private int ders4Biti = 0;
        private int ders5Biti = 0;
        private int ders6Biti = 0;
        private int cevap1Biti = 0;
        private int cevap2Biti = 0;
        private int cevap3Biti = 0;
        private int cevap4Biti = 0;
        private int cevap5Biti = 0;
        private int cevap6Biti = 0;
        private int oturumBiti = 0;
        private int grupBiti = 0;
        private int kitapcikBiti = 0;
        private int durumBiti = 0;

        private string ogrnum = null;
        private string ogrisim = null;
        private string ders1 = null;
        private string ders2 = null;
        private string ders3 = null;
        private string ders4 = null;
        private string ders5 = null;
        private string ders6 = null;
        private string cevap1 = null;
        private string cevap2 = null;
        private string cevap3 = null;
        private string cevap4 = null;
        private string cevap5 = null;
        private string cevap6 = null;
        private string oturum = null;
        private string grup = null;
        private string kitapcik = null;
        private string durum = null;

        DatabaseConnection db;
        DataCrud data;
        string filePath;
        string[] lines = null;
        public opticTxt(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
            this.db = db;
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            DatabaseConnection conn = new DatabaseConnection();
            sinav_islemleri sinav_islemleri = new sinav_islemleri(conn);
            sinav_islemleri.Show();
            this.Hide();
        }



        private void opticTxt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opticCombo.SelectedIndex != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    lines = ReadFileLines(filePath);

                    string selectedItem = opticCombo.SelectedItem.ToString();
                    dt = data.GetIntColumns(selectedItem);
                    int[] newdt =  dt.ToArray();
                    BasBitEvent(lines, newdt);

                    // Dosya yolu ile yapýlacak iþlemler
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir optik türü giriniz.");
            }

        }
        private void opticEkle_Click(object sender, EventArgs e)
        {
            ogrnumBasi = int.Parse(ogrNumBas.Text);
            ogrnumBiti = int.Parse(ogrNumBit.Text);
            ogrisimBasi = int.Parse(ogrAdBas.Text);
            ogrisimBiti = int.Parse(ogrAdBit.Text);
            ders1Basi = int.Parse(d1Bas.Text);
            ders1Biti = int.Parse(d1Bit.Text);
            ders2Basi = int.Parse(d2Bas.Text);
            ders2Biti = int.Parse(d2Bit.Text);
            ders3Basi = int.Parse(d3Bas.Text);
            ders3Biti = int.Parse(d3Bit.Text);
            ders4Basi = int.Parse(d4Bas.Text);
            ders4Biti = int.Parse(d4Bit.Text);
            ders5Basi = int.Parse(d5Bas.Text);
            ders5Biti = int.Parse(d5Bit.Text);
            ders6Basi = int.Parse(d6Bas.Text);
            ders6Biti = int.Parse(d6Bit.Text);
            cevap1Basi = int.Parse(c1Bas.Text);
            cevap1Biti = int.Parse(c1Bit.Text);
            cevap2Basi = int.Parse(c2Bas.Text);
            cevap2Biti = int.Parse(c2Bit.Text);
            cevap3Basi = int.Parse(c3Bas.Text);
            cevap3Biti = int.Parse(c3Bit.Text);
            cevap4Basi = int.Parse(c4Bas.Text);
            cevap4Biti = int.Parse(c4Bit.Text);
            cevap5Basi = int.Parse(c5Bas.Text);
            cevap5Biti = int.Parse(c5Bit.Text);
            cevap6Basi = int.Parse(c6Bas.Text);
            cevap6Biti = int.Parse(c6Bit.Text);
            oturumBasi = int.Parse(oturumBas.Text);
            oturumBiti = int.Parse(oturumBit.Text);
            kitapcikBasi = int.Parse(KitapcikBas.Text);
            kitapcikBiti = int.Parse(KitapcikBit.Text);
            grupBasi = int.Parse(grupBas.Text);
            grupBiti = int.Parse(grupBit.Text);
            durumBasi = int.Parse(durumBas.Text);
            durumBiti = int.Parse(durumBit.Text);
            if (opticturTxt.Text != "")
            {
                data.AddOptic(opticturTxt.Text, ogrnumBasi, ogrnumBiti, ogrisimBasi, ogrisimBiti, ders1Basi,
                    ders1Biti, ders2Basi, ders2Biti, ders3Basi, ders3Biti, ders4Basi, ders4Biti, ders5Basi, ders5Biti, ders6Basi,
                    ders6Biti, cevap1Basi, cevap1Biti, cevap2Basi, cevap2Biti, cevap3Basi, cevap3Biti, cevap4Basi, cevap4Biti, cevap5Basi,
                    cevap5Biti, cevap6Basi, cevap6Biti, oturumBasi, oturumBiti, grupBasi, grupBiti,
                    kitapcikBasi, kitapcikBiti, durumBasi, durumBiti);
                MessageBox.Show($"{opticturTxt.Text} baþarýyla eklendi ");
                PopulateComboBox(opticCombo);
            }
            else
            {
                MessageBox.Show("Lütfen optic ad kýsmýný boþ býrakmayýnýz.");
            }
        }
        private string[] ReadFileLines(string filePath)
        {
            List<string> linesList = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("windows-1254")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        linesList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Dosya okuma hatasý: " + e.Message);
            }

            return linesList.ToArray();
        }

        private string GetSubstring(string input, int startIndex, int endIndex)
        {
            /*if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (startIndex < 0 || startIndex >= input.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (endIndex < 0 || endIndex > input.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            if (startIndex > endIndex)
                throw new ArgumentException("startIndex cannot be greater than endIndex");*/

            return input.Substring(startIndex, endIndex);
        }

        public void PopulateComboBox(ComboBox comboBox)
        {
            List<string> opticTurValues = data.GetOpticTurValues();
            comboBox.Items.Clear();
            foreach (var value in opticTurValues)
            {
                comboBox.Items.Add(value);
            }
        }
        public void BasBitEvent(string[] linesList, int[] dt)
        {
            if (dt.Length > 36 && dt.Length < 36)
            {
                throw new ArgumentException("dt listesi 36 eleman olmalýdýr.");
            }
            int value;
            MessageBox.Show($"Index uzunluðu = {dt.Length}");
            foreach (string line in linesList)
            {
                ogrnum = GetSubstring(line, dt[0], dt[1]);
                ogrisim = GetSubstring(line, dt[2], dt[3]);
                ders1 = GetSubstring(line, dt[4], dt[5]);
                ders2 = GetSubstring(line, dt[6], dt[7]);
                ders3 = GetSubstring(line, dt[8], dt[9]);
                ders4 = GetSubstring(line, dt[10], dt[11]);
                ders5 = GetSubstring(line, dt[12], dt[13]);
                ders6 = GetSubstring(line, dt[14], dt[15]);
                cevap1 = GetSubstring(line, dt[16], dt[17]);
                cevap2 = GetSubstring(line, dt[18], dt[19]);
                cevap3 = GetSubstring(line, dt[20], dt[21]);
                cevap4 = GetSubstring(line, dt[22], dt[23]);
                cevap5 = GetSubstring(line, dt[24], dt[25]);
                cevap6 = GetSubstring(line, dt[26], dt[27]);
                oturum = GetSubstring(line, dt[28], dt[29]);
                grup = GetSubstring(line, dt[30], dt[31]);
                kitapcik = GetSubstring(line, dt[32], dt[33]);
                durum = GetSubstring(line, dt[34], dt[35]);
                data.AddTxt(ogrnum, ogrisim, ders1, ders2, ders3, ders4, ders5, ders6, cevap1, cevap2, cevap3, cevap4, cevap5, cevap6, oturum,
                grup, kitapcik, durum);
            }
            MessageBox.Show("Öðrenciler baþarýyla eklendi.");

        }

        private void opticTxt_Load(object sender, EventArgs e)
        {
            PopulateComboBox(opticCombo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();
                string query = "DELETE FROM optictur WHERE opticTur = @opticTur";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@opticTur", opticCombo.Text);  
                cmd.ExecuteNonQuery();
                PopulateComboBox(opticCombo);
            }
            catch(Exception E)
            {
                MessageBox.Show("Silme iþlemi sýrasýnda bir hata oluþtu." + E.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }






    /*
     * foreach (string line in linesList)
            {
                ogrnum = GetSubstring(line, int.Parse(ogrNumBas.Text), int.Parse(ogrNumBit.Text));
                ogrisim = GetSubstring(line, int.Parse(ogrAdBas.Text), int.Parse(ogrAdBit.Text));
                ders1 = GetSubstring(line, int.Parse(d1Bas.Text), int.Parse(d1Bit.Text));
                ders2 = GetSubstring(line, int.Parse(d2Bas.Text), int.Parse(d2Bit.Text));
                ders3 = GetSubstring(line, int.Parse(d3Bas.Text), int.Parse(d3Bit.Text));
                ders4 = GetSubstring(line, int.Parse(d4Bas.Text), int.Parse(d4Bit.Text));
                ders5 = GetSubstring(line, int.Parse(d5Bas.Text), int.Parse(d5Bit.Text));
                ders6 = GetSubstring(line, int.Parse(d6Bas.Text), int.Parse(d6Bit.Text));
                cevap1 = GetSubstring(line, int.Parse(c1Bas.Text), int.Parse(c1Bit.Text));
                cevap2 = GetSubstring(line, int.Parse(c2Bas.Text), int.Parse(c2Bit.Text));
                cevap3 = GetSubstring(line, int.Parse(c3Bas.Text), int.Parse(c3Bit.Text));
                cevap4 = GetSubstring(line, int.Parse(c4Bas.Text), int.Parse(c4Bit.Text));
                cevap5 = GetSubstring(line, int.Parse(c5Bas.Text), int.Parse(c5Bit.Text));
                cevap6 = GetSubstring(line, int.Parse(c6Bas.Text), int.Parse(c6Bit.Text));
                oturum = GetSubstring(line, int.Parse(oturumBas.Text), int.Parse(oturumBit.Text));
                grup = GetSubstring(line, int.Parse(grupBas.Text), int.Parse(grupBit.Text));
                kitapcik = GetSubstring(line, int.Parse(KitapcikBas.Text), int.Parse(KitapcikBit.Text));
                durum = GetSubstring(line, int.Parse(durumBas.Text), int.Parse(durumBit.Text));
                data.AddTxt(ogrnum, ogrisim, ders1, ders2, ders3, ders4, ders5, ders6, cevap1, cevap2, cevap3, cevap4, cevap5, cevap6, oturum,
                grup, kitapcik, durum);
            }

    */
}




