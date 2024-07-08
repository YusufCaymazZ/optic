using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;


namespace optic
{
    public partial class sinav_islemleri : Form
    {
        public sinav_islemleri()
        {
            InitializeComponent();
            InitializeDataGridView();
            // Boyutlandırma düğmesini devre dışı bırak
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }


        private void mysqltest_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.OpenConnection();
                txtoutput.Text = "Veritabanına bağlanıldı";
                txtoutput.Visible = true;
                HandledUsers.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı işlemi sırasında bir hata oluştu: {ex.Message}");
            }

        }

        private void AddDataToGridView()
        {

        }
        private void InitializeDataGridView()
        {
            // DataGridView nesnesini oluştur ve ayarlarını yapılandır

            // 18 sütun ekle
            for (int i = 0; i < 18; i++)
            {
                HandledUsers.Columns.Add("Column" + i, "Sütun " + (i + 1));
            }
            HandledUsers.Columns["Column0"].HeaderText = "Numara";
            HandledUsers.Columns["Column1"].HeaderText = "Ad - Soyad";
            HandledUsers.Columns["Column2"].HeaderText = "Ders 1";
            HandledUsers.Columns["Column3"].HeaderText = "Ders 2";
            HandledUsers.Columns["Column4"].HeaderText = "Ders 3";
            HandledUsers.Columns["Column5"].HeaderText = "Ders 4";
            HandledUsers.Columns["Column6"].HeaderText = "Ders 5";
            HandledUsers.Columns["Column7"].HeaderText = "Ders 6";
            HandledUsers.Columns["Column8"].HeaderText = "Cevap 1";
            HandledUsers.Columns["Column9"].HeaderText = "Cevap 2";
            HandledUsers.Columns["Column10"].HeaderText = "Cevap 3";
            HandledUsers.Columns["Column11"].HeaderText = "Cevap 4";
            HandledUsers.Columns["Column12"].HeaderText = "Cevap 5";
            HandledUsers.Columns["Column13"].HeaderText = "Cevap 6";
            HandledUsers.Columns["Column14"].HeaderText = "Oturum";
            HandledUsers.Columns["Column15"].HeaderText = "Grup";
            HandledUsers.Columns["Column16"].HeaderText = "Kitapçık";
            HandledUsers.Columns["Column17"].HeaderText = "Gelmedi";

            // DataGridView'i forma ekle
            this.Controls.Add(HandledUsers);
        }

        private void txtButton_Click(object sender, EventArgs e)
        {

        }

        private void optic_txt_Click(object sender, EventArgs e)
        {
            opticTxt opticTxt = new opticTxt();
            opticTxt.Show();
            this.Close();
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            Ana_Sayfa form = new Ana_Sayfa();
            form.Show();
            this.Close();
        }

        private void sinav_islemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
