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
    public partial class HASTA : Form
    {
        public HASTA()
        {
            InitializeComponent();
        }

        SqlBaglanti Bgl = new SqlBaglanti();
        public string Tc;
        public string Ad_Soyad;

        void Randevulistele()
        { 
            LblAdSoyad.Text = Ad_Soyad;
            LblTc.Text = Tc;
            SqlCommand komut = new SqlCommand("select ıd, Hastane,Doktor,Brans,Tarih,saat,Sikayet from Tbl_KayıtlıRandevu where AdSoyad=@p1 OR Tc=@p2", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", LblAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", LblTc.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        void AdSoyad()
        { 
            SqlCommand komut0 = new SqlCommand("select AD,SOYAD from Tbl_Hastalar where Tc=@p1 ", Bgl.Baglanti());
            komut0.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut0.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1].ToString();
            }
        }

        void Randevuİptali()
        {
            SqlCommand komut0 = new SqlCommand("DELETE From Tbl_KayıtlıRandevu where ıd=@p1", Bgl.Baglanti());
            komut0.Parameters.AddWithValue("@p1", LbkRandevuId.Text);
            try
            {
                komut0.ExecuteNonQuery();
                MessageBox.Show("Randevu Kaydınız Silindi", "UYAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Randevu silinirken bir hata oluştu. Tekrar deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void RandevuIptaliGüncelle()
        { 
            SqlCommand komut1 = new SqlCommand("UPDATE Tbl_Randevu set DURUM=@p1 where ıd=@p2", Bgl.Baglanti());
            komut1.Parameters.AddWithValue("@p1", "True");
            komut1.Parameters.AddWithValue("@p2", LbkRandevuId.Text);
            try
            {
                komut1.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Randevu silinirken bir hata oluştu. Tekrar deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void HASTA_Load(object sender, EventArgs e)
        {
            LblAdSoyad.Text = Ad_Soyad;
            LblTc.Text = Tc;
            Randevulistele();
            AdSoyad(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandevuIptaliGüncelle();
            Randevuİptali();
            Randevulistele();
            BtnRandevuIptali.Visible = false;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRandevuAra Frm = new FrmRandevuAra();
            Frm.tckimlikno = LblTc.Text;
            Frm.adsoyad = LblAdSoyad.Text;
            Frm.Show();
            this.Hide();
        }

       
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaRecete frm = new FrmHastaRecete();
            frm.Tc = LblTc.Text;
            frm.AdSoyad = LblAdSoyad.Text;
            frm.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaGüncelle frm = new HastaGüncelle();
            frm.Tc = Tc;
            frm.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tut = dataGridView1.SelectedCells[0].RowIndex;
            LbkRandevuId.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            BtnRandevuIptali.Visible = true;
        }
    }
}
