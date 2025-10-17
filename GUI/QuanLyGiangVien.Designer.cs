using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class QuanLyGiangVien
    {
        private System.ComponentModel.IContainer components = null;

        // NEW: layout chính 2 hàng (20% title / 80% nội dung)
        private TableLayoutPanel mainLayout;

        // Top title
        private Label lblTitle;

        // Split & panels
        private SplitContainer splitMain;
        private Panel pnlRight;

        // Left
        private GroupBox groupDetail;
        private TableLayoutPanel pnlLeft;
        private TextBox txtMa, txtTen, txtSDT, txtEmail;
        private ComboBox cboGioiTinh, cboPhanLoai;
        private PictureBox pic;
        private Button btnChonAnh;

        // Right
        private GroupBox groupList;
        private Panel panelGrid;
        private DataGridView dgv;
        private FlowLayoutPanel pnlButtons;
        private Button btnThem, btnSua, btnXoa, btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Màu
            Color teal = Color.FromArgb(0, 155, 159);           // header
            Color leftPanelColor = Color.FromArgb(198, 234, 238); // nền panel trái
            Color buttonOrange = Color.FromArgb(255, 165, 90);

            // ===== FORM =====
            this.Text = "THÔNG TIN GIẢNG VIÊN";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1200, 700);
            this.BackColor = Color.White;

            // ===== MAIN LAYOUT: 20% title / 80% nội dung =====
            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            this.Controls.Add(mainLayout);

            // ===== TITLE =====
            lblTitle = new Label
            {
                Text = "THÔNG TIN GIẢNG VIÊN",
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 235, 0),
                BackColor = teal,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0)
            };
            mainLayout.Controls.Add(lblTitle, 0, 0);

            // ===== SPLIT CONTAINER =====
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 440,
                SplitterWidth = 6
            };
            splitMain.Panel1.Padding = new Padding(20);
            splitMain.Panel2.Padding = new Padding(10);

            splitMain.Panel1.BackColor = leftPanelColor;
            splitMain.Panel2.BackColor = Color.White;
            mainLayout.Controls.Add(splitMain, 0, 1);

            // ===== LEFT: Thông tin chi tiết =====
            groupDetail = new GroupBox
            {
                Text = "Thông tin chi tiết",
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 0, 0, 0),
                Font = new Font("Times New Roman", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = leftPanelColor
            };
            splitMain.Panel1.Controls.Add(groupDetail);

            // Bảng 2 cột
            pnlLeft = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(0)
            };
            pnlLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            pnlLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            groupDetail.Controls.Add(pnlLeft);

            // Nhãn
            var lblMa = new Label { Text = "Mã GV", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };
            var lblTen = new Label { Text = "Họ Tên", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };
            var lblGT = new Label { Text = "Giới tính", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };
            var lblSDT = new Label { Text = "SĐT", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };
            var lblMail = new Label { Text = "Email", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };
            var lblPL = new Label { Text = "Phân loại", AutoSize = true, Font = new Font("Times New Roman", 13, FontStyle.Bold), ForeColor = Color.Black, Anchor = AnchorStyles.Left, Margin = new Padding(0, 8, 8, 4) };

            // Input
            txtMa = new TextBox { Font = new Font("Times New Roman", 13), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            txtTen = new TextBox { Font = new Font("Times New Roman", 13), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboGioiTinh = new ComboBox { Font = new Font("Times New Roman", 13), DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            txtSDT = new TextBox { Font = new Font("Times New Roman", 13), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            txtEmail = new TextBox { Font = new Font("Times New Roman", 13), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboPhanLoai = new ComboBox { Font = new Font("Times New Roman", 13), DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboPhanLoai.Items.AddRange(new object[] { "Cử Nhân", "Thạc Sĩ", "Tiến Sĩ", "PGS", "GS" });

            pic = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, Height = 150, Dock = DockStyle.Fill, BackColor = Color.White };
            btnChonAnh = new Button { Text = "Chọn ảnh", Height = 40, BackColor = buttonOrange, Font = new Font("Times New Roman", 13, FontStyle.Bold) };
            btnChonAnh.Click += btnChonAnh_Click;

            // Add vào bảng
            pnlLeft.Controls.Add(lblMa, 0, 0); pnlLeft.Controls.Add(txtMa, 1, 0);
            pnlLeft.Controls.Add(lblTen, 0, 1); pnlLeft.Controls.Add(txtTen, 1, 1);
            pnlLeft.Controls.Add(lblGT, 0, 2); pnlLeft.Controls.Add(cboGioiTinh, 1, 2);
            pnlLeft.Controls.Add(lblSDT, 0, 3); pnlLeft.Controls.Add(txtSDT, 1, 3);
            pnlLeft.Controls.Add(lblMail, 0, 4); pnlLeft.Controls.Add(txtEmail, 1, 4);
            pnlLeft.Controls.Add(lblPL, 0, 5); pnlLeft.Controls.Add(cboPhanLoai, 1, 5);
            pnlLeft.Controls.Add(pic, 1, 6);
            pnlLeft.Controls.Add(btnChonAnh, 1, 7);

            // ===== RIGHT =====
            pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10), BackColor = Color.White };
            splitMain.Panel2.Controls.Add(pnlRight);

            groupList = new GroupBox
            {
                Text = "Danh sách",
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                Font = new Font("Times New Roman", 16, FontStyle.Bold),
                BackColor = Color.White
            };
            panelGrid = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(6) };

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                GridColor = Color.Silver,
                EnableHeadersVisualStyles = false
            };
            panelGrid.Controls.Add(dgv);
            groupList.Controls.Add(panelGrid);

            // Nút bên phải
            pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 160,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(8, 24, 8, 8),
                BackColor = Color.White
            };
            btnThem = MakeButton("Thêm", buttonOrange, btnThem_Click);
            btnSua = MakeButton("Sửa", buttonOrange, btnSua_Click);
            btnXoa = MakeButton("Xóa", buttonOrange, btnXoa_Click);
            btnThoat = MakeButton("Thoát", buttonOrange, btnThoat_Click);
            pnlButtons.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnThoat });

            // Add vào Panel phải
            pnlRight.Controls.Add(groupList);
            pnlRight.Controls.Add(pnlButtons);
        }

        private Button MakeButton(string text, Color bg, System.EventHandler handler)
        {
            var btn = new Button
            {
                Text = text,
                Width = 135,
                Height = 50,
                Margin = new Padding(8, 12, 8, 0),
                BackColor = bg,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += handler;
            return btn;
        }
    }
}
