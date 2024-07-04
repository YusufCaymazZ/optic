namespace optic
{
    partial class Ana_Sayfa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ana_Sayfa));
            tableLayoutPanel1 = new TableLayoutPanel();
            ders_btn = new Button();
            sinav_btn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49F));
            tableLayoutPanel1.Controls.Add(ders_btn, 0, 0);
            tableLayoutPanel1.Controls.Add(sinav_btn, 0, 1);
            tableLayoutPanel1.Location = new Point(450, 249);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(259, 136);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // ders_btn
            // 
            ders_btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ders_btn.Location = new Point(3, 3);
            ders_btn.Name = "ders_btn";
            ders_btn.Size = new Size(253, 62);
            ders_btn.TabIndex = 0;
            ders_btn.Text = "Ders İşlemleri";
            ders_btn.UseVisualStyleBackColor = true;
            // 
            // sinav_btn
            // 
            sinav_btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sinav_btn.Location = new Point(3, 71);
            sinav_btn.Name = "sinav_btn";
            sinav_btn.Size = new Size(253, 62);
            sinav_btn.TabIndex = 1;
            sinav_btn.Text = "Sınav İşlemleri";
            sinav_btn.UseVisualStyleBackColor = true;
            sinav_btn.Click += sinav_btn_Click_1;
            // 
            // Ana_Sayfa
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 661);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1200, 700);
            Name = "Ana_Sayfa";
            Text = "Ana Sayfa";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button ders_islem_btn;
        private Button sinav_islem_btn;
        private TableLayoutPanel tableLayoutPanel1;
        private Button ders_btn;
        private Button sinav_btn;
    }
}
