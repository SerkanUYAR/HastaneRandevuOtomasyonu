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
using System.Net.Mail;
using System.Net;

namespace HastaneRandevuOtomasyonProjesi
{
    public partial class FrmSekreterMail : Form
    {
        public FrmSekreterMail()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        public string Hastane;
        MailMessage eposta = new MailMessage();

        private void FrmSekreterMail_Load(object sender, EventArgs e)
        {
            this.Text = Hastane;
            TxtKimden.Text = "xxxxx@gmail.com";   // Gönderici Mail adresi
        }

        private void BtnHastalar_Click(object sender, EventArgs e)  
        {
            SqlCommand hasta = new SqlCommand("select Tc,Mail from Tbl_Hastalar ", Bgl.Baglanti());
            SqlDataAdapter dataadapter0 = new SqlDataAdapter(hasta);
            DataTable Tablo0 = new DataTable();
            dataadapter0.Fill(Tablo0);
            try
            {
                dataGridView1.DataSource = Tablo0;

            }
            catch (Exception hata0)
            {

                MessageBox.Show("Hasta Mail'leri getirilemedi", hata0.Message + "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDoktorlar_Click(object sender, EventArgs e)  
        {
            SqlCommand doktor = new SqlCommand("select Tc, Mail from Tbl_Doktorlar where HASTANE=@p1", Bgl.Baglanti());
            doktor.Parameters.AddWithValue("@p1", Hastane);
            SqlDataAdapter dataadapter1 = new SqlDataAdapter(doktor);
            DataTable Tablo1 = new DataTable();
            dataadapter1.Fill(Tablo1);
            try
            {
                dataGridView1.DataSource = Tablo1;
            }
            catch (Exception Hata1)
            {
                MessageBox.Show("Doktor Mail'leri getirilemedi", Hata1.Message + "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnGönder_Click(object sender, EventArgs e)
        {
            SmtpClient sk = new SmtpClient();
            sk.Port = 587;
            sk.Host = "smtp.gmail.com";
            sk.EnableSsl = true;
            sk.Credentials = new NetworkCredential("MAİL(E POSTA )", "SİFRESİ "); // GÖDERİCİ MELİ İLE ŞİFRESİ GİRİLECEK
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(TxtKimden.Text.ToString());
            mail.To.Add(TxtKime.Text.ToString());
            mail.Subject = TxtKonu.Text.ToString();
            mail.IsBodyHtml = true;
            mail.Body = richTextBox1.Text.ToString();
            sk.Send(mail);
            MessageBox.Show("Mail Gönderildi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKime.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
