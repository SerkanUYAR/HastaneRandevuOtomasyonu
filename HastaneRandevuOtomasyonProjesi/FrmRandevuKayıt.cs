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
    public partial class FrmRandevuKayıt : Form
    {
        public FrmRandevuKayıt()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string AdSoyad;
        public string doktor;
        public string brans;
        public string tarih;
        public string saat;
        public string hastane;
        public string İl;
        public string ilce;
        public string Tckim;
        public string RandevuId;

        private void FrmRandevuKayıt_Load(object sender, EventArgs e)
        {
            LblRAnduvuId.Text = RandevuId;
            LblAdSoyad.Text = AdSoyad;
            LblBrans.Text = brans;
            LblDoktor.Text = doktor;
            LblHastane.Text = hastane;
            LblSaat.Text = saat;
            LblTarih.Text = tarih;
            LblTc.Text = Tckim;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LblRandevuDurum.Text = "False";
            SqlCommand kayıt = new SqlCommand("insert into Tbl_kayıtlıRandevu (AdSoyad,Tc,Hastane,Doktor,Brans,Tarih,saat,sikayet,Durum,ıd) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", Bgl.Baglanti());
            kayıt.Parameters.AddWithValue("@p1", LblAdSoyad.Text);
            kayıt.Parameters.AddWithValue("@p2", LblTc.Text);
            kayıt.Parameters.AddWithValue("@p3", LblHastane.Text);
            kayıt.Parameters.AddWithValue("@p4", LblDoktor.Text);
            kayıt.Parameters.AddWithValue("@p5", LblBrans.Text);
            kayıt.Parameters.AddWithValue("@p6", LblTarih.Text.ToString());
            kayıt.Parameters.AddWithValue("@p7", LblSaat.Text.ToString());
            kayıt.Parameters.AddWithValue("@p8", richTextBox1.Text);
            kayıt.Parameters.AddWithValue("@p9", LblRAnduvuId.Text);
            kayıt.Parameters.AddWithValue("@p10", LblRAnduvuId.Text);
            kayıt.ExecuteNonQuery();

            Bgl.Baglanti().Close();
            MessageBox.Show("Randevu saat" + LblSaat.Text + " Randevu Tarih " + LblTarih.Text + " Randevunu alınmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            BtnRandevuOnay.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (LblRandevuDurum.Text == "False")  
            {
                SqlCommand güncelle = new SqlCommand(" update Tbl_Randevu set TARİH=@P1,SAAT=@P2,BRANS=@P3,DOKTOR=@P4,DURUM=@P5,HASTANE=@P6 WHERE Id=@P7 ", Bgl.Baglanti());
                güncelle.Parameters.AddWithValue("@P1", LblTarih.Text);
                güncelle.Parameters.AddWithValue("@P2", LblSaat.Text);
                güncelle.Parameters.AddWithValue("@P3", LblBrans.Text);
                güncelle.Parameters.AddWithValue("@P4", LblDoktor.Text);
                güncelle.Parameters.AddWithValue("@P5", LblRandevuDurum.Text);
                güncelle.Parameters.AddWithValue("@P6", LblHastane.Text);
                güncelle.Parameters.AddWithValue("@P7", LblRAnduvuId.Text);
                güncelle.ExecuteNonQuery();
                HASTA frm = new HASTA();
                frm.Tc = LblTc.Text;
                frm.Ad_Soyad = LblAdSoyad.Text;
                frm.Show();
                this.Hide();
            }
            else 
            {
                HASTA frm = new HASTA();
                frm.Tc = LblTc.Text;
                frm.Ad_Soyad = LblAdSoyad.Text;
                frm.Show();
                this.Close();
            }
        }
    }
}
