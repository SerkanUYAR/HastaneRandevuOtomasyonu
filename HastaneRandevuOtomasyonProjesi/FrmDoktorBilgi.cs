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
    public partial class FrmDoktorBilgi : Form
    {
        public FrmDoktorBilgi()
        {
            InitializeComponent();
        }
        public string Tc;
        SqlBaglanti Bgl = new SqlBaglanti();

        private void FrmDoktorBilgi_Load(object sender, EventArgs e)
        {
            MskTc.Text = Tc;
            SqlCommand Komut = new SqlCommand("select * from Tbl_Doktorlar where TC=@p1", Bgl.Baglanti());
            Komut.Parameters.AddWithValue("@p1", Tc);
            SqlDataReader dr = Komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtBrens.Text = dr[5].ToString();
                TxtHastane.Text = dr[6].ToString();
                TxtIl.Text = dr[7].ToString();
                TxtIlce.Text = dr[8].ToString();
                LblCinsiyet.Text = dr[9].ToString();
                MskSifre.Text = dr[10].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label11.Text = "1";
            SqlCommand güncelle = new SqlCommand("update Tbl_Doktorlar set AD=@p1,SOYAD=@p2,TELEFON=@p3,SİFRE=@p4 where TC=@p5 ", Bgl.Baglanti());
            güncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            güncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", MskTelefon.Text);
            güncelle.Parameters.AddWithValue("@p4", MskSifre.Text);
            güncelle.Parameters.AddWithValue("@p5", Tc);
            güncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DoktorGiris frm = new DoktorGiris();
            frm.Show();
            this.Hide();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label11.Text=="1")
            {
                DoktorGiris frm = new DoktorGiris();
                frm.Show();
                this.Close();
            }
            if (label11.Text=="0")
            {
                DOKTOR frm = new DOKTOR();
                frm.Tc = MskTc.Text;
                frm.Ad_Soyad = TxtAd.Text + " " + TxtSoyad.Text;
                frm.Show();
                this.Close();
            }
        }
    }
}
