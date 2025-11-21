using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using GUI.QLThongTinHocSinh;

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
            CapNhatNamHoc();
        }

        // ======================== LOAD DỮ LIỆU =========================
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
            dgvHocSinh.DataSource = listHocSinh;
            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CapNhatNamHoc()
        {
            List<NamHocDTO> nams = NamHocBLL.Instance.GetAllNamHoc();
            nams.Sort((x, y) => y.NgayKetThuc.CompareTo(x.NgayBatDau));
            nams.Insert(0, new NamHocDTO { MaNamHoc = "", TenNamHoc = "-Tất cả-" });

            cbbNamHoc.DataSource = nams;
            cbbNamHoc.DisplayMember = "TenNamHoc";
            cbbNamHoc.ValueMember = "MaNamHoc";
        }

        // ======================== XỬ LÝ NÚT =========================
        private void ClearForm()
        {
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
                if (dgvHocSinh.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần sửa!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                if (HocSinhBLL.Instance.UpdateHocSinh(hs))
                {
                    MessageBox.Show("Cập nhật học sinh thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHocSinhData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (dgvHocSinh.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần xóa!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHocSinh = dgvHocSinh.CurrentRow.Cells["MaHocSinh"].Value.ToString();
                string tenHocSinh = dgvHocSinh.CurrentRow.Cells["HoTen"].Value.ToString();

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa học sinh '{tenHocSinh}' (Mã: {maHocSinh}) không?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                    return;

                try
                {
                    // BƯỚC 1: Thử XÓA CỨNG (DELETE)
                    if (HocSinhBLL.Instance.DeleteHocSinh(maHocSinh))
                    {
                        // Xóa cứng thành công (học sinh này "sạch", chưa có dữ liệu điểm)
                        MessageBox.Show("Xóa học sinh thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHocSinhData();
                        ClearForm();
                    }
                    else
                    {
                        // BLL trả về false mà không ném exception
                        MessageBox.Show("Xóa học sinh thất bại!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547)
                {
                    // BƯỚC 2: Bị lỗi khóa ngoại (FK constraint, lỗi 547) 
                    // -> Học sinh này đã có dữ liệu (điểm)
                    // -> Chuyển sang XÓA MỀM (SOFT DELETE)

                    var confirmSoftDelete = MessageBox.Show(
                        $"Không thể xóa vĩnh viễn học sinh '{tenHocSinh}' vì đã có dữ liệu điểm liên quan.\n\n" +
                        $"Bạn có muốn 'Vô hiệu hóa' (ẩn) học sinh này thay thế không?",
                        "Không thể xóa vĩnh viễn",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmSoftDelete == DialogResult.Yes)
                    {
                        // Lấy toàn bộ thông tin của học sinh từ DGV
                        // để gọi hàm Update, chỉ thay đổi TrangThai
                        HocSinhDTO hs = new HocSinhDTO
                        {
                            MaHocSinh = maHocSinh,
                            HoTen = dgvHocSinh.CurrentRow.Cells["HoTen"].Value.ToString(),
                            GioiTinh = dgvHocSinh.CurrentRow.Cells["GioiTinh"].Value.ToString(),
                            NgaySinh = Convert.ToDateTime(dgvHocSinh.CurrentRow.Cells["NgaySinh"].Value),
                            DiaChi = dgvHocSinh.CurrentRow.Cells["DiaChi"].Value.ToString(),
                            Email = dgvHocSinh.CurrentRow.Cells["Email"].Value.ToString(),
                            MaLop = dgvHocSinh.CurrentRow.Cells["MaLop"].Value?.ToString(),

                            // Đây là điểm mấu chốt: Cập nhật TrangThai = 0 (tức là false)
                            TrangThai = "0"
                        };

                        // Gọi lại hàm Update (giống hệt nút Sửa) để vô hiệu hóa
                        if (HocSinhBLL.Instance.UpdateHocSinh(hs))
                        {
                            MessageBox.Show("Vô hiệu hóa học sinh thành công!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHocSinhData(); // Tải lại dữ liệu (học sinh này sẽ biến mất)
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Vô hiệu hóa thất bại.", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Các lỗi chung khác (mất kết nối, v.v.)
                    MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lỗi chung khi lấy dữ liệu từ DGV
                MessageBox.Show("Lỗi chung: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            cbbNamHoc.SelectedIndex = 0;
            LoadHocSinhData();
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

        // ======================== CELL CLICK =========================
        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHocSinh.Rows.Count > 0)
            {
                txtHoTen.Text = dgvHocSinh.CurrentRow.Cells["HoTen"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvHocSinh.CurrentRow.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvHocSinh.CurrentRow.Cells["NgaySinh"].Value);
                txtDiaChi.Text = dgvHocSinh.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = dgvHocSinh.CurrentRow.Cells["Email"].Value.ToString();

                // ✅ Lấy trực tiếp MaLop
                if (dgvHocSinh.Columns.Contains("MaLop"))
                {
                    string maLop = dgvHocSinh.CurrentRow.Cells["MaLop"].Value?.ToString();
                    if (!string.IsNullOrEmpty(maLop))
                        cboMaLop.SelectedValue = maLop;
                }
            }
        }

        public DataGridView DgvHocSinh
        {
            get { return dgvHocSinh; }
        }


        // ======================== LỌC THEO NĂM HỌC & LỚP =========================
        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNamHoc.SelectedIndex == 0)
            {
                LoadHocSinhData();
                cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
                cbbLop.DataSource = null;
                cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;
                return;
            }

            cbbLop.SelectedIndexChanged -= cbbLop_SelectedIndexChanged;
            string maNamHoc = cbbNamHoc.SelectedValue.ToString();

            List<LopDTO> lops = LopBLL.Instance.GetLopByNamHoc(maNamHoc);
            lops.Sort((x, y) => string.Compare(x.TenLop, y.TenLop));
            lops.Insert(0, new LopDTO { MaLop = "", TenLop = "-Chọn lớp-" });

            cbbLop.DataSource = lops;
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "MaLop";
            cbbLop.SelectedIndexChanged += cbbLop_SelectedIndexChanged;

            dgvHocSinh.DataSource = HocSinhBLL.Instance.GetHocSinhByNamHoc(maNamHoc);
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLop.SelectedIndex == 0 || cbbLop.SelectedValue == null)
            {
                dgvHocSinh.DataSource = null;
                return;
            }

            string maLop = cbbLop.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(maLop))
            {
                dgvHocSinh.DataSource = HocSinhBLL.Instance.GetHocSinhByLop(maLop);
                dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                LoadHocSinhData();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmTimKiemHocSinh frm = new frmTimKiemHocSinh(this);
            frm.Show();
        }
    }
}


