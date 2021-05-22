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
    public partial class DOKTOR : Form
    {
        public DOKTOR()
        {
            InitializeComponent();
        }
        public string Tc;
        public string Ad_Soyad;
        public string hastane;
        public string Tarih;

        SqlBaglanti Bgl = new SqlBaglanti();

        void DoktorBilgi()
        {
            SqlCommand DoktoBilgi = new SqlCommand(" select * From Tbl_Doktorlar where Tc=@p1",Bgl.Baglanti());
            DoktoBilgi.Parameters.AddWithValue("@p1",Tc);
            SqlDataReader dr = DoktoBilgi.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[1] + " " + dr[2].ToString();
                label2.Text = dr[7].ToString();
                label4.Text = dr[6].ToString();
            } 
        }

        void Hastalistesi()
        {
            SqlCommand HasListesi = new SqlCommand("select AdSoyad,Tc,Tarih,Saat,Sikayet from Tbl_kayıtlıRandevu  where Doktor='"+LblAdSoyad.Text +"' And Tarih='"+LblTarih.Text +"'", Bgl.Baglanti());
            SqlDataAdapter da = new SqlDataAdapter(HasListesi);
            DataTable Tablo0 = new DataTable();
            da.Fill(Tablo0);
            dataGridView1.DataSource = Tablo0;
            label5.Text = "RANDEVU LİSTESİ";
        }
       
        private void DOKTOR_Load(object sender, EventArgs e)
        {
            label2.Text = hastane;
            LblTc.Text = Tc;
            LblTarih.Text = dateTimePicker1.Text;
            DoktorBilgi();
            Hastalistesi(); 
        }
       
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlCommand komut = new SqlCommand("select  Baslık,Duyuru,Tarih,Saat from Tbl_Duyurular where HastaneAd=@p1 And Tarih=@p2", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", label2.Text);
            komut.Parameters.AddWithValue("@p2", dateTimePicker1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable Tablo = new DataTable();
            da.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
            label5.Text = "DUYURU LİSTESİ";
            linkLabel1.Visible= true;
            pictureBox1.Visible = true;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoktorBilgi frm = new FrmDoktorBilgi();
            frm.Tc = Tc;
            frm.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LblTarih.Text = dateTimePicker1.Text;
            Hastalistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (label5.Text== "RANDEVU LİSTESİ")
            {
                int HastaBilgiAktar = dataGridView1.SelectedCells[0].RowIndex;
                FrmDoktorRecete Frm = new FrmDoktorRecete();
                Frm.HastaAdSoyad = dataGridView1.Rows[HastaBilgiAktar].Cells[0].Value.ToString();
                Frm.HastaTc = dataGridView1.Rows[HastaBilgiAktar].Cells[1].Value.ToString();
                Frm.RandevuTarih = dataGridView1.Rows[HastaBilgiAktar].Cells[2].Value.ToString();
                Frm.RandevuSaat = dataGridView1.Rows[HastaBilgiAktar].Cells[3].Value.ToString();
                Frm.DoktorAd = LblAdSoyad.Text;
                Frm.Hastane = label2.Text;
                Frm.Brans = label4.Text;
                Frm.DoktorTc = LblTc.Text;
                Frm.Show();
            }
           
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hastalistesi();
        }
        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
