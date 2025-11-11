using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BLL;
using DTO;
using Guna.UI2.WinForms; 
namespace GUI
{

    public partial class QuanLyGiaoVien : Form
    {
        public QuanLyGiaoVien()
        {
            InitializeComponent();
            this.Resize += new EventHandler(QuanLyGiaoVien_Resize);
            AdjustItemHeight();
        }

        private void QuanLyGiaoVien_Resize(object sender, EventArgs e)
        {
            AdjustItemHeight();
    
        }
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

            try
            {
                if (DataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = DataGridView1.Rows[0];

                    txtMaGV.Text = firstRow.Cells["MaGiaoVien"].Value?.ToString();
                    txtHoTen.Text = firstRow.Cells["HoTen"].Value?.ToString();

                    if (firstRow.Cells["NgaySinh"].Value != null && firstRow.Cells["NgaySinh"].Value != DBNull.Value)
                    {
                        DTPNgaySinh.Value = (DateTime)firstRow.Cells["NgaySinh"].Value; // DTPNgaySinh
                    }

                    if (firstRow.Cells["GioiTinh"].Value != null)
                    {
                        cboGioiTinh.SelectedItem = firstRow.Cells["GioiTinh"].Value.ToString(); // cboGioiTinh
                    }

                    if (firstRow.Cells["DiaChi"].Value != null)
                        txtDiaChi.Text = firstRow.Cells["DiaChi"].Value.ToString(); // txtDiaChi

                    if (firstRow.Cells["DienThoai"].Value != null)
                        txtSĐT.Text = firstRow.Cells["DienThoai"].Value.ToString(); // txtSĐT

                    if (firstRow.Cells["Email"].Value != null)
                        txtEmail.Text = firstRow.Cells["Email"].Value.ToString();

                    if (firstRow.Cells["ChuyenMon"].Value != null)
                        cboChuyenMon.SelectedItem = firstRow.Cells["ChuyenMon"].Value.ToString(); // cboChuyenMon

                    if (firstRow.Cells["TrangThai"].Value != null && firstRow.Cells["TrangThai"].Value != DBNull.Value)
                    {
                        bool trangThai = Convert.ToBoolean(firstRow.Cells["TrangThai"].Value);
                        cboTrangThai.SelectedItem = trangThai ? "Đang làm việc" : "Nghỉ việc"; // cboTrangThai
                    }

                  
                    txtMaGV.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi hiển thị thông tin giảng viên đầu tiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    cboChuyenMon.SelectedItem = row.Cells["ChuyenMon"].Value.ToString(); // cboChuyenMon

                if (row.Cells["TrangThai"].Value != null && row.Cells["TrangThai"].Value != DBNull.Value)
                {
                    bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                    cboTrangThai.SelectedItem = trangThai ? "Đang làm việc" : "Nghỉ việc"; // cboTrangThai
                }

                // Xử lý load ảnh khi click vào hàng (nếu có)
                // if (row.Cells["HinhAnh"].Value != null && row.Cells["HinhAnh"].Value is byte[] imageData)
                // {
                //     using (MemoryStream ms = new MemoryStream(imageData))
                //     {
                //         picThemAnh.Image = Image.FromStream(ms);
                //         picThemAnh.Tag = null; 
                //     }
                // }
                // else
                // {
                //     picThemAnh.Image = null;
                //     picThemAnh.Tag = null;
                // }
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
            // if (picThemAnh.Tag != null)
            // {
            //      gv.HinhAnh = File.ReadAllBytes(picThemAnh.Tag.ToString());
            // }

            string ketQua = GiaoVienBLL.Instance.InsertGiaoVien(gv);
            MessageBox.Show(ketQua, "Thông báo");

            if (ketQua.Contains("thành công"))
            {
                LoadData();
                ClearForm();
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
            gv.MaGiaoVien = Convert.ToInt32(txtMaGV.Text).ToString();
            gv.HoTen = txtHoTen.Text;
            gv.DiaChi = txtDiaChi.Text; // txtDiaChi
            gv.DienThoai = txtSĐT.Text; // txtSĐT
            gv.Email = txtEmail.Text;
            gv.ChuyenMon = cboChuyenMon.SelectedItem?.ToString(); // cboChuyenMon
            gv.TrangThai = (cboTrangThai.SelectedItem?.ToString() == "Đang làm việc"); // cboTrangThai

            // Xử lý ảnh (nếu có)
            // if (picThemAnh.Tag != null)
            // {
            //      gv.HinhAnh = File.ReadAllBytes(picThemAnh.Tag.ToString());
            // }

            string ketQua = GiaoVienBLL.Instance.UpdateGiaoVien(gv);
            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để xóa.", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa giáo viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maGiaoVien = Convert.ToInt32(txtMaGV.Text);
                string ketQua = GiaoVienBLL.Instance.DeleteGiaoVien(maGiaoVien);
                MessageBox.Show(ketQua, "Thông báo");

                if (ketQua.Contains("thành công"))
                {
                    LoadData();
                    ClearForm();
                }
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
            DTPNgaySinh.Value = DateTime.Now; // DTPNgaySinh
            cboGioiTinh.Text = ""; // cboGioiTinh
            txtDiaChi.Text = ""; // txtDiaChi
            txtSĐT.Text = ""; // txtSĐT
            txtEmail.Text = "";

          
            cboChuyenMon.SelectedIndex = -1; // cboChuyenMon
            cboTrangThai.SelectedIndex = -1; // cboTrangThai

          

            txtMaGV.ReadOnly = true;
            txtHoTen.Focus();
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
                newHeight = 35;
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
    }
}