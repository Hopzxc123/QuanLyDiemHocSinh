using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQLThongTinHocSinh : Form
    {
        public frmQLThongTinHocSinh()
        {
            InitializeComponent();
        }

        private void frmQLThongTinHocSinh_Load(object sender, EventArgs e)
        {
            LoadGioiTinh();
            LoadLop();
            LoadHocSinhData();

            // Bắt đầu ở chế độ "Thêm"
            SetAppMode(isAdding: true);
            CapNhatNamHoc();
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
                // Cho phép Thêm, vô hiệu hóa Sửa/Xóa
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                // Xóa lựa chọn trên DataGridView
                dgvHocSinh.ClearSelection();
            }
            else
            {
                // Vô hiệu hóa Thêm, cho phép Sửa/Xóa
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        // ====================================================================
        // KẾT THÚC KHỐI LOGIC MỚI
        // ====================================================================


        private void LoadGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;
        }

        private void LoadLop()
        {
            var list = LopBLL.Instance.GetAllLop();
            cboMaLop.DataSource = list;
            cboMaLop.DisplayMember = "TenLop";
            cboMaLop.ValueMember = "MaLop";
        }

        private void LoadHocSinhData()
        {
            var listHocSinh = HocSinhBLL.Instance.GetAllHocSinh() ?? new List<HocSinhDTO>();
            var listLop = LopBLL.Instance.GetAllLop() ?? new List<LopDTO>();

            var displayList = listHocSinh.Select(hs => new
            {
                hs.MaHocSinh,
                hs.HoTen,
                hs.GioiTinh,
                hs.NgaySinh,
                hs.DiaChi,
                hs.Email,
                TenLop = listLop.FirstOrDefault(l => l.MaLop.ToString() == hs.MaLop)?.TenLop
            }).ToList();

            dgvHocSinh.DataSource = displayList;
            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearForm()
        {
            //txtMaHS.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cboGioiTinh.SelectedIndex = 0;
            if (cboMaLop.Items.Count > 0)
                cboMaLop.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HocSinhDTO hs = new HocSinhDTO
                {
                    //MaHocSinh = txtMaHS.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    MaLop = cboMaLop.SelectedValue?.ToString(),
                    TrangThai = "1"
                };

                if (HocSinhBLL.Instance.InsertHocSinh(hs))
                {
                    MessageBox.Show("Thêm học sinh thành công!");
                    LoadHocSinhData();
                    ClearForm();
                    // Sau khi thêm, vẫn ở chế độ "Thêm"
                    SetAppMode(isAdding: true);
                }
                else
                {
                    MessageBox.Show("Thêm học sinh thất bại!");
                }
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
                // Kiểm tra có dòng nào đang chọn không
                if (dgvHocSinh.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần sửa!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === SỬA LỖI: Logic này phải nằm BÊN NGOÀI khối 'if' ở trên ===
                string maHocSinh = dgvHocSinh.CurrentRow.Cells["MaHocSinh"].Value.ToString();
                HocSinhDTO hs = new HocSinhDTO
                {
                    MaHocSinh = maHocSinh,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    MaLop = cboMaLop.SelectedValue?.ToString(),
                    TrangThai = "1"
                };

                // Gọi BLL để cập nhật
                if (HocSinhBLL.Instance.UpdateHocSinh(hs))
                {
                    MessageBox.Show("Cập nhật học sinh thành công!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHocSinhData();
                    ClearForm();
                    // Sau khi sửa, trả về chế độ "Thêm"
                    SetAppMode(isAdding: true);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // === KẾT THÚC SỬA LỖI ===
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có hàng được chọn trong DataGridView
                if (dgvHocSinh.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy MaHocSinh từ DataGridView
                string maHocSinh = dgvHocSinh.CurrentRow.Cells["MaHocSinh"].Value.ToString();

                var confirm = MessageBox.Show("Bạn có chắc muốn xóa học sinh này không?", "Xác nhận",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    if (HocSinhBLL.Instance.DeleteHocSinh(maHocSinh))
                    {
                        MessageBox.Show("Xóa học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHocSinhData();
                        ClearForm();
                        // Sau khi xóa, trả về chế độ "Thêm"
                        SetAppMode(isAdding: true);
                    }
                    else
                    {
                        MessageBox.Show("Xóa học sinh thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHocSinh.Rows.Count > 0)
            {
                //txtMaHS.Text = dgvHocSinh.CurrentRow.Cells["MaHocSinh"].Value.ToString();
                txtHoTen.Text = dgvHocSinh.CurrentRow.Cells["HoTen"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvHocSinh.CurrentRow.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvHocSinh.CurrentRow.Cells["NgaySinh"].Value);
                txtDiaChi.Text = dgvHocSinh.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = dgvHocSinh.CurrentRow.Cells["Email"].Value.ToString();
                string tenLop = dgvHocSinh.CurrentRow.Cells["TenLop"].Value.ToString();
                var lop = LopBLL.Instance.GetAllLop().FirstOrDefault(l => l.TenLop == tenLop);
                if (lop != null)
                {
                    cboMaLop.SelectedValue = lop.MaLop;
                }

                // Khi nhấn vào 1 hàng, chuyển sang chế độ "Sửa/Xóa"
                SetAppMode(isAdding: false);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtTimKiem.Clear(); // Clear textbox tìm kiếm
            LoadHocSinhData();

            // Khi làm mới, trả về chế độ "Thêm"
            SetAppMode(isAdding: true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ===== CHỨC NĂNG TÌM KIẾM =====

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadHocSinhData();
                    return;
                }

                var allHocSinh = HocSinhBLL.Instance.GetAllHocSinh();
                var listLop = LopBLL.Instance.GetAllLop();

                // Map học sinh với tên lớp
                var displayList = allHocSinh.Select(hs => new
                {
                    hs.MaHocSinh,
                    hs.HoTen,
                    hs.GioiTinh,
                    hs.NgaySinh,
                    hs.DiaChi,
                    hs.Email,
                    TenLop = listLop.FirstOrDefault(l => l.MaLop.ToString() == hs.MaLop)?.TenLop
                }).ToList();

                // Tìm kiếm theo tên lớp
                var result = displayList.Where(hs =>

                    (hs.TenLop != null && hs.TenLop.ToLower().Contains(keyword))
                ).ToList();

                dgvHocSinh.DataSource = null;
                dgvHocSinh.DataSource = result;

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Tìm kiếm khi nhấn Enter trong TextBox
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CapNhatNamHoc()
        {
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau)); // Sắp xếp giảm dần theo Năm Bắt Đầu
            nams.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "-Tất cả-" });
            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";

        }

        
    }
}