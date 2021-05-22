using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevuOtomasyonProjesi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        int sayac;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            linkLabel1.Text = "Bakan Fahrettin Koca, Parlamento Muhabirlerinin Sorularını Yanıtladı";
            
        }

        private void hASTAGİRİŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HastaGiris frm = new HastaGiris();
            frm.Show();
            this.Hide();
        }

        private void dOKTORGİRİŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoktorGiris frm = new DoktorGiris();
            frm.Show();
            this.Hide();
        }

        private void sEKRETERGİRİŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frm = new FrmSekreterGiris();
            frm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label1.Text = sayac.ToString();
            if (sayac == 0)
            {

                pictureBox3.Image = Properties.Resources.resim1;
                linkLabel1.Text = "Bakan Fahrettin Koca, Parlamento Muhabirlerinin Sorularını Yanıtladı";

            }
            if (sayac == 5)
            {
                pictureBox3.Image = Properties.Resources.resim2;
                linkLabel1.Text = "Aşı Programı Adaletle ve Şeffaf Şekilde Yürütülmektedir";
            }
            if (sayac == 10)
            {
                pictureBox3.Image = Properties.Resources.resim3;
                linkLabel1.Text = "Bakan Koca, Türkiye’nin Kovid-19’la 1 Yıllık Mücadele Sürecini Değerlendirdi";

            }
            if (sayac==15)
            {
                pictureBox3.Image = Properties.Resources.resim4;
                linkLabel1.Text = "En Çok Aşılama Yapan Ülkeler Arasındayız";
            }
            if (sayac == 15)
            {
                sayac = 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "Bakan Fahrettin Koca, Parlamento Muhabirlerinin Sorularını Yanıtladı")
            {
                System.Diagnostics.Process.Start("https://www.saglik.gov.tr/TR,81811/bakan-fahrettin-koca-parlamento-muhabirlerinin-sorularini-yanitladi.html");
            }
            if (linkLabel1.Text == "Aşı Programı Adaletle ve Şeffaf Şekilde Yürütülmektedir")
            {
                System.Diagnostics.Process.Start("https://www.saglik.gov.tr/TR,82365/en-cok-asilama-yapan-ulkeler-arasindayiz.html");
            }
            if (linkLabel1.Text == "Bakan Koca, Türkiye’nin Kovid-19’la 1 Yıllık Mücadele Sürecini Değerlendirdi")
            {
                System.Diagnostics.Process.Start("https://www.saglik.gov.tr/TR,80604/bakan-koca-turkiyenin-kovid-19la-1-yillik-mucadele-surecini-degerlendirdi.html");
            }
            if (linkLabel1.Text == "En Çok Aşılama Yapan Ülkeler Arasındayız")
            {
                System.Diagnostics.Process.Start("https://www.saglik.gov.tr/TR,82365/en-cok-asilama-yapan-ulkeler-arasindayiz.html");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://covid19.saglik.gov.tr/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
