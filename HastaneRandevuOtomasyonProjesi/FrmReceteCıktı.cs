using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace HastaneRandevuOtomasyonProjesi
{
    public partial class FrmReceteCıktı : Form
    {
        public FrmReceteCıktı()
        {
            InitializeComponent();
        }
        public String HastaAd;
        public String HastaTc;
        public String HastaneAd;
        public String DoktorAd;
        public String DoktorBrans;
        public String ReceteKodu;
        public String Recete;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReceteCıktı_Load(object sender, EventArgs e)
        {
            LblHastaAdı.Text = HastaAd;
            LblTc.Text = HastaTc;
            LblHastane.Text = HastaneAd;
            LblDoktor.Text = DoktorAd;
            LblBrans.Text = DoktorBrans;
            LblRecerteKodu.Text = ReceteKodu;
            LblRecete.Text = Recete;
           
        }
        void PdfOku()
        {
            FrmHastaPdfCıktı frm = new FrmHastaPdfCıktı();
            frm.Yol = "C:'" + LblHastaAdı.Text + LblRecerteKodu.Text + "'.pdf";
            frm.Show();
            this.Hide();
           
        }
       


        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
            iTextSharp.text.Document raporum = new iTextSharp.text.Document();
            PdfWriter.GetInstance(raporum, new FileStream("C:'" + LblHastaAdı.Text+LblRecerteKodu.Text+"'.pdf", FileMode.Create)); 
            raporum.AddAuthor(LblHastane.Text+"/"+LblDoktor.Text); 
            raporum.AddCreationDate(); 
            raporum.AddCreator(LblHastane.Text+"/"+LblDoktor.Text);  
            raporum.AddSubject("Recete"+LblRecerteKodu.Text);
            raporum.AddKeywords(LblHastaAdı.Text);

            if (raporum.IsOpen() == false) 
            {
                raporum.Open();  
            }
            raporum.Add(new Paragraph(LblRecete.Text)); 
            pictureBox1.Enabled = false; 
            PdfOku();
        }
    }
}
