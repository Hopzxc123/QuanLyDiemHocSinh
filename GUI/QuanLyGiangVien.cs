using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace GUI
{
    public class GiangVien
    {
        public string MaGV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string GioiTinh { get; set; } = "Nam";
        public string SDT { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhanLoai { get; set; } = "Thạc Sĩ";
        public string AnhPath { get; set; } = "";
    }
    public partial class QuanLyGiangVien : Form
    {
        private readonly BindingList<GiangVien> _ds = new BindingList<GiangVien>();

        public QuanLyGiangVien()
        {
            InitializeComponent();

            // Giữ tỉ lệ 40/60
            this.Resize += (_, __) => ApplySplitRatio();
            this.Shown += (_, __) => ApplySplitRatio();

            // Tiêu đề nhỏ hơn để không “đè” control
            lblTitle.Font = new Font("Times New Roman", 28f, FontStyle.Bold);

            // Style nút
            StyleButton(btnChonAnh);
            StyleButton(btnThem);
            StyleButton(btnSua);
            StyleButton(btnXoa);
            StyleButton(btnThoat);

            // DataGridView
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;

            // Cột
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã GV", DataPropertyName = "MaGV", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ Tên", DataPropertyName = "HoTen", Width = 220 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giới Tính", DataPropertyName = "GioiTinh", Width = 130 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = "SDT", Width = 130 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Width = 230 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phân loại", DataPropertyName = "PhanLoai", Width = 150 });

            // Cỡ chữ lưới gọn như hình 2
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 38;
            dgv.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dgv.RowTemplate.Height = 28;

            dgv.DataSource = _ds;
            dgv.SelectionChanged += (_, __) => HienThiChiTiet();

            Seed();
            if (dgv.Rows.Count > 0) dgv.Rows[0].Selected = true;
        }

        private void ApplySplitRatio()
        {
            if (splitMain == null) return;
            int w = splitMain.ClientSize.Width;
            if (w <= 0) return;
            int target = (int)(w * 0.40);
            int max = w - splitMain.SplitterWidth - splitMain.Panel2MinSize;
            target = Math.Max(splitMain.Panel1MinSize, Math.Min(target, max));
            splitMain.SplitterDistance = target;
        }
        private void StyleButton(Button b)
        {
            b.BackColor = Color.FromArgb(255, 165, 90);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            b.ForeColor = Color.Black;
            b.Cursor = Cursors.Hand;
        }

        private void Seed()
        {
            _ds.Add(new GiangVien { MaGV = "dhnam", HoTen = "Đỗ Hoàng Nam", GioiTinh = "Nam", SDT = "0979739123", Email = "dhnam@utc.edu.vn", PhanLoai = "Tiến Sĩ" });
            _ds.Add(new GiangVien { MaGV = "nvthanh", HoTen = "Nguyễn Văn Thành", GioiTinh = "Nam", SDT = "0979739345", Email = "nvthanh@utc.edu.vn", PhanLoai = "Thạc Sĩ" });
            _ds.Add(new GiangVien { MaGV = "tnhi", HoTen = "Thái Trúc Nhi", GioiTinh = "Nữ", SDT = "0907155678", Email = "ttnhi@utc.edu.vn", PhanLoai = "Thạc Sĩ" });
        }

        private void HienThiChiTiet()
        {
            var rowObj = dgv.CurrentRow != null ? dgv.CurrentRow.DataBoundItem : null;
            var gv = rowObj as GiangVien;
            if (gv == null) return;

            txtMa.Text = gv.MaGV;
            txtTen.Text = gv.HoTen;
            cboGioiTinh.SelectedItem = gv.GioiTinh;
            txtSDT.Text = gv.SDT;
            txtEmail.Text = gv.Email;
            cboPhanLoai.SelectedItem = gv.PhanLoai;

            if (!string.IsNullOrWhiteSpace(gv.AnhPath) && File.Exists(gv.AnhPath))
                pic.ImageLocation = gv.AnhPath;
            else { pic.ImageLocation = null; pic.Image = null; }
        }

        // Thu thập dữ liệu từ panel trái (trả về null nếu thiếu)
        private GiangVien ThuThap(bool forEdit = false)
        {
            var gv = new GiangVien
            {
                MaGV = txtMa.Text.Trim(),
                HoTen = txtTen.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhanLoai = cboPhanLoai.SelectedItem?.ToString() ?? "Thạc Sĩ",
                AnhPath = pic.ImageLocation ?? ""
            };

            if (gv.MaGV == "" || gv.HoTen == "")
            {
                MessageBox.Show("Vui lòng nhập Mã GV và Họ Tên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (!forEdit && _ds.Any(x => x.MaGV.Equals(gv.MaGV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã GV đã tồn tại.", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return gv;
        }

        private void ChonDongTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.DataBoundItem is GiangVien g && g.MaGV.Equals(ma, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgv.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void ClearInputs()
        {
            txtMa.Clear(); txtTen.Clear(); txtSDT.Clear(); txtEmail.Clear();
            cboGioiTinh.SelectedIndex = 0; cboPhanLoai.SelectedIndex = 1;
            pic.Image = null; pic.ImageLocation = null;
        }

        // ====== Event handlers ======
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files|*.*"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    pic.ImageLocation = ofd.FileName;
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var gv = ThuThap();
            if (gv == null) return;
            _ds.Add(gv);
            ChonDongTheoMa(gv.MaGV);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var rowObj2 = dgv.CurrentRow != null ? dgv.CurrentRow.DataBoundItem : null;
            var cur = rowObj2 as GiangVien;
            if (cur == null) { MessageBox.Show("Chưa chọn dòng để sửa.", "Thông báo"); return; }
            var tmp = ThuThap(forEdit: true);
            if (tmp == null) return;

            if (!tmp.MaGV.Equals(cur.MaGV, StringComparison.OrdinalIgnoreCase) &&
                _ds.Any(x => x.MaGV.Equals(tmp.MaGV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã GV mới bị trùng.", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cur.MaGV = tmp.MaGV; cur.HoTen = tmp.HoTen; cur.GioiTinh = tmp.GioiTinh;
            cur.SDT = tmp.SDT; cur.Email = tmp.Email; cur.PhanLoai = tmp.PhanLoai;
            cur.AnhPath = tmp.AnhPath;

            dgv.Refresh();
            ChonDongTheoMa(cur.MaGV);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var rowObj3 = dgv.CurrentRow != null ? dgv.CurrentRow.DataBoundItem : null;
            var gv = rowObj3 as GiangVien;
            if (gv == null) { MessageBox.Show("Chưa chọn dòng để xóa.", "Thông báo"); return; }
            if (MessageBox.Show($"Xóa giảng viên '{gv.HoTen}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ds.Remove(gv);
                ClearInputs();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();
    }
}
