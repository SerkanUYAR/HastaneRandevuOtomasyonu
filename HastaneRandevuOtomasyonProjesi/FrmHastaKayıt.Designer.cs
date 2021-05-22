
namespace HastaneRandevuOtomasyonProjesi
{
    partial class FrmHastaKayıt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHastaKayıt));
            this.MskSifre = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbIlce = new System.Windows.Forms.ComboBox();
            this.CmbIl = new System.Windows.Forms.ComboBox();
            this.MskDogumTarih = new System.Windows.Forms.MaskedTextBox();
            this.MskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.MskTc = new System.Windows.Forms.MaskedTextBox();
            this.TxtSoyad = new System.Windows.Forms.TextBox();
            this.TxtAd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PctKayıt = new System.Windows.Forms.PictureBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.LblCinsiyet = new System.Windows.Forms.Label();
            this.MskMail = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnSifre = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PctKayıt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MskSifre
            // 
            this.MskSifre.Location = new System.Drawing.Point(607, 288);
            this.MskSifre.Name = "MskSifre";
            this.MskSifre.PasswordChar = '*';
            this.MskSifre.Size = new System.Drawing.Size(196, 31);
            this.MskSifre.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(511, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 42;
            this.label9.Text = "ŞİFRE";
            // 
            // CmbIlce
            // 
            this.CmbIlce.FormattingEnabled = true;
            this.CmbIlce.Location = new System.Drawing.Point(607, 241);
            this.CmbIlce.Name = "CmbIlce";
            this.CmbIlce.Size = new System.Drawing.Size(196, 31);
            this.CmbIlce.TabIndex = 38;
            // 
            // CmbIl
            // 
            this.CmbIl.FormattingEnabled = true;
            this.CmbIl.Location = new System.Drawing.Point(607, 193);
            this.CmbIl.Name = "CmbIl";
            this.CmbIl.Size = new System.Drawing.Size(196, 31);
            this.CmbIl.TabIndex = 37;
            this.CmbIl.SelectedIndexChanged += new System.EventHandler(this.CmbIl_SelectedIndexChanged);
            // 
            // MskDogumTarih
            // 
            this.MskDogumTarih.Location = new System.Drawing.Point(607, 145);
            this.MskDogumTarih.Mask = "00/00/0000";
            this.MskDogumTarih.Name = "MskDogumTarih";
            this.MskDogumTarih.Size = new System.Drawing.Size(196, 31);
            this.MskDogumTarih.TabIndex = 36;
            this.MskDogumTarih.ValidatingType = typeof(System.DateTime);
            // 
            // MskTelefon
            // 
            this.MskTelefon.Location = new System.Drawing.Point(177, 243);
            this.MskTelefon.Mask = "(999) 000-0000";
            this.MskTelefon.Name = "MskTelefon";
            this.MskTelefon.Size = new System.Drawing.Size(202, 31);
            this.MskTelefon.TabIndex = 34;
            // 
            // MskTc
            // 
            this.MskTc.Location = new System.Drawing.Point(177, 193);
            this.MskTc.Mask = "00000000000";
            this.MskTc.Name = "MskTc";
            this.MskTc.Size = new System.Drawing.Size(202, 31);
            this.MskTc.TabIndex = 33;
            this.MskTc.ValidatingType = typeof(int);
            // 
            // TxtSoyad
            // 
            this.TxtSoyad.Location = new System.Drawing.Point(177, 144);
            this.TxtSoyad.Name = "TxtSoyad";
            this.TxtSoyad.Size = new System.Drawing.Size(202, 31);
            this.TxtSoyad.TabIndex = 32;
            // 
            // TxtAd
            // 
            this.TxtAd.Location = new System.Drawing.Point(177, 99);
            this.TxtAd.Name = "TxtAd";
            this.TxtAd.Size = new System.Drawing.Size(202, 31);
            this.TxtAd.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 23);
            this.label8.TabIndex = 30;
            this.label8.Text = "İLÇE ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(538, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "İL ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "DOĞUM TARİHİ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "TELEFON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "TC KİMLİK NO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "SOYAD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "AD ";
            // 
            // PctKayıt
            // 
            this.PctKayıt.BackColor = System.Drawing.Color.Red;
            this.PctKayıt.Image = ((System.Drawing.Image)(resources.GetObject("PctKayıt.Image")));
            this.PctKayıt.Location = new System.Drawing.Point(722, 2);
            this.PctKayıt.Name = "PctKayıt";
            this.PctKayıt.Size = new System.Drawing.Size(65, 48);
            this.PctKayıt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctKayıt.TabIndex = 56;
            this.PctKayıt.TabStop = false;
            this.PctKayıt.Click += new System.EventHandler(this.PctKayıt_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(711, 95);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 27);
            this.radioButton2.TabIndex = 60;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ERKEK";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(608, 95);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 27);
            this.radioButton1.TabIndex = 59;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "KADIN";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 23);
            this.label10.TabIndex = 58;
            this.label10.Text = "CİNSİYET";
            // 
            // LblCinsiyet
            // 
            this.LblCinsiyet.AutoSize = true;
            this.LblCinsiyet.Location = new System.Drawing.Point(33, 27);
            this.LblCinsiyet.Name = "LblCinsiyet";
            this.LblCinsiyet.Size = new System.Drawing.Size(41, 23);
            this.LblCinsiyet.TabIndex = 61;
            this.LblCinsiyet.Text = "Null";
            this.LblCinsiyet.Visible = false;
            this.LblCinsiyet.Click += new System.EventHandler(this.LblCinsiyet_Click);
            // 
            // MskMail
            // 
            this.MskMail.Location = new System.Drawing.Point(177, 305);
            this.MskMail.Name = "MskMail";
            this.MskMail.Size = new System.Drawing.Size(202, 31);
            this.MskMail.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 62;
            this.label5.Text = "E POSTA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Image = global::HastaneRandevuOtomasyonProjesi.Properties.Resources.çıkış;
            this.pictureBox1.Location = new System.Drawing.Point(794, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Corbel", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(198, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(401, 42);
            this.label11.TabIndex = 66;
            this.label11.Text = "KULLANICI KAYIT PANELİ";
            // 
            // BtnSifre
            // 
            this.BtnSifre.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSifre.Location = new System.Drawing.Point(722, 325);
            this.BtnSifre.Name = "BtnSifre";
            this.BtnSifre.Size = new System.Drawing.Size(81, 24);
            this.BtnSifre.TabIndex = 67;
            this.BtnSifre.Text = "Göster";
            this.BtnSifre.UseVisualStyleBackColor = true;
            this.BtnSifre.Click += new System.EventHandler(this.button1_Click);
            this.BtnSifre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnSifre_MouseClick);
            // 
            // FrmHastaKayıt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 429);
            this.Controls.Add(this.BtnSifre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MskMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblCinsiyet);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PctKayıt);
            this.Controls.Add(this.MskSifre);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbIlce);
            this.Controls.Add(this.CmbIl);
            this.Controls.Add(this.MskDogumTarih);
            this.Controls.Add(this.MskTelefon);
            this.Controls.Add(this.MskTc);
            this.Controls.Add(this.TxtSoyad);
            this.Controls.Add(this.TxtAd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmHastaKayıt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHastaKayıt";
            this.Load += new System.EventHandler(this.FrmHastaKayıt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PctKayıt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox MskSifre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbIlce;
        private System.Windows.Forms.ComboBox CmbIl;
        private System.Windows.Forms.MaskedTextBox MskDogumTarih;
        private System.Windows.Forms.MaskedTextBox MskTelefon;
        private System.Windows.Forms.MaskedTextBox MskTc;
        private System.Windows.Forms.TextBox TxtSoyad;
        private System.Windows.Forms.TextBox TxtAd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PctKayıt;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblCinsiyet;
        private System.Windows.Forms.MaskedTextBox MskMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnSifre;
    }
}