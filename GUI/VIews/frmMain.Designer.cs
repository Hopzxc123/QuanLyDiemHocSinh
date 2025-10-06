using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

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

            // ======= MÀU SẮC =======
            Color teal = Color.FromArgb(0, 155, 159);              
            Color leftPanelColor = Color.FromArgb(198, 234, 234);  
            Color rightPanelColor = Color.White;                   
            Color buttonOrange = Color.FromArgb(255, 165, 90);


            // ===== FORM =====
            this.Text = "THÔNG TIN GIẢNG VIÊN";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1100, 600);
            this.BackColor = Color.White;
          
            // ===== TITLE =====
            lblTitle = new Label
            {
                Text = "THÔNG TIN GIẢNG VIÊN",
                Dock = DockStyle.Top,
                Height = 60,
                Font = new Font("Times New Roman", 36, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 235, 0),
                BackColor = teal,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ===== SPLIT CONTAINER =====
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 470,
                SplitterWidth = 6,                         
                   
            };

            splitMain.Panel1.BackColor = teal;
            splitMain.Panel2.BackColor = teal;
            
            splitMain.Panel1.Padding = new Padding(10, 10, 10, 10);
            splitMain.Panel2.Padding = new Padding(10, 10, 10, 10);


            // ===== Add vào Form theo đúng thứ tự =====
            this.Controls.Add(splitMain);
            this.Controls.Add(lblTitle);


            // ===== LEFT: Thông tin chi tiết =====
            groupDetail = new GroupBox
            {
                Text = "Thông tin chi tiết",
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                ForeColor = Color.Black,                        
                Dock = DockStyle.Fill,
                Margin = new Padding(10),                     
                Padding = new Padding(12),

                // giữ nền bên trong là xanh nhạt
                BackColor = leftPanelColor
            };
            splitMain.Panel1.Controls.Add(groupDetail);

            pnlLeft = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(8),           
                BackColor = leftPanelColor                      
            };
            pnlLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            pnlLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            groupDetail.Controls.Add(pnlLeft);


            // ===== LABELS =====
            var lblMa = new Label { Text = "Mã GV", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };
            var lblTen = new Label { Text = "Họ Tên", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };
            var lblGT = new Label { Text = "Giới tính", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };
            var lblSDT = new Label { Text = "SĐT", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };
            var lblMail = new Label { Text = "Email", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };
            var lblPL = new Label { Text = "Phân loại", AutoSize = true, Font = new Font("Times New Roman", 14, FontStyle.Bold), ForeColor = Color.Black, Margin = new Padding(0, 8, 8, 4), Anchor = AnchorStyles.Left };

            // ===== INPUTS =====
            txtMa = new TextBox { Font = new Font("Times New Roman", 14), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            txtTen = new TextBox { Font = new Font("Times New Roman", 14), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboGioiTinh = new ComboBox { Font = new Font("Times New Roman", 14), DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            txtSDT = new TextBox { Font = new Font("Times New Roman", 14), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            txtEmail = new TextBox { Font = new Font("Times New Roman", 14), BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboPhanLoai = new ComboBox { Font = new Font("Times New Roman", 14), DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            cboPhanLoai.Items.AddRange(new object[] { "Cử Nhân", "Thạc Sĩ", "Tiến Sĩ", "PGS", "GS" });

            pic = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, Height = 160, Dock = DockStyle.Fill };
            btnChonAnh = new Button { Text = "Chọn", Height = 45, BackColor = buttonOrange, Font = new Font("Times New Roman", 14, FontStyle.Bold) };
            btnChonAnh.Click += btnChonAnh_Click;

            // ===== ADD TO TABLE =====
            pnlLeft.Controls.Add(lblMa, 0, 0); pnlLeft.Controls.Add(txtMa, 1, 0);
            pnlLeft.Controls.Add(lblTen, 0, 1); pnlLeft.Controls.Add(txtTen, 1, 1);
            pnlLeft.Controls.Add(lblGT, 0, 2); pnlLeft.Controls.Add(cboGioiTinh, 1, 2);
            pnlLeft.Controls.Add(lblSDT, 0, 3); pnlLeft.Controls.Add(txtSDT, 1, 3);
            pnlLeft.Controls.Add(lblMail, 0, 4); pnlLeft.Controls.Add(txtEmail, 1, 4);
            pnlLeft.Controls.Add(lblPL, 0, 5); pnlLeft.Controls.Add(cboPhanLoai, 1, 5);
            pnlLeft.Controls.Add(pic, 1, 6);
            pnlLeft.Controls.Add(btnChonAnh, 1, 7);

            // ===== RIGHT: Danh sách =====
            pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0) };
            splitMain.Panel2.Controls.Add(pnlRight);

            groupList = new GroupBox
            {
                Text = "Danh sách",
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(198, 234, 234)   
            };

            panelGrid = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(198, 234, 234),
                Padding = new Padding(6)
            };

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                GridColor = Color.DarkGray,
                Font = new Font("Times New Roman", 14),
                DefaultCellStyle = new DataGridViewCellStyle { Font = new Font("Times New Roman", 14) },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Times New Roman", 16, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = rightPanelColor
                },
                EnableHeadersVisualStyles = false
            };
            panelGrid.Controls.Add(dgv);
            groupList.Controls.Add(panelGrid);

            // ===== BUTTONS =====
            pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                Width = 160,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(8,40,8,8)
            };

            btnThem = MakeButton("Thêm", buttonOrange, btnThem_Click);
            btnSua = MakeButton("Sửa", buttonOrange, btnSua_Click);
            btnXoa = MakeButton("Xóa", buttonOrange, btnXoa_Click);
            btnThoat = MakeButton("Thoát", buttonOrange, btnThoat_Click);

            pnlButtons.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnThoat });

            // ===== Add to right =====
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
