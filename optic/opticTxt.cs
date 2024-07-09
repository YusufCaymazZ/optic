using System.IO;
using System.Text;
namespace optic
{
    public partial class opticTxt : Form
    {
        private String ogrnum = null;
        private String ogrisim = null;
        private String ders1 = null;
        private String ders2 = null;
        private String ders3 = null;
        private String ders4 = null;
        private String ders5 = null;
        private String ders6 = null;
        private String cevap1 = null;
        private String cevap2 = null;
        private String cevap3 = null;
        private String cevap4 = null;
        private String cevap5 = null;
        private String cevap6 = null;
        private String oturum = null;
        private String grup = null;
        private String kitapcik = null;
        private String durum = null;
        DatabaseConnection db;
        DataCrud data;
        string filePath;
        string[] lines;
        public opticTxt(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                lines = ReadFileLines(filePath);
                MessageBox.Show(lines[1]);
                // Dosya yolu ile yapýlacak iþlemler
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
                foreach (string line in linesList) {
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

                    data.AddTxt(ogrnum,ogrisim,ders1,ders2,ders3,ders4,ders5,ders6,cevap1,cevap2,cevap3,cevap4,cevap5,cevap6,oturum,
                        grup,kitapcik,durum);
                        
                }
                MessageBox.Show("Öðrenciler baþarýyla eklendi.");







            }
            catch (Exception e)
            {
                MessageBox.Show("Dosya okuma hatasý: " + e.Message);
            }

            return linesList.ToArray();
        }

        private string GetSubstring(string input, int startIndex, int endIndex)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (startIndex < 0 || startIndex >= input.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (endIndex < 0 || endIndex > input.Length)
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            if (startIndex > endIndex)
                throw new ArgumentException("startIndex cannot be greater than endIndex");

            return input.Substring(startIndex, endIndex - startIndex);
        }

        
    }
}




