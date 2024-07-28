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

namespace optic
{
    public partial class Cevaplar : Form
    {
        DatabaseConnection db;
        DataCrud data;
        public Cevaplar(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);

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
    }
}
