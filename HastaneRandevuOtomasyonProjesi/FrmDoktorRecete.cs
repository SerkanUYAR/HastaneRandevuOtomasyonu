using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HastaneRandevuOtomasyonProjesi
{
    public partial class FrmDoktorRecete : Form
    {
        public FrmDoktorRecete()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string DoktorAd;
        public string Brans;
        public string Hastane;
        public string DoktorTc;
        public string HastaAdSoyad;
        public string HastaTc;
        public string RandevuTarih;
        public string RandevuSaat;
        private string ReceteKodu;
        
        void Captcha_Oluşturma()
        {
            string[] sembol1 = { "a", "b", "c", "d", "e", "f", "g" };
            string[] sembol2 = { "+", "-", "/", "+", "&" };
            string[] sembol3 = { "A", "B", "C", "D", "E" };
            Random r = new Random();
            int s1, s2, s3, s4;
            s1 = r.Next(0, sembol1.Length);
            s2 = r.Next(0, sembol2.Length);
            s3 = r.Next(1, 10);
            s4 = r.Next(0, sembol3.Length);
            textBox1.Text = sembol1[s1].ToString() + sembol2[s2].ToString() + s3.ToString() + sembol3[s4].ToString();
        }
        
        private void FrmDoktorRecete_Load(object sender, EventArgs e)
        {
            label2.Text = DoktorTc;
            ReceteKodu = Convert.ToString(textBox1.Text);
            LblHastaAd.Text = HastaAdSoyad;
            LblHastaTC.Text = HastaTc;
            Captcha_Oluşturma();

            //Kategoriler:
            CmbKatagoriler.Text = "";
            DataTable Tablo0 = new DataTable();
            SqlDataAdapter Listele = new SqlDataAdapter("select Adı from Tbl_Tedaviler", Bgl.Baglanti());
            Listele.Fill(Tablo0);
            CmbKatagoriler.ValueMember = "ıd";
            CmbKatagoriler.DisplayMember = "Adı";
            CmbKatagoriler.DataSource = Tablo0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text == "1")
            {
                SqlCommand ReceteOnay = new SqlCommand("insert into Tbl_Recete (Ad_Soyad,Tc,Hastane,Doktor,Brans,Recete,Recete_Kodu,Tarih,Saat) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", Bgl.Baglanti());
                ReceteOnay.Parameters.AddWithValue("@p1", LblHastaAd.Text);
                ReceteOnay.Parameters.AddWithValue("@p2", LblHastaTC.Text);
                ReceteOnay.Parameters.AddWithValue("@p3", Hastane);
                ReceteOnay.Parameters.AddWithValue("@p4", DoktorAd);
                ReceteOnay.Parameters.AddWithValue("@p5", Brans);
                ReceteOnay.Parameters.AddWithValue("@p6", richTextBox1.Text);
                ReceteOnay.Parameters.AddWithValue("@p7", textBox1.Text);
                ReceteOnay.Parameters.AddWithValue("@p8", RandevuTarih);
                ReceteOnay.Parameters.AddWithValue("@p9", RandevuSaat);
                ReceteOnay.ExecuteNonQuery();
                MessageBox.Show("Recete Onaylandı. Recete Kodu:" + textBox1.Text + " dır.");
                label3.Text = "0";
            }
            if (label3.Text == "0")
            {
                richTextBox1.Enabled = false;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DOKTOR Frm = new DOKTOR();
            Frm.Tc = DoktorTc;
            Frm.Show();
            this.Hide();
        }

        private void CmbKatagoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ilaclar
            Cmbİlaclar.Items.Clear();
            SqlCommand Komut = new SqlCommand("select * from Tbl_Ilaclar where TedaviId=@p1", Bgl.Baglanti());
            Komut.Parameters.AddWithValue("@p1",CmbKatagoriler.SelectedIndex+1);
            SqlDataReader dr = Komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlaclar.Items.Add(dr[1]);
            }
        }

        private void Cmbİlaclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = Cmbİlaclar.Text;
        }
    }
}
