using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BLL;
using DTO;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
namespace GUI
{

    public partial class frmQuanLyGiaoVien : Form
    {
        public frmQuanLyGiaoVien()
        {
            InitializeComponent();
            this.Resize += new EventHandler(QuanLyGiaoVien_Resize);
            AdjustItemHeight();
        }

        private void QuanLyGiaoVien_Resize(object sender, EventArgs e)
        {
            AdjustItemHeight();

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
                // THAY ĐỔI LOGIC:
                // 1. Xóa lựa chọn (ClearSelection) TRƯỚC TIÊN.
                //    Việc này có thể kích hoạt CellClick (gọi SetAppMode(false)),
                //    nhưng không sao, vì chúng ta sẽ ghi đè lại ở bước 2.
                DataGridView1.ClearSelection();

                // 2. Bật/Tắt các nút SAU CÙNG.
                //    Điều này đảm bảo trạng thái "Thêm" (Enabled = true) là trạng thái cuối cùng.
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
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

        private void QuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang làm việc");
            cboTrangThai.Items.Add("Nghỉ việc");
            LoadData();
            SetupDataGridView();

            // Liên kết CellFormatting cho DataGridView1
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);

            // Liên kết CellClick cho DataGridView1
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);

            // Bắt đầu ở chế độ "Thêm"
            SetAppMode(isAdding: true);
        }

        // --- Xử lý sự kiện CellClick của DataGridView ---
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView1.Rows[e.RowIndex]; // DataGridView1

                txtMaGV.Text = row.Cells["MaGiaoVien"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

                if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    DTPNgaySinh.Value = (DateTime)row.Cells["NgaySinh"].Value; // DTPNgaySinh
                }
                if (row.Cells["GioiTinh"].Value != null)
                {
                    cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString(); // cboGioiTinh
                }

                if (row.Cells["DiaChi"].Value != null)
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString(); // txtDiaChi

                if (row.Cells["DienThoai"].Value != null)
                    txtSĐT.Text = row.Cells["DienThoai"].Value.ToString(); // txtSĐT

                if (row.Cells["Email"].Value != null)
                    txtEmail.Text = row.Cells["Email"].Value.ToString();

                if (row.Cells["ChuyenMon"].Value != null)
                    cboChuyenMon.Text = row.Cells["ChuyenMon"].Value.ToString(); // cboChuyenMon

                if (row.Cells["TrangThai"].Value != null && row.Cells["TrangThai"].Value != DBNull.Value)
                {
                    bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                    cboTrangThai.Text = trangThai ? "Đang làm việc" : "Nghỉ việc"; // cboTrangThai
                }

                txtMaGV.ReadOnly = true; // Giữ nguyên ReadOnly cho Mã GV

                // Khóa nút Thêm và mở nút Sửa/Xóa (chế độ sửa/xóa)
                btnThem.Enabled = false; // Khóa nút Thêm
                btnSua.Enabled = true; // Mở nút Sửa
                btnXoa.Enabled = true; // Mở nút Xóa

                // Xử lý load ảnh khi click vào hàng (nếu có)
                // ... (logic ảnh của bạn) ...

                // Khi nhấn vào 1 hàng, chuyển sang chế độ "Sửa/Xóa"
                SetAppMode(isAdding: false);
            }
        }

        // --- Xử lý sự kiện Button Click ---

        private void btnThem_Click(object sender, EventArgs e)
        {

            GiaoVienDTO gv = new GiaoVienDTO();
            gv.NgaySinh = DTPNgaySinh.Value; // DTPNgaySinh
            gv.GioiTinh = cboGioiTinh.Text; // cboGioiTinh

            gv.HoTen = txtHoTen.Text;
            gv.DiaChi = txtDiaChi.Text; // txtDiaChi
            gv.DienThoai = txtSĐT.Text; // txtSĐT
            gv.Email = txtEmail.Text;
            gv.ChuyenMon = cboChuyenMon.SelectedItem?.ToString(); // cboChuyenMon
            gv.TrangThai = (cboTrangThai.SelectedItem?.ToString() == "Đang làm việc"); // cboTrangThai

            // Xử lý ảnh (nếu có)
            // ... (logic ảnh của bạn) ...

            string ketQua = GiaoVienBLL.Instance.InsertGiaoVien(gv);
            MessageBox.Show(ketQua, "Thông báo");

            if (ketQua.Contains("thành công"))
            {
                LoadData();
                ClearForm();
                // Trở về chế độ "Thêm"
                SetAppMode(isAdding: true);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để sửa.", "Thông báo");
                return;
            }

            // Thêm kiểm tra validation ở đây
            GiaoVienDTO gv = new GiaoVienDTO();
            gv.NgaySinh = DTPNgaySinh.Value; // DTPNgaySinh
            gv.GioiTinh = cboGioiTinh.Text; // cboGioiTinh
                                            // Đảm bảo gv.MaGiaoVien là kiểu string
            gv.MaGiaoVien = txtMaGV.Text.Trim();
            gv.HoTen = txtHoTen.Text;
            gv.DiaChi = txtDiaChi.Text; // txtDiaChi
            gv.DienThoai = txtSĐT.Text; // txtSĐT
            gv.Email = txtEmail.Text;
            gv.ChuyenMon = cboChuyenMon.SelectedItem?.ToString(); // cboChuyenMon
            gv.TrangThai = (cboTrangThai.SelectedItem?.ToString() == "Đang làm việc"); // cboTrangThai

            // Xử lý ảnh (nếu có)
            // ... (logic ảnh của bạn) ...

            string ketQua = GiaoVienBLL.Instance.UpdateGiaoVien(gv);
            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
                // Trở về chế độ "Thêm"
                ClearForm();
                SetAppMode(isAdding: true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để xóa.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maGiaoVien = txtMaGV.Text.Trim();
            string tenGiaoVien = txtHoTen.Text; // Lấy tên để thông báo đẹp hơn

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa giáo viên '{tenGiaoVien}' (Mã: {maGiaoVien}) không?",
                                           "Xác nhận xóa",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            try
            {
                // BƯỚC 1: Thử XÓA CỨNG (DELETE)
                string ketQua = GiaoVienBLL.Instance.DeleteGiaoVien(maGiaoVien);

                if (ketQua.Contains("thành công"))
                {
                    // Xóa cứng thành công (giáo viên "sạch", chưa có tài khoản/dữ liệu điểm)
                    MessageBox.Show(ketQua, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                    // ClearForm() đã tự gọi SetAppMode(true)
                }
                else
                {
                    // Trường hợp BLL trả về lỗi mà không phải exception (ví dụ: "Không tìm thấy GV")
                    MessageBox.Show(ketQua, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                // BƯỚC 2: Bị lỗi khóa ngoại (FK constraint, lỗi 547) 
                // -> Giáo viên này đã có dữ liệu (Tài khoản, Điểm)
                // -> Chuyển sang XÓA MỀM (SOFT DELETE)

                var confirmSoftDelete = MessageBox.Show(
                    $"Không thể xóa vĩnh viễn giáo viên '{tenGiaoVien}' vì đã có dữ liệu liên quan (tài khoản hoặc điểm đã nhập).\n\n" +
                    $"Bạn có muốn 'Vô hiệu hóa' (ẩn) giáo viên này thay thế không?",
                    "Không thể xóa vĩnh viễn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmSoftDelete == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo đối tượng GiaoVienDTO để gọi hàm Update
                        GiaoVienDTO gv = new GiaoVienDTO
                        {
                            MaGiaoVien = maGiaoVien,
                            HoTen = txtHoTen.Text,
                            NgaySinh = DTPNgaySinh.Value,
                            GioiTinh = cboGioiTinh.Text,
                            DiaChi = txtDiaChi.Text,
                            DienThoai = txtSĐT.Text,
                            Email = txtEmail.Text,
                            ChuyenMon = cboChuyenMon.SelectedItem?.ToString(),

                            // Đây là điểm mấu chốt: Cập nhật TrangThai = false ("Nghỉ việc")
                            TrangThai = false
                        };

                        // Gọi lại hàm Update (giống hệt nút Sửa) để vô hiệu hóa
                        string ketQuaUpdate = GiaoVienBLL.Instance.UpdateGiaoVien(gv);

                        if (ketQuaUpdate.Contains("thành công"))
                        {
                            MessageBox.Show("Vô hiệu hóa giáo viên thành công!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu (GV này sẽ biến mất nếu LoadData chỉ lấy GV đang làm)
                            ClearForm(); // Đưa về chế độ thêm
                        }
                        else
                        {
                            MessageBox.Show("Vô hiệu hóa thất bại: " + ketQuaUpdate, "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exUpdate)
                    {
                        MessageBox.Show("Lỗi khi đang vô hiệu hóa: " + exUpdate.Message, "Lỗi",
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        // --- Các Hàm Hỗ trợ ---

        private void LoadData()
        {
            try
            {
                List<GiaoVienDTO> danhSach = GiaoVienBLL.Instance.GetAllGiaoVien();
                DataGridView1.DataSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtMaGV.Text = "";
            txtHoTen.Text = "";
            DTPNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtDiaChi.Text = "";
            txtSĐT.Text = "";
            txtEmail.Text = "";
            cboChuyenMon.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0; // Luôn mặc định là "Đang làm việc"

            // Bỏ dòng txtMaGV.ReadOnly = true;

            // Quan trọng: Sau khi xóa form, đưa về chế độ "Thêm mới"
            SetAppMode(isAdding: true);
        }

        private void SetupDataGridView()
        {
            DataGridView1.ReadOnly = true;
            DataGridView1.AutoGenerateColumns = false;

            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.AllowUserToResizeColumns = false;
            DataGridView1.Columns.Clear();

            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaGiaoVien", HeaderText = "Mã GV", DataPropertyName = "MaGiaoVien", Width = 70 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ Tên", DataPropertyName = "HoTen", Width = 150 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", HeaderText = "Ngày Sinh", DataPropertyName = "NgaySinh", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", HeaderText = "Giới Tính", DataPropertyName = "GioiTinh", Width = 80 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChi", HeaderText = "Địa Chỉ", DataPropertyName = "DiaChi", Width = 90 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DienThoai", HeaderText = "Điện Thoại", DataPropertyName = "DienThoai", Width = 100 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", Width = 190 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChuyenMon", HeaderText = "Chuyên Môn", DataPropertyName = "ChuyenMon", Width = 100 });
            DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 120 });

        }


        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DataGridView1.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        bool status = Convert.ToBoolean(e.Value);
                        e.Value = status ? "Đang làm việc" : "Nghỉ việc";
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        e.Value = "Không xác định";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        private void AdjustItemHeight()
        {
            int newHeight;

            if (this.WindowState == FormWindowState.Maximized)
            {
                newHeight = 36;
            }
            else
            {
                newHeight = 22;
            }

            if (this.cboGioiTinh.ItemHeight != newHeight)
            {
                this.cboGioiTinh.ItemHeight = newHeight;
                this.cboGioiTinh.Invalidate();
            }

            if (this.cboChuyenMon.ItemHeight != newHeight)
            {
                this.cboChuyenMon.ItemHeight = newHeight;
                this.cboChuyenMon.Invalidate();
            }

            if (this.cboTrangThai.ItemHeight != newHeight)
            {
                this.cboTrangThai.ItemHeight = newHeight;
                this.cboTrangThai.Invalidate();
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
        private void txtMaGV_TextChanged(object sender, EventArgs e) { }
        private void GrbTTCT_Click(object sender, EventArgs e) { }
        private void PanelDanhSach_Paint(object sender, PaintEventArgs e) { }
        private void PanelChucNang_Paint(object sender, PaintEventArgs e) { }
        private void lblTTGV_Click(object sender, EventArgs e) { }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLabelPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DTPNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tLPTTCT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrbDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void lblChuyenmon_Click(object sender, EventArgs e)
        {

        }
    }
}