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
    public partial class frmTrangChinh : Form
    {
        public frmTrangChinh()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            plBody.Controls.Add(childForm);
            plBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }



        private void fTrangChinh_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLThongTinSinhVien ());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLDiemHS());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLThongTinSinhVien());
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQuanLyMonHoc());
        }
    }
}
