namespace optic
{
    partial class DersIslemleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DersIslemleri));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ogrEkleGuncelle = new Button();
            ogrListele = new Button();
            ogrGetirBtn = new Button();
            ogrExcellBtn = new Button();
            ogrNum = new TextBox();
            ogrAd = new TextBox();
            ogrSoyadi = new TextBox();
            ogrGetirTxt = new TextBox();
            ogr_num = new Label();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            ogrDersKoduTxt = new TextBox();
            ogrListSil = new Button();
            tableLayoutPanel8 = new TableLayoutPanel();
            dersListele = new Button();
            dersGetir = new Button();
            dersKodu = new TextBox();
            programAdi = new TextBox();
            dersAdi = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            getirilecekDers = new TextBox();
            dersEkle = new Button();
            dersExcell = new Button();
            geriButton = new Button();
            dersSilButton = new Button();
            dersDataGrid = new DataGridView();
            ogrDataGrid = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dersDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ogrDataGrid).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel8, 0, 1);
            tableLayoutPanel1.Controls.Add(dersDataGrid, 1, 1);
            tableLayoutPanel1.Controls.Add(ogrDataGrid, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1184, 661);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.82594F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.17406F));
            tableLayoutPanel2.Controls.Add(ogrEkleGuncelle, 1, 6);
            tableLayoutPanel2.Controls.Add(ogrListele, 1, 0);
            tableLayoutPanel2.Controls.Add(ogrGetirBtn, 1, 1);
            tableLayoutPanel2.Controls.Add(ogrExcellBtn, 0, 6);
            tableLayoutPanel2.Controls.Add(ogrNum, 1, 2);
            tableLayoutPanel2.Controls.Add(ogrAd, 1, 3);
            tableLayoutPanel2.Controls.Add(ogrSoyadi, 1, 4);
            tableLayoutPanel2.Controls.Add(ogrGetirTxt, 0, 1);
            tableLayoutPanel2.Controls.Add(ogr_num, 0, 2);
            tableLayoutPanel2.Controls.Add(label5, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 0, 4);
            tableLayoutPanel2.Controls.Add(label4, 0, 5);
            tableLayoutPanel2.Controls.Add(ogrDersKoduTxt, 1, 5);
            tableLayoutPanel2.Controls.Add(ogrListSil, 1, 7);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 9;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 46.1538467F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 53.8461533F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(586, 324);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // ogrEkleGuncelle
            // 
            ogrEkleGuncelle.Dock = DockStyle.Fill;
            ogrEkleGuncelle.Location = new Point(336, 213);
            ogrEkleGuncelle.Name = "ogrEkleGuncelle";
            ogrEkleGuncelle.Size = new Size(247, 36);
            ogrEkleGuncelle.TabIndex = 15;
            ogrEkleGuncelle.Text = "Öğr. Ekle veya Güncelle";
            ogrEkleGuncelle.UseVisualStyleBackColor = true;
            ogrEkleGuncelle.Click += ogrEkleGuncelle_Click;
            // 
            // ogrListele
            // 
            ogrListele.Dock = DockStyle.Fill;
            ogrListele.Location = new Point(336, 3);
            ogrListele.Name = "ogrListele";
            ogrListele.Size = new Size(247, 30);
            ogrListele.TabIndex = 0;
            ogrListele.Text = "Öğrenci Listele";
            ogrListele.UseVisualStyleBackColor = true;
            ogrListele.Click += ogrListele_Click;
            // 
            // ogrGetirBtn
            // 
            ogrGetirBtn.Dock = DockStyle.Fill;
            ogrGetirBtn.Location = new Point(336, 39);
            ogrGetirBtn.Name = "ogrGetirBtn";
            ogrGetirBtn.Size = new Size(247, 36);
            ogrGetirBtn.TabIndex = 1;
            ogrGetirBtn.Text = "Öğreci Getir";
            ogrGetirBtn.UseVisualStyleBackColor = true;
            ogrGetirBtn.Click += ogrGetirBtn_Click;
            // 
            // ogrExcellBtn
            // 
            ogrExcellBtn.Dock = DockStyle.Fill;
            ogrExcellBtn.Location = new Point(3, 213);
            ogrExcellBtn.Name = "ogrExcellBtn";
            ogrExcellBtn.Size = new Size(327, 36);
            ogrExcellBtn.TabIndex = 4;
            ogrExcellBtn.Text = "Öğrenci Excell Ekle";
            ogrExcellBtn.UseVisualStyleBackColor = true;
            ogrExcellBtn.Click += ogrExcellBtn_Click;
            // 
            // ogrNum
            // 
            ogrNum.Dock = DockStyle.Fill;
            ogrNum.Location = new Point(336, 81);
            ogrNum.Name = "ogrNum";
            ogrNum.Size = new Size(247, 27);
            ogrNum.TabIndex = 5;
            // 
            // ogrAd
            // 
            ogrAd.Dock = DockStyle.Fill;
            ogrAd.Location = new Point(336, 113);
            ogrAd.Name = "ogrAd";
            ogrAd.Size = new Size(247, 27);
            ogrAd.TabIndex = 6;
            // 
            // ogrSoyadi
            // 
            ogrSoyadi.Dock = DockStyle.Fill;
            ogrSoyadi.Location = new Point(336, 146);
            ogrSoyadi.Name = "ogrSoyadi";
            ogrSoyadi.Size = new Size(247, 27);
            ogrSoyadi.TabIndex = 7;
            // 
            // ogrGetirTxt
            // 
            ogrGetirTxt.Dock = DockStyle.Fill;
            ogrGetirTxt.Location = new Point(3, 39);
            ogrGetirTxt.Name = "ogrGetirTxt";
            ogrGetirTxt.Size = new Size(327, 27);
            ogrGetirTxt.TabIndex = 8;
            ogrGetirTxt.Text = "Getirilecek öğrencinin numarasını buraya yazınız.";
            ogrGetirTxt.Click += ogrGetirTxt_Click;
            // 
            // ogr_num
            // 
            ogr_num.AutoSize = true;
            ogr_num.Dock = DockStyle.Fill;
            ogr_num.Location = new Point(3, 78);
            ogr_num.Name = "ogr_num";
            ogr_num.Size = new Size(327, 32);
            ogr_num.TabIndex = 9;
            ogr_num.Text = "Öğrenci Numarası";
            ogr_num.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 110);
            label5.Name = "label5";
            label5.Size = new Size(327, 33);
            label5.TabIndex = 10;
            label5.Text = "Öğrenci Adı";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 143);
            label6.Name = "label6";
            label6.Size = new Size(327, 34);
            label6.TabIndex = 11;
            label6.Text = "Öğrenci Soyadı";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 177);
            label4.Name = "label4";
            label4.Size = new Size(327, 33);
            label4.TabIndex = 12;
            label4.Text = "Ders Kodu";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ogrDersKoduTxt
            // 
            ogrDersKoduTxt.Dock = DockStyle.Fill;
            ogrDersKoduTxt.Location = new Point(336, 180);
            ogrDersKoduTxt.Name = "ogrDersKoduTxt";
            ogrDersKoduTxt.Size = new Size(247, 27);
            ogrDersKoduTxt.TabIndex = 13;
            // 
            // ogrListSil
            // 
            ogrListSil.Dock = DockStyle.Fill;
            ogrListSil.Location = new Point(336, 255);
            ogrListSil.Name = "ogrListSil";
            ogrListSil.Size = new Size(247, 31);
            ogrListSil.TabIndex = 16;
            ogrListSil.Text = "Öğrenci Listesini Sil";
            ogrListSil.UseVisualStyleBackColor = true;
            ogrListSil.Click += ogrListSil_Click;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.06826F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.93174F));
            tableLayoutPanel8.Controls.Add(dersListele, 1, 0);
            tableLayoutPanel8.Controls.Add(dersGetir, 1, 1);
            tableLayoutPanel8.Controls.Add(dersKodu, 1, 2);
            tableLayoutPanel8.Controls.Add(programAdi, 1, 3);
            tableLayoutPanel8.Controls.Add(dersAdi, 1, 4);
            tableLayoutPanel8.Controls.Add(label2, 0, 3);
            tableLayoutPanel8.Controls.Add(label3, 0, 4);
            tableLayoutPanel8.Controls.Add(label1, 0, 2);
            tableLayoutPanel8.Controls.Add(getirilecekDers, 0, 1);
            tableLayoutPanel8.Controls.Add(dersEkle, 1, 5);
            tableLayoutPanel8.Controls.Add(dersExcell, 0, 6);
            tableLayoutPanel8.Controls.Add(geriButton, 1, 6);
            tableLayoutPanel8.Controls.Add(dersSilButton, 0, 5);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 333);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 8;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50.63291F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 49.36709F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Size = new Size(586, 325);
            tableLayoutPanel8.TabIndex = 3;
            // 
            // dersListele
            // 
            dersListele.Dock = DockStyle.Fill;
            dersListele.Location = new Point(355, 3);
            dersListele.Name = "dersListele";
            dersListele.Size = new Size(228, 34);
            dersListele.TabIndex = 0;
            dersListele.Text = "Listele";
            dersListele.UseVisualStyleBackColor = true;
            dersListele.Click += dersListele_Click;
            // 
            // dersGetir
            // 
            dersGetir.Dock = DockStyle.Fill;
            dersGetir.Location = new Point(355, 43);
            dersGetir.Name = "dersGetir";
            dersGetir.Size = new Size(228, 33);
            dersGetir.TabIndex = 1;
            dersGetir.Text = "Dersi Getir";
            dersGetir.UseVisualStyleBackColor = true;
            dersGetir.Click += dersGetir_Click;
            // 
            // dersKodu
            // 
            dersKodu.Dock = DockStyle.Fill;
            dersKodu.Location = new Point(355, 82);
            dersKodu.Name = "dersKodu";
            dersKodu.Size = new Size(228, 27);
            dersKodu.TabIndex = 2;
            // 
            // programAdi
            // 
            programAdi.Dock = DockStyle.Fill;
            programAdi.Location = new Point(355, 115);
            programAdi.Name = "programAdi";
            programAdi.Size = new Size(228, 27);
            programAdi.TabIndex = 3;
            // 
            // dersAdi
            // 
            dersAdi.Dock = DockStyle.Fill;
            dersAdi.Location = new Point(355, 151);
            dersAdi.Name = "dersAdi";
            dersAdi.Size = new Size(228, 27);
            dersAdi.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 112);
            label2.Name = "label2";
            label2.Size = new Size(346, 36);
            label2.TabIndex = 6;
            label2.Text = "Program Adı:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 148);
            label3.Name = "label3";
            label3.Size = new Size(346, 35);
            label3.TabIndex = 7;
            label3.Text = "Ders Adı:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 79);
            label1.Name = "label1";
            label1.Size = new Size(346, 33);
            label1.TabIndex = 5;
            label1.Text = "Ders Kodu:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // getirilecekDers
            // 
            getirilecekDers.Dock = DockStyle.Fill;
            getirilecekDers.Location = new Point(3, 43);
            getirilecekDers.Name = "getirilecekDers";
            getirilecekDers.Size = new Size(346, 27);
            getirilecekDers.TabIndex = 8;
            getirilecekDers.Text = "Getirilecek dersin kodunu buraya yazınız.";
            getirilecekDers.Click += textBox4_Click;
            // 
            // dersEkle
            // 
            dersEkle.Dock = DockStyle.Fill;
            dersEkle.Location = new Point(355, 186);
            dersEkle.Name = "dersEkle";
            dersEkle.Size = new Size(228, 37);
            dersEkle.TabIndex = 9;
            dersEkle.Text = "Ekle veya Güncelle";
            dersEkle.UseVisualStyleBackColor = true;
            dersEkle.Click += dersEkle_Click;
            // 
            // dersExcell
            // 
            dersExcell.Dock = DockStyle.Fill;
            dersExcell.Location = new Point(3, 229);
            dersExcell.Name = "dersExcell";
            dersExcell.Size = new Size(346, 36);
            dersExcell.TabIndex = 10;
            dersExcell.Text = "Ders Excell Ekle";
            dersExcell.UseVisualStyleBackColor = true;
            dersExcell.Click += dersExcell_Click;
            // 
            // geriButton
            // 
            geriButton.Dock = DockStyle.Fill;
            geriButton.Location = new Point(355, 229);
            geriButton.Name = "geriButton";
            geriButton.Size = new Size(228, 36);
            geriButton.TabIndex = 11;
            geriButton.Text = "Geri";
            geriButton.UseVisualStyleBackColor = true;
            geriButton.Click += geriButton_Click_1;
            // 
            // dersSilButton
            // 
            dersSilButton.Dock = DockStyle.Fill;
            dersSilButton.Location = new Point(3, 186);
            dersSilButton.Name = "dersSilButton";
            dersSilButton.Size = new Size(346, 37);
            dersSilButton.TabIndex = 12;
            dersSilButton.Text = "Dersi Sil";
            dersSilButton.UseVisualStyleBackColor = true;
            dersSilButton.Click += dersSilButton_Click;
            // 
            // dersDataGrid
            // 
            dersDataGrid.BackgroundColor = Color.Navy;
            dersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dersDataGrid.Dock = DockStyle.Fill;
            dersDataGrid.Location = new Point(595, 333);
            dersDataGrid.Name = "dersDataGrid";
            dersDataGrid.Size = new Size(586, 325);
            dersDataGrid.TabIndex = 4;
            dersDataGrid.RowPostPaint += dersDataGrid_RowPostPaint;
            // 
            // ogrDataGrid
            // 
            ogrDataGrid.BackgroundColor = Color.Navy;
            ogrDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ogrDataGrid.Dock = DockStyle.Fill;
            ogrDataGrid.Location = new Point(595, 3);
            ogrDataGrid.Name = "ogrDataGrid";
            ogrDataGrid.Size = new Size(586, 324);
            ogrDataGrid.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // DersIslemleri
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "DersIslemleri";
            Text = "Ders İşlemleri";
            FormClosing += DersIslemleri_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dersDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ogrDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel8;
        private DataGridView dersDataGrid;
        private Button dersListele;
        private Button dersGetir;
        private TextBox dersKodu;
        private TextBox programAdi;
        private TextBox dersAdi;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox getirilecekDers;
        private Button dersEkle;
        private TableLayoutPanel tableLayoutPanel2;
        private OpenFileDialog openFileDialog1;
        private Button dersExcell;
        private Button geriButton;
        private Button ogrListele;
        private Button ogrGetirBtn;
        private Button button6;
        private Button ogrExcellBtn;
        private TextBox ogrNum;
        private TextBox ogrAd;
        private TextBox ogrSoyadi;
        private TextBox ogrGetirTxt;
        private Label ogr_num;
        private Label label5;
        private Label label6;
        private DataGridView ogrDataGrid;
        private Button ogrEkleGuncelle;
        private Label label4;
        private TextBox ogrDersKoduTxt;
        private Button ogrListSil;
        private Button dersSilButton;
    }
}