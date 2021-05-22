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
    public partial class FrmRandevuAra : Form
    {
        public FrmRandevuAra()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string tckimlikno;
        public string adsoyad;

        void Temizle()
        {
            CmbIL.Text = " ";
            CmbIlce.Text = " ";
            CmbHastane.Text = " ";
            CmbBrans.Text = " ";
            CmbDoktor.Text = " ";
        }

        private void FrmRandevuAra_Load(object sender, EventArgs e)
        {
            msktc.Text = tckimlikno;
            TxtAdSoyad.Text = adsoyad;

           
            CmbIlce.Items.Clear();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select SehirAd from Tbl_Iller", Bgl.Baglanti());
            da.Fill(tablo);
            CmbIL.ValueMember = "ID";
            CmbIL.DisplayMember = "SehirAd";
            CmbIL.DataSource = tablo;
        }

        private void CmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CmbIlce.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ilceler  where sehirid=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                CmbIlce.Items.Add(dr[1]);
            }
        }

        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            CmbHastane.Items.Clear();
            SqlCommand komuth = new SqlCommand("select hastaneadi from Tbl_Hastaneler where ilceadi=@p1", Bgl.Baglanti());
            komuth.Parameters.AddWithValue("@p1", CmbIlce.Text.ToString());
            SqlDataReader dr = komuth.ExecuteReader();
            while (dr.Read())
            {
                CmbHastane.Items.Add(dr[0]);
            }
        }

        private void CmbHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CmbBrans.Items.Clear();
            SqlCommand komut = new SqlCommand("select distinct BRANS from Tbl_Doktorlar where HASTANE=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", CmbHastane.Text.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbBrans.Items.Add(dr[0]);
            }
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CmbDoktor.Items.Clear();
            SqlCommand Komut = new SqlCommand("select AD,SOYAD from Tbl_Doktorlar where BRANS=@p1 and HASTANE=@p2", Bgl.Baglanti());
            Komut.Parameters.AddWithValue("@p1", CmbBrans.Text.ToString());
            Komut.Parameters.AddWithValue("@p2", CmbHastane.Text.ToString());
            SqlDataReader dr = Komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            SqlCommand komutara = new SqlCommand("select ID,BRANS,DOKTOR,HASTANE,TARİH,SAAT from Tbl_Randevu where Doktor=@p1 And TARİH=@p2 And Durum=@p3", Bgl.Baglanti());
            komutara.Parameters.AddWithValue("@p1", CmbDoktor.Text);
            komutara.Parameters.AddWithValue("@p2", dateTimePicker1.Text.ToString());
            komutara.Parameters.AddWithValue("@p3", LblRanduvuDurum.Text); 
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komutara); 
            DataTable Tablo = new DataTable(); 
            dataAdapter.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            FrmRandevuKayıt frm = new FrmRandevuKayıt(); 
            int aktar = dataGridView1.SelectedCells[0].RowIndex;
            frm.RandevuId = dataGridView1.Rows[aktar].Cells[0].Value.ToString();  
            frm.doktor = dataGridView1.Rows[aktar].Cells[2].Value.ToString();
            frm.hastane = dataGridView1.Rows[aktar].Cells[3].Value.ToString();
            frm.brans = dataGridView1.Rows[aktar].Cells[1].Value.ToString();
            frm.tarih = dataGridView1.Rows[aktar].Cells[4].Value.ToString();
            frm.saat = dataGridView1.Rows[aktar].Cells[5].Value.ToString();
            frm.Tckim = msktc.Text;
            frm.AdSoyad = TxtAdSoyad.Text;
            frm.Show();
            this.Close();
            Temizle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HASTA frm = new HASTA();
            frm.Tc = msktc.Text;
            frm.Ad_Soyad = TxtAdSoyad.Text;
            frm.Show();
            this.Close();
        }
    }
}
