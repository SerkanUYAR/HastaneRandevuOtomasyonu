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
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti Bgl = new SqlBaglanti();
        void temizle()
        {
            maskedTextBox1.Text = "";
            textBox1.Text = "";
        }

        private void DoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand Giris = new SqlCommand("select * from Tbl_Doktorlar where TC = @p1 and SİFRE=@p2 ", Bgl.Baglanti());
            Giris.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            Giris.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dm = Giris.ExecuteReader();
            if (dm.Read())
            {
                DOKTOR frm = new DOKTOR();
                frm.Tc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AnaForm frm = new AnaForm();
            frm.Show();
            this.Hide();
        }
    }
}
