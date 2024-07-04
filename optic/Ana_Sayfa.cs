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
        }

        

        private void sinav_btn_Click_1(object sender, EventArgs e)
        {
            sinav_islemleri sinav_islemleri = new sinav_islemleri();
            sinav_islemleri.Show();
            this.Hide();


        }
    }
}
