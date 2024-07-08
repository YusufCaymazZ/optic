namespace optic
{
    public partial class opticTxt : Form
    {
        public opticTxt()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void geri_button_Click(object sender, EventArgs e)
        {
            sinav_islemleri sinav_islemleri = new sinav_islemleri();
            sinav_islemleri.Show();
            this.Close();
        }

        private void opticTxt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
