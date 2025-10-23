using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class frmQLLop : Form
    {
       private readonly LopBLL bll = new LopBLL();
        public frmQLLop()
        {
            InitializeComponent();
            LoadData();
        }
   
        private void LoadData()
        {
            dgvLop.DataSource = bll.GetAll();
        }

        private void ClearInput()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoiLop.Text = "";
            txtSiSo.Text = "";
            txtNamHoc.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LopDTO lop = new LopDTO
                {
                    TenLop = txtTenLop.Text,
                    KhoiLop = int.Parse(txtKhoiLop.Text),
                    SiSo = int.Parse(txtSiSo.Text),
                    NamHoc = int.Parse(txtNamHoc.Text),
                    GhiChu = txtGhiChu.Text
                };

                if (bll.Insert(lop))
                {
                    MessageBox.Show("Thêm lớp thành công");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LopDTO lop = new LopDTO
                {
                    MaLop = int.Parse(txtMaLop.Text),
                    TenLop = txtTenLop.Text,
                    KhoiLop = int.Parse(txtKhoiLop.Text),
                    SiSo = int.Parse(txtSiSo.Text),
                    NamHoc = int.Parse(txtNamHoc.Text),
                    GhiChu = txtGhiChu.Text
                };

                if (bll.Update(lop))
                {
                    MessageBox.Show("Sửa lớp thành công");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtMaLop.Text);
                if (bll.Delete(id))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txtKhoiLop.Text = row.Cells["KhoiLop"].Value.ToString();
                txtSiSo.Text = row.Cells["SiSo"].Value.ToString();
                txtNamHoc.Text = row.Cells["NamHoc"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLLop_Load(object sender, EventArgs e)
        {
            toolTipMaLop.InitialDelay = 1000;
            toolTipMaLop.AutoPopDelay = 8000;   
            toolTipMaLop.ReshowDelay = 100;      
        }
    }
}
