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
    public partial class FrmHastaKayıt : Form
    {
        public FrmHastaKayıt()
        {
            InitializeComponent();
        }

        SqlBaglanti Bgl = new SqlBaglanti();
        bool durum;

        void TekrarEngenleme()
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where TC=@k3",Bgl.Baglanti());
            komut.Parameters.AddWithValue("@k3",MskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
        }

        private void PctKayıt_Click(object sender, EventArgs e)
        {
            TekrarEngenleme();
            if (durum==true)
            {
                SqlCommand Kaydet = new SqlCommand("insert into Tbl_Hastalar (AD, SOYAD, TC, TELEFON, ŞİFRE, CİNSİYET, DTAR, İL, İLCE,MAİL  )values (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10)", Bgl.Baglanti());
                Kaydet.Parameters.AddWithValue("@k1", TxtAd.Text);
                Kaydet.Parameters.AddWithValue("@k2", TxtSoyad.Text);
                Kaydet.Parameters.AddWithValue("@k3", MskTc.Text);
                Kaydet.Parameters.AddWithValue("@k4", MskTelefon.Text);
                Kaydet.Parameters.AddWithValue("@k5", MskSifre.Text);
                Kaydet.Parameters.AddWithValue("@k6", LblCinsiyet.Text);
                Kaydet.Parameters.AddWithValue("@k7", MskDogumTarih.Text);
                Kaydet.Parameters.AddWithValue("@k8", CmbIl.Text);
                Kaydet.Parameters.AddWithValue("@k9", CmbIlce.Text);
                Kaydet.Parameters.AddWithValue("@k10", MskMail.Text);
                Kaydet.ExecuteNonQuery();
                Bgl.Baglanti().Close();
                MessageBox.Show("Kayıt Basarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FrmHastaKayıt_Load(object sender, EventArgs e)
        {
            
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select SehirAd from Tbl_Iller", Bgl.Baglanti());
            da.Fill(tablo);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SehirAd";
            CmbIl.DataSource = tablo;
        }
        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ilceler  where sehirid=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex +1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Items.Add(dr[1]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                LblCinsiyet.Text = "KADIN";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                LblCinsiyet.Text = "ERKEK";
            }
        }

        private void BtnSifre_MouseClick(object sender, MouseEventArgs e)
        {
            if (BtnSifre.Text=="Göster")
            {
                MskSifre.PasswordChar = '\0';
                BtnSifre.Text = "Gizle";
            }
            else
            {
                BtnSifre.Text="Gizle";
                MskSifre.PasswordChar = '*';
                BtnSifre.Text = "Göster";
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        } 

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LblCinsiyet_Click(object sender, EventArgs e)
        { }
    }
}
