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
        DatabaseConnection db;
        DataCrud data;
        public ogr_guncelle(DatabaseConnection db)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
        }

        private void ogr_guncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geribtn_Click(object sender, EventArgs e)
        {
            DatabaseConnection conn = new DatabaseConnection();
            sinav_islemleri opticTxt = new sinav_islemleri(conn);
            opticTxt.Show();
            this.Hide();
        }
        Student student = new Student();
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            string ogrnum = ogrnumtxtbox.Text;
            string isim = isimtxtbox.Text;
            string oturum = oturumtxtbox.Text;
            string grup = gruptxtbox.Text;
            string kitapcik = kitapciktxtbox.Text;
            string durum = durumtxtbox.Text;
            string ders1 = ders1txtbox.Text;
            string ders2 = ders2txtbox.Text;
            string ders3 = ders3txtbox.Text;
            string ders4 = ders4txtbox.Text;
            string ders5 = ders5txtbox.Text;
            string ders6 = ders6txtbox.Text;
            string cevap1 = cevap1txtbox.Text;
            string cevap2 = cevap2txtbox.Text;
            string cevap3 = cevap3txtbox.Text;
            string cevap4 = cevap4txtbox.Text;
            string cevap5 = cevap5txtbox.Text;
            string cevap6 = cevap6txtbox.Text;
            string eskinum = eskinumtxt.Text;
            try
            {
                 data.UpdateOneTxt(eskinum, ogrnum, isim, ders1, ders2, ders3, ders4
                    , ders5, ders6, cevap1, cevap2, cevap3, cevap4, cevap5, cevap6, oturum, grup, kitapcik, durum);
                Student student2 = new Student();
                student2 = data.GetStudentByOgrNum(ogrnum);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        private void ogrGetir_Click(object sender, EventArgs e)
        {
            string eskinum = eskinumtxt.Text;
            student = data.GetStudentByOgrNum(eskinum);

            if (student != null)
            {
                // Öğrenci bilgilerini işleyebilirsiniz
                MessageBox.Show($"Öğrenci Numarası: {student.OgrNum}, Öğrenci İsmi: {student.OgrIsim}");
                ogrnumtxtbox.Text = student.OgrNum;
                isimtxtbox.Text = student.OgrIsim;
                oturumtxtbox.Text = student.Oturum;
                gruptxtbox.Text = student.Grup;
                kitapciktxtbox.Text = student.Kitapcik;
                durumtxtbox.Text = student.Durum;
                ders1txtbox.Text = student.Ders1;
                ders2txtbox.Text = student.Ders2;
                ders3txtbox.Text = student.Ders3;
                ders4txtbox.Text = student.Ders4;
                ders5txtbox.Text = student.Ders5;
                ders6txtbox.Text = student.Ders6;
                cevap1txtbox.Text = student.Cevap1;
                cevap2txtbox.Text = student.Cevap2;
                cevap3txtbox.Text = student.Cevap3;
                cevap4txtbox.Text = student.Cevap4;
                cevap5txtbox.Text = student.Cevap5;
                cevap6txtbox.Text = student.Cevap6;

            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı.");
            }




        }
    }

    public class Student
    {
        public string OgrNum { get; set; }
        public string OgrIsim { get; set; }
        public string Ders1 { get; set; }
        public string Ders2 { get; set; }
        public string Ders3 { get; set; }
        public string Ders4 { get; set; }
        public string Ders5 { get; set; }
        public string Ders6 { get; set; }
        public string Cevap1 { get; set; }
        public string Cevap2 { get; set; }
        public string Cevap3 { get; set; }
        public string Cevap4 { get; set; }
        public string Cevap5 { get; set; }
        public string Cevap6 { get; set; }
        public string Oturum { get; set; }
        public string Grup { get; set; }
        public string Kitapcik { get; set; }
        public string Durum { get; set; }
    }

}
