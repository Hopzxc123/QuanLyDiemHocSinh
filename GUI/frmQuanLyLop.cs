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
    public partial class frmQuanLyLop : Form
    {
        public frmQuanLyLop()
        {
            InitializeComponent();
            LoadLopData();
            LoadKhoiLop();
            LoadNamHoc();
        }

        // ====================================================================
        // KHỐI LOGIC NGHIỆP VỤ MỚI
        // ====================================================================

        /// <summary>
        /// Quản lý trạng thái của các nút Thêm, Sửa, Xóa.
        /// </summary>
        /// <param name="isAdding">True: Chế độ "Thêm mới". False: Chế độ "Sửa/Xóa".</param>
        private void SetAppMode(bool isAdding)
        {
            if (isAdding)
            {
                // Fix: Xóa lựa chọn trước để tránh kích hoạt CellClick
                dgvLop.ClearSelection();

                // Đặt trạng thái nút
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                // Chế độ Sửa/Xóa
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        // ====================================================================
        // KẾT THÚC KHỐI LOGIC MỚI
        // ====================================================================


        private void LoadLopData()
        {
            dgvLop.DataSource = null;
            dgvLop.DataSource = LopBLL.Instance.GetAllLop();
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadKhoiLop()
        {
            cbbKhoiLop.Items.Clear();
            cbbKhoiLop.Items.AddRange(new object[] { 10, 11, 12 });
            cbbKhoiLop.SelectedIndex = -1;
        }

        private void LoadNamHoc()
        {
            var list = NamHocBLL.Instance.GetAllNamHoc();

            cbbNamHoc.DataSource = list;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";

            cbbNamHoc.SelectedIndex = -1;
        }

        private void frmQLLop_Load(object sender, EventArgs e)
        {
            LoadKhoiLop();
            LoadNamHoc();
            LoadLopData();
            // Bắt đầu ở chế độ "Thêm"
            SetAppMode(isAdding: true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // !! Ghi chú: Logic kiểm tra (validation) này có vẻ chưa tối ưu,
                // nhưng tôi sẽ giữ nguyên theo yêu cầu của bạn.
                if (string.IsNullOrWhiteSpace(txtMaLop.Text) &&
                    string.IsNullOrWhiteSpace(txtTenLop.Text) &&
                    string.IsNullOrWhiteSpace(txtGhiChu.Text) &&
                    string.IsNullOrWhiteSpace(txtSiSo.Text) &&
                    cbbKhoiLop.SelectedValue == null &&
                    cbbNamHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng nhập thông tin lớp cần thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LopDTO lop = new LopDTO
                {
                    MaLop = txtMaLop.Text,
                    TenLop = txtTenLop.Text,
                    KhoiLop = Convert.ToInt32(cbbKhoiLop.SelectedItem),
                    SiSo = int.TryParse(txtSiSo.Text, out int siso) ? siso : 0,
                    NamHoc = cbbNamHoc.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                if (LopBLL.Instance.InsertLop(lop))
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    LoadLopData();
                    ClearForm();
                    // Trở về chế độ "Thêm"
                    SetAppMode(isAdding: true);
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
                {
                    MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LopDTO lop = new LopDTO
                {
                    MaLop = txtMaLop.Text,
                    TenLop = txtTenLop.Text,
                    KhoiLop = Convert.ToInt32(cbbKhoiLop.SelectedItem),
                    SiSo = int.TryParse(txtSiSo.Text, out int siso) ? siso : 0,
                    NamHoc = cbbNamHoc.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                if (LopBLL.Instance.UpdateLop(lop))
                {
                    MessageBox.Show("Cập nhật lớp thành công!");
                    LoadLopData();
                    ClearForm();
                    // Trở về chế độ "Thêm"
                    SetAppMode(isAdding: true);
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
                        // Trở về chế độ "Thêm"
                        SetAppMode(isAdding: true);
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
                cbbKhoiLop.SelectedItem = Convert.ToInt32(dgvLop.CurrentRow.Cells["KhoiLop"].Value);
                cbbNamHoc.SelectedValue = dgvLop.CurrentRow.Cells["NamHoc"].Value.ToString();
                txtGhiChu.Text = dgvLop.CurrentRow.Cells["GhiChu"].Value?.ToString();

                // Chuyển sang chế độ "Sửa/Xóa"
                SetAppMode(isAdding: false);
            }
        }

        private void ClearForm()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSiSo.Clear();
            txtGhiChu.Clear();
            cbbKhoiLop.SelectedIndex = -1;
            cbbNamHoc.SelectedIndex = -1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadLopData();
            // Trở về chế độ "Thêm"
            SetAppMode(isAdding: true);
        }

        private void frmQuanLyLop_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void tableLayoutPanel2_Layout(object sender, LayoutEventArgs e)
        {
            cbbTKKhoiLop.Height = txtTKMaLop.Height;
        }
    }
}
