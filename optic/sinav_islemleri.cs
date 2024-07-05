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
        }


        private void mysqltest_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.OpenConnection();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı işlemi sırasında bir hata oluştu: {ex.Message}");
            }

        }

        private void txtoutput_Click(object sender, EventArgs e)
        {

        }
    }
}
