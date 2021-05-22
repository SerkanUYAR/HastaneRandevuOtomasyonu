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
    public partial class FrmSekreterDuyuru : Form
    {
        public FrmSekreterDuyuru()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string Hastane;
        public string Sekreter;
        public string TcD;
        string DuyuruId;

        void Temizle()
        {
            CmbBaslıklar.Text = " ";
            MskTarih.Clear();
            MskSaat.Clear();
            richTextBox1.Clear();
        }

        void Listele()
        {
            SqlCommand DuyuruListe = new SqlCommand("select * from Tbl_Duyurular where SekreterAd=@p1", Bgl.Baglanti());
            DuyuruListe.Parameters.AddWithValue("@p1", LblSekreter.Text);
            SqlDataAdapter da = new SqlDataAdapter(DuyuruListe);
            DataTable Tablo = new DataTable();
            da.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
        }

        void DuyuruYayınla()
        {
            SqlCommand duyuru = new SqlCommand("insert into Tbl_duyurular (Baslık,Duyuru,Tarih,Saat,HastaneAd,SekreterAd) values (@d1,@d2,@d3,@d4,@d5,@d6)", Bgl.Baglanti());
            duyuru.Parameters.AddWithValue("@d1", CmbBaslıklar.Text);
            duyuru.Parameters.AddWithValue("@d2", richTextBox1.Text);
            duyuru.Parameters.AddWithValue("@d3", MskTarih.Text);
            duyuru.Parameters.AddWithValue("@d4", MskSaat.Text);
            duyuru.Parameters.AddWithValue("@d5", Hastane);
            duyuru.Parameters.AddWithValue("@d6", Sekreter);
            try
            {
                duyuru.ExecuteNonQuery();
                MessageBox.Show("Duyutu Yayınlandı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            catch (Exception HATA)
            {

                MessageBox.Show("Duyuru Yayınlanamadı" + HATA.Message + "HATA" + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
        }

        void DuyuruBaslıkları()
        {
            SqlCommand Baslık = new SqlCommand("select DISTINCT Baslık from Tbl_Duyurular ", Bgl.Baglanti());
            SqlDataReader dr = Baslık.ExecuteReader();
            while (dr.Read())
            {
                CmbBaslıklar.Items.Add(dr[0].ToString());
            }
        }

        void DuyuruGüncelle()
        {
            SqlCommand KomutGüncelle = new SqlCommand("Update Tbl_Duyurular Set Baslık=@p1,Duyuru=@p2,Tarih=@p3,Saat=@p4 where ıd=@p5", Bgl.Baglanti());
            KomutGüncelle.Parameters.AddWithValue("@p1", CmbBaslıklar.Text);
            KomutGüncelle.Parameters.AddWithValue("@p2", richTextBox1.Text);
            KomutGüncelle.Parameters.AddWithValue("@p3", MskTarih.Text);
            KomutGüncelle.Parameters.AddWithValue("@p4", MskSaat.Text);
            KomutGüncelle.Parameters.AddWithValue("@p5", DuyuruId);
            KomutGüncelle.ExecuteNonQuery();
            MessageBox.Show(MskTarih.Text + " " + MskSaat.Text + " " + "Tarihli duyuru Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void DuyuruSil()
        {
            SqlCommand KomutSil = new SqlCommand("delete From Tbl_Duyurular where ıd=@p1", Bgl.Baglanti());
            KomutSil.Parameters.AddWithValue("@p1", DuyuruId);
            KomutSil.ExecuteNonQuery();
            MessageBox.Show(MskTarih.Text + " " + MskSaat.Text + " " + " Tarihli Duyuru Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmSekreterDuyuru_Load(object sender, EventArgs e)
        {
            LblHastane.Text = Hastane;
            LblSekreter.Text = Sekreter;
            Listele();
            DuyuruBaslıkları();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            int Tası = dataGridView1.SelectedCells[0].RowIndex;
            DuyuruId = dataGridView1.Rows[Tası].Cells[0].Value.ToString();
            CmbBaslıklar.Text = dataGridView1.Rows[Tası].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[Tası].Cells[2].Value.ToString();
            MskTarih.Text = dataGridView1.Rows[Tası].Cells[3].Value.ToString();
            MskSaat.Text = dataGridView1.Rows[Tası].Cells[4].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  
        {
            SEKRETER frm = new SEKRETER();
            frm.Tc = TcD;
            frm.Show();
            this.Hide();
        }
        
        private void pictureBox2_Click(object sender, EventArgs e) 
        {
            DuyuruYayınla();
        }

        private void pictureBox4_Click(object sender, EventArgs e) 
        {
            
            DuyuruGüncelle();
            Listele();
            Temizle();
        }

        private void pictureBox3_Click(object sender, EventArgs e) 
        {
            DuyuruSil();
            Listele();
            Temizle();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Temizle();
        } 
    }
}
