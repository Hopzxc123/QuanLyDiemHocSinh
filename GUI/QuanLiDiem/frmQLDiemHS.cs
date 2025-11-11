using BLL;
using DTO;
using FontAwesome.Sharp;
using GUI.frmQLDiemHS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace GUI
{
    public partial class FrmQLDiemHS : Form
    {
        public FrmQLDiemHS()
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
            CapNhatThongTinDiemHS();
            CapNhatLop();

        }

        private void CapNhatLop()
        {
            List<LopDTO> lops = LopBLL.Instance.GetAllLop();
            cbbLop.DataSource = lops;
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "MaLop";

        }

        private void CapNhatThongTinDiemHS()
        {
            dgvDanhSach.DataSource = HocSinhBLL.Instance.GetAllHocSinh();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHocSinh = dgvDanhSach.Rows[e.RowIndex].Cells["MaHocSinh"].Value.ToString();
                GUI.frmQLDiemHS.frmChiTietDiemHocSinh chiTietDiemForm = new GUI.frmQLDiemHS.frmChiTietDiemHocSinh(HocSinhBLL.Instance.GetHocSinhByMa(maHocSinh));
                chiTietDiemForm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Thoát", "Bạn có muốn thoát không ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if(txttMaHS.Text == "" && cbbLop.SelectedIndex != -1)
            {
                dgvDanhSach.DataSource = HocSinhBLL.Instance.GetHocSinhByLop((cbbLop.SelectedValue.ToString()));
                return;
            }
            else if(txttMaHS.Text !="")
            {
                dgvDanhSach.DataSource = HocSinhBLL.Instance.GetHocSinhByMa(txttMaHS.Text.Trim());
                return;
            }
            else
            {
                
                MessageBox.Show(this, "Vui lòng chọn tiêu chí để lọc ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CapNhatThongTinDiemHS();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //if(dgvDanhSach.Rows.Count ==0)
            //{
            //    MessageBox.Show("Không có dữ liệu để in","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    return;
            //}
            //InExcel();
        }

       

    }
}
