using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQLDiemHS : Form
    {
        public frmQLDiemHS()
        {
            InitializeComponent();
            panel1.Resize += panel1_Resize;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void CenterControlInPanel()
        {
            lblTieuDe.Left = (panel1.Width - lblTieuDe.Width) / 2;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            CenterControlInPanel();
        }
        private void frmQLDiemHS_Load(object sender, EventArgs e)
        {

        }
    }
}
