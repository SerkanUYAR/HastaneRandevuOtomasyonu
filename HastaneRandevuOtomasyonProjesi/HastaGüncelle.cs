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
    public partial class HastaGüncelle : Form
    {
        public HastaGüncelle()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string Tc;
        

        private void HastaGüncelle_Load(object sender, EventArgs e)
        {
            TxtTc.Text = Tc;
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where Tc=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", Tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                MskSifre.Text = dr[5].ToString();
                LblCinsiyet.Text = dr[6].ToString();
                MskDogum.Text = dr[7].ToString();
                Txtİl.Text = dr[8].ToString();
                TxtIlce.Text = dr[9].ToString();
                TxtMail.Text = dr[10].ToString();
            }
            if (LblCinsiyet.Text=="KADIN")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;   
            }
        }

        private void LblCinsiyet_Click(object sender, EventArgs e)
        {
            if (LblCinsiyet.Text == "KADIN")
            {
                radioButton1.Checked = true;
            }
            if (LblCinsiyet.Text == "ERKEK")
            {
                radioButton2.Checked = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label11.Text = "1"; 
            SqlCommand güncelle = new SqlCommand("update Tbl_Hastalar set AD=@p1,SOYAD=@p2,TELEFON=@p3,ŞİFRE=@p4,İL=@p5,İlce=@p6,MAİL=@p7 where Tc=@p8 ", Bgl.Baglanti());
            güncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            güncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", MskTelefon.Text);
            güncelle.Parameters.AddWithValue("@p4", MskSifre.Text);
            güncelle.Parameters.AddWithValue("@p5", Txtİl.Text);
            güncelle.Parameters.AddWithValue("@p6", TxtIlce.Text);
            güncelle.Parameters.AddWithValue("@p7", TxtMail.Text);
            güncelle.Parameters.AddWithValue("@p8", TxtTc.Text);
            güncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label11.Text == "0")
            {
                HASTA frm = new HASTA();
                frm.Tc = TxtTc.Text;
                frm.Ad_Soyad = TxtAd.Text + " " + TxtSoyad.Text;
                frm.Show();
                this.Close();
            }
            if (label11.Text == "1")
            {
                HastaGiris frm = new HastaGiris();
                frm.Show();
                this.Hide();
            }
        }
    }
}
