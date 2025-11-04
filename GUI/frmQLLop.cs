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

namespace GUI
{
    public partial class frmQLLop : Form
    {
       
        public frmQLLop()
        {
            InitializeComponent();
           
        }

        private void LoadLopData()
        {
            dgvLop.DataSource = null;
            dgvLop.DataSource = LopBLL.Instance.GetAllLop();
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadKhoiLop()
        {
            cboKhoiLop.Items.Clear();
            cboKhoiLop.Items.AddRange(new object[] { 10, 11, 12 });
            cboKhoiLop.SelectedIndex = -1;
        }

        private void LoadNamHoc()
        {
            var list = NamHocBLL.Instance.GetAllNamHoc();

            cboNamHoc.DataSource = list;
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.ValueMember = "MaNamHoc";

            cboNamHoc.SelectedIndex = -1;
        }

        private void frmQLLop_Load(object sender, EventArgs e)
        {
            LoadKhoiLop();
            LoadNamHoc();
            LoadLopData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LopDTO lop = new LopDTO
                {
                    MaLop = txtMaLop.Text,
                    TenLop = txtTenLop.Text,
                    KhoiLop = Convert.ToInt32(cboKhoiLop.SelectedItem),
                    SiSo = int.TryParse(txtSiSo.Text, out int siso) ? siso : 0,
                    NamHoc = cboNamHoc.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                if (LopBLL.Instance.InsertLop(lop))
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    LoadLopData();
                }
                else
                    MessageBox.Show("Thêm lớp thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLop.CurrentRow == null)
                    return;

                LopDTO lop = new LopDTO
                {
                    MaLop = txtMaLop.Text,
                    TenLop = txtTenLop.Text,
                    KhoiLop = Convert.ToInt32(cboKhoiLop.SelectedItem),
                    SiSo = int.TryParse(txtSiSo.Text, out int siso) ? siso : 0,
                    NamHoc = cboNamHoc.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                if (LopBLL.Instance.UpdateLop(lop))
                {
                    MessageBox.Show("Cập nhật lớp thành công!");
                    LoadLopData();
                }
                else
                    MessageBox.Show("Cập nhật thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLop.Text))
                {
                    MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maLop = txtMaLop.Text;
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa lớp này không?", "Xác nhận",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    bool result = LopBLL.Instance.DeleteLop(maLop);
                    if (result)
                    {
                        MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLopData();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLop.Rows.Count > 0)
            {
                txtMaLop.Text = dgvLop.CurrentRow.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = dgvLop.CurrentRow.Cells["TenLop"].Value.ToString();
                txtSiSo.Text = dgvLop.CurrentRow.Cells["SiSo"].Value.ToString();
                cboKhoiLop.SelectedItem = Convert.ToInt32(dgvLop.CurrentRow.Cells["KhoiLop"].Value);
                cboNamHoc.SelectedValue = dgvLop.CurrentRow.Cells["NamHoc"].Value.ToString();
                txtGhiChu.Text = dgvLop.CurrentRow.Cells["GhiChu"].Value?.ToString();

            }
        }

        private void ClearForm()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSiSo.Clear();
            txtGhiChu.Clear();
            cboKhoiLop.SelectedIndex = -1;
            if (cboNamHoc.Items.Count > 0) cboNamHoc.SelectedIndex = -1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadLopData();
        }

        
    }
}
