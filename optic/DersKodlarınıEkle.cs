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
    public partial class DersKodlarınıEkle : Form
    {
        DatabaseConnection db;
        DataCrud data;
        
        public DersKodlarınıEkle(DatabaseConnection db)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            data = new DataCrud(db);
            PopulateComboBox(dKoduCombo);
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {

        }

        public void PopulateComboBox(ComboBox comboBox)
        {
            List<string> ders_kodlari = data.GetDersKoduData();
            comboBox.Items.Clear();
            foreach (var value in ders_kodlari)
            {
                comboBox.Items.Add(value);
            }
        }
    }
}
