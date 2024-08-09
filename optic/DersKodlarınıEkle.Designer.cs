namespace optic
{
    partial class DersKodlarınıEkle
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
            tableLayoutPanel1 = new TableLayoutPanel();
            kitapcikCombo = new ComboBox();
            dKoduCombo = new ComboBox();
            ekleBtn = new Button();
            cevapCombo = new ComboBox();
            label1 = new Label();
            cevapSutun = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.91667F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.0833321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 415F));
            tableLayoutPanel1.Controls.Add(kitapcikCombo, 0, 1);
            tableLayoutPanel1.Controls.Add(dKoduCombo, 2, 1);
            tableLayoutPanel1.Controls.Add(ekleBtn, 2, 2);
            tableLayoutPanel1.Controls.Add(cevapCombo, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cevapSutun, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 99F));
            tableLayoutPanel1.Size = new Size(1184, 261);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // kitapcikCombo
            // 
            kitapcikCombo.Dock = DockStyle.Fill;
            kitapcikCombo.FormattingEnabled = true;
            kitapcikCombo.Location = new Point(3, 84);
            kitapcikCombo.Name = "kitapcikCombo";
            kitapcikCombo.Size = new Size(362, 29);
            kitapcikCombo.TabIndex = 0;
            // 
            // dKoduCombo
            // 
            dKoduCombo.Dock = DockStyle.Fill;
            dKoduCombo.FormattingEnabled = true;
            dKoduCombo.Location = new Point(771, 84);
            dKoduCombo.Name = "dKoduCombo";
            dKoduCombo.Size = new Size(410, 29);
            dKoduCombo.TabIndex = 1;
            // 
            // ekleBtn
            // 
            ekleBtn.Dock = DockStyle.Top;
            ekleBtn.Location = new Point(771, 165);
            ekleBtn.Name = "ekleBtn";
            ekleBtn.Size = new Size(410, 47);
            ekleBtn.TabIndex = 13;
            ekleBtn.Text = "Ekle";
            ekleBtn.UseVisualStyleBackColor = true;
            ekleBtn.Click += ekleBtn_Click;
            // 
            // cevapCombo
            // 
            cevapCombo.Dock = DockStyle.Fill;
            cevapCombo.FormattingEnabled = true;
            cevapCombo.Location = new Point(371, 84);
            cevapCombo.Name = "cevapCombo";
            cevapCombo.Size = new Size(394, 29);
            cevapCombo.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(3, 60);
            label1.Name = "label1";
            label1.Size = new Size(362, 21);
            label1.TabIndex = 15;
            label1.Text = "Kitapçık";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cevapSutun
            // 
            cevapSutun.AutoSize = true;
            cevapSutun.Dock = DockStyle.Bottom;
            cevapSutun.Location = new Point(371, 60);
            cevapSutun.Name = "cevapSutun";
            cevapSutun.Size = new Size(394, 21);
            cevapSutun.TabIndex = 16;
            cevapSutun.Text = "Cevap Sütunu";
            cevapSutun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(771, 60);
            label3.Name = "label3";
            label3.Size = new Size(410, 21);
            label3.TabIndex = 17;
            label3.Text = "Ders Kodu";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(371, 162);
            label2.Name = "label2";
            label2.Size = new Size(394, 99);
            label2.TabIndex = 18;
            label2.Text = "Optikte soldan sağa doğru kaçıncı sütunun ders kodunu ekleyeceğinizi belirtin.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 162);
            label4.Name = "label4";
            label4.Size = new Size(362, 99);
            label4.TabIndex = 19;
            label4.Text = "Optikte hangi kitapçığın işaretlendiğini belirtiniz.";
            // 
            // DersKodlarınıEkle
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 261);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "DersKodlarınıEkle";
            Text = "DersKodlarınıEkle";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label cevapSutun;
        private Label label3;
        private ComboBox kitapcikCombo;
        private ComboBox dKoduCombo;
        private Button ekleBtn;
        private ComboBox cevapCombo;
        private Label label2;
        private Label label4;
    }
}