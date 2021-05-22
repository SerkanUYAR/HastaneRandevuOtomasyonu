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
    public partial class FrmSekreterDoktor : Form
    {
        public FrmSekreterDoktor()
        {
            InitializeComponent();
        }
        public string hastane;
        SqlBaglanti Bgl = new SqlBaglanti();
        bool durum;

        void TekrarEngenleme()
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where TC=@p3", Bgl.Baglanti()); // doktor listesi tc ile kontrol ediliton
            komut.Parameters.AddWithValue("@p3", MslTc.Text);
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
        

        private void FrmSekreterDoktor_Load(object sender, EventArgs e)
        {
            CmbHastane.Text = hastane;
            this.Text = hastane;
            CmbHastane.Enabled = false;
           
            CmbIlce.Items.Clear();
            DataTable tablo = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select SehirAd from Tbl_Iller", Bgl.Baglanti());
            da.Fill(tablo);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SehirAd";
            CmbIl.DataSource = tablo;


           
            CmbBranş.Items.Clear();
            SqlCommand komut = new SqlCommand("select distinct BRANS from Tbl_Doktorlar where HASTANE=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", CmbHastane.Text.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbBranş.Items.Add(dr[0]);
            }

        }
        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            CmbIlce.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ilceler  where sehirid=@p1", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                CmbIlce.Items.Add(dr[1]);
            }
        }

        private void PctKayıt_Click(object sender, EventArgs e)
        {
            TekrarEngenleme(); 

            if (durum == true)
            {
                SqlCommand kayıt = new SqlCommand("insert into Tbl_Doktorlar(AD,SOYAD,TC,TELEFON,BRANS,HASTANE,IL,ILCE,CİNSİYET,SİFRE,MAİL)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11) ", Bgl.Baglanti());
                kayıt.Parameters.AddWithValue("@p1", TxtAd.Text);
                kayıt.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                kayıt.Parameters.AddWithValue("@p3", MslTc.Text);
                kayıt.Parameters.AddWithValue("@p4", MskTelefon.Text);
                kayıt.Parameters.AddWithValue("@p5", CmbBranş.Text);
                kayıt.Parameters.AddWithValue("@p6", CmbHastane.Text);
                kayıt.Parameters.AddWithValue("@p7", CmbIl.Text);
                kayıt.Parameters.AddWithValue("@p8", CmbIlce.Text);
                kayıt.Parameters.AddWithValue("@p9", LblCinsiyet.Text);
                kayıt.Parameters.AddWithValue("@p10", TxtSifre.Text);
                kayıt.Parameters.AddWithValue("@p11", TxtMail.Text);
                kayıt.ExecuteNonQuery();
                MessageBox.Show("Kayıt yapıldı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            if (durum==false)
            {

                MessageBox.Show(MslTc.Text + " " + "Kaydınız Bulunmaktadır.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PctTemizle_Click(object sender, EventArgs e)
        {
            TxtAd.Clear();
            TxtSoyad.Clear();
            MskTelefon.Clear();
            MslTc.Clear();
            TxtMail.Clear();
            CmbBranş.Text = " ";
            CmbIl.Text = " ";
            CmbIlce.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtSifre.Clear();
        }  

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
