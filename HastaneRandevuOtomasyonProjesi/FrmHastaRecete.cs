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
    public partial class FrmHastaRecete : Form
    {
        public FrmHastaRecete()
        {
            InitializeComponent();
        }

        SqlBaglanti Bgl = new SqlBaglanti();
        public string Tc;
        public String AdSoyad;
        private void FrmHastaRecete_Load(object sender, EventArgs e)
        {
            LblAdSoyad.Text = AdSoyad;
            LblTc.Text = Tc;
            SqlCommand komut = new SqlCommand("select Hastane,Doktor,Brans,Recete,Recete_Kodu from Tbl_Recete where Tc=@p1 ", Bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable Tablo = new DataTable();
            da.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HASTA frm = new HASTA();
            frm.Tc = LblTc.Text;
            frm.Ad_Soyad = LblAdSoyad.Text;
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmReceteCıktı Frm = new FrmReceteCıktı();
            int tası = dataGridView1.SelectedCells[0].RowIndex;
            Frm.HastaneAd = dataGridView1.Rows[tası].Cells[0].Value.ToString();
            Frm.DoktorAd = dataGridView1.Rows[tası].Cells[1].Value.ToString();
            Frm.DoktorBrans = dataGridView1.Rows[tası].Cells[2].Value.ToString();
            Frm.Recete = dataGridView1.Rows[tası].Cells[3].Value.ToString();
            Frm.ReceteKodu = dataGridView1.Rows[tası].Cells[4].Value.ToString();
            Frm.HastaAd = LblAdSoyad.Text;
            Frm.HastaTc = LblTc.Text;
            Frm.Show();
        }
    }
}
