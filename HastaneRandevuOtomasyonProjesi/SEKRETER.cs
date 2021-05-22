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
    public partial class SEKRETER : Form
    {
        public SEKRETER()
        {
            InitializeComponent();
        }

        public string Tc;
        public string hastaneadi;
        public string SekreterAd;

        SqlBaglanti Bgl = new SqlBaglanti();

        void Duyurular()
        {
            label2.Text = dateTimePicker1.Text; 
            SqlCommand DuyuruListesi = new SqlCommand("select Baslık,Duyuru,Tarih,Saat from Tbl_Duyurular where HastaneAd ='" + LblHastaneAdi.Text+ "' AND Tarih='" + label2.Text + "'", Bgl.Baglanti()); //sql deki duyurular tarihe göre cekme
            SqlDataAdapter da = new SqlDataAdapter(DuyuruListesi);
            DataTable Tablo = new DataTable();
            da.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
        }

        void SekreterBilgileri()
        {
            SqlCommand Bilgiler = new SqlCommand("select AD,SOYAD,HASTANE From Tbl_Sekreter where TC=@p1", Bgl.Baglanti());
            Bilgiler.Parameters.AddWithValue("@p1", Tc);
            SqlDataReader dr = Bilgiler.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1]; 
                LblHastaneAdi.Text = dr[2].ToString();
            }
        }
        private void SEKRETER_Load(object sender, EventArgs e)
        {
            hastaneadi = LblHastaneAdi.Text;
            LblKullanıcıAdı.Text = Tc;
            SekreterBilgileri();
            Duyurular();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSekreterDuyuru frm = new FrmSekreterDuyuru();
            frm.Hastane = LblHastaneAdi.Text;
            frm.Sekreter = LblAdSoyad.Text;
            frm.TcD = LblKullanıcıAdı.Text;
            frm.Show();
            this.Hide();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSekreterRandevu frm = new FrmSekreterRandevu();
            frm.HastaneAd = LblHastaneAdi.Text;
            frm.Show();
        }

       
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSekreterDoktor frm = new FrmSekreterDoktor();
            frm.hastane = LblHastaneAdi.Text;
            frm.Show();
           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSekreterMail frm = new FrmSekreterMail();
            frm.Hastane = LblHastaneAdi.Text;
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = dateTimePicker1.Text;
            Duyurular();
        }
    }
}
