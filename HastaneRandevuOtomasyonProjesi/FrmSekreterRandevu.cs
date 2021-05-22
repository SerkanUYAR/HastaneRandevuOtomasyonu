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
    public partial class FrmSekreterRandevu : Form
    {
        public FrmSekreterRandevu()
        {
            InitializeComponent();
        }
        public string HastaneAd;

        SqlBaglanti Bgl = new SqlBaglanti();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select TARİH,SAAT,DOKTOR,DURUM from Tbl_Randevu ", Bgl.Baglanti());
            DataTable Tablo0 = new DataTable();
            da.Fill(Tablo0);
            dataGridView1.DataSource = Tablo0;
        }
        private void FrmSekreterRandevu_Load(object sender, EventArgs e)
        {
            listele();
            label3.Text = HastaneAd;
        }

        
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand güncelle = new SqlCommand("update Tbl_Randevu set DURUM=@p1 ,TARİH=@p2 where   Tarih=@p4", Bgl.Baglanti()); 
            güncelle.Parameters.AddWithValue("@p1","True");
            güncelle.Parameters.AddWithValue("@p2",dateTimePicker2.Text); 
            
            güncelle.Parameters.AddWithValue("@p4",dateTimePicker1.Text); 
            try
            {
                güncelle.ExecuteNonQuery();
                MessageBox.Show("Randevu Tarih" + " " + dateTimePicker2.Text + " " + " olarak düzeltildi." + "BİLGİ" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                listele();
            }
            catch (Exception HATA)
            {
                MessageBox.Show("Hata",HATA.Message+"BİLGİ"+MessageBoxButtons.OK+MessageBoxIcon.Error);
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
