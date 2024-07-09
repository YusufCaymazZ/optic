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
    public partial class ogr_guncelle : Form
    {
        
        public ogr_guncelle()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void ogr_guncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geribtn_Click(object sender, EventArgs e)
        {
            DatabaseConnection conn = new DatabaseConnection(); 
            opticTxt opticTxt = new opticTxt(conn);
            opticTxt.Show();
            this.Hide();
        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
