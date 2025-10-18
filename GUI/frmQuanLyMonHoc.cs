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
    public partial class frmQuanLyMonHoc : Form
    {
        public frmQuanLyMonHoc()
        {
            InitializeComponent();
            panel3.Resize += panel3_Resize;
        }

        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {

        }

        private void gbThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CenterControlInPanel()
        {
            lbltitle.Left = (panel3.Width - lbltitle.Width) / 2;
            
        }
        private void panel3_Resize(object sender, EventArgs e)
        {
            CenterControlInPanel();
        }
    }
}
