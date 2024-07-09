using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms;
using System;
namespace optic
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }



        private void sinav_btn_Click_1(object sender, EventArgs e)
        {
            DatabaseConnection conn = new DatabaseConnection();
            sinav_islemleri sinav_islemleri = new sinav_islemleri(conn);
            sinav_islemleri.Show();
            this.Hide();
        }

        private void Ana_Sayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
