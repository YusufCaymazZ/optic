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
        private String ogrnum { get; set; }
        private String ogrisim { get; set; }
        private String ders1 { get; set; }
        private String ders2 { get; set; }
        private String ders3 { get; set; }
        private String ders4 { get; set; }
        private String ders5 { get; set; }
        private String ders6 { get; set; }
        private String cevap1 { get; set; }
        private String cevap2 { get; set; }
        private String cevap3 { get; set; }
        private String cevap4 { get; set; }
        private String cevap5 { get; set; }
        private String cevap6 { get; set; }
        private String oturum { get; set; }
        private String grup { get; set; }
        private String kitapcik { get; set; }
        private String gelmedi { get; set; }
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
            opticTxt opticTxt = new opticTxt();
            opticTxt.Show();
            this.Hide();
        }
    }
}
