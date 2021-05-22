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

namespace HastaneRandevuOtomasyonProjesi
{
    public partial class FrmHastaPdfCıktı : Form
    {
        public FrmHastaPdfCıktı()
        {
            InitializeComponent();
        }
        public string Yol;

        private void FrmPdfOku_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(Yol);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
