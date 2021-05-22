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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti Bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand Giris = new SqlCommand("Select * From Tbl_Hastalar where Tc=@p1 and ŞİFRE=@p2", Bgl.Baglanti());
            Giris.Parameters.AddWithValue("@p1", MskKullaniciad.Text);
            Giris.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = Giris.ExecuteReader();
            if (dr.Read())
            {
                HASTA frm = new HASTA();
                frm.Tc = MskKullaniciad.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Bgl.Baglanti().Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            AnaForm frm = new AnaForm();
            frm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıt frm = new FrmHastaKayıt();
            frm.Show();
        }
    }
}
