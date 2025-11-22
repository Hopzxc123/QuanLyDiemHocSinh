namespace GUI
{
    partial class frmTrangChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChinh));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHam = new Guna.UI2.WinForms.Guna2PictureBox();
            this.plQLHocSinh = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQLHS = new Guna.UI2.WinForms.Guna2Button();
            this.plQLDiemHS = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQLDiem = new Guna.UI2.WinForms.Guna2Button();
            this.plQLLop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQLLop = new Guna.UI2.WinForms.Guna2Button();
            this.plQLMonHoc = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQLMonHoc = new Guna.UI2.WinForms.Guna2Button();
            this.plQLGiaoVien = new Guna.UI2.WinForms.Guna2Panel();
            this.btnQLGiaoVien = new Guna.UI2.WinForms.Guna2Button();
            this.plDangXuat = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.ptbavatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.plView = new Guna.UI2.WinForms.Guna2Panel();
            this.sidebarTransition = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.plQLHocSinh.SuspendLayout();
            this.plQLDiemHS.SuspendLayout();
            this.plQLLop.SuspendLayout();
            this.plQLMonHoc.SuspendLayout();
            this.plQLGiaoVien.SuspendLayout();
            this.plDangXuat.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbavatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Controls.Add(this.btnHam);
            this.sidebarTransition.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1262, 39);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnHam
            // 
            this.sidebarTransition.SetDecoration(this.btnHam, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnHam.Image = global::GUI.Properties.Resources.burger_menu_svgrepo_com__3_;
            this.btnHam.ImageRotate = 0F;
            this.btnHam.Location = new System.Drawing.Point(12, 12);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(19, 20);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHam.TabIndex = 2;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // plQLHocSinh
            // 
            this.plQLHocSinh.Controls.Add(this.btnQLHS);
            this.sidebarTransition.SetDecoration(this.plQLHocSinh, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plQLHocSinh.Location = new System.Drawing.Point(3, 100);
            this.plQLHocSinh.Name = "plQLHocSinh";
            this.plQLHocSinh.Size = new System.Drawing.Size(194, 67);
            this.plQLHocSinh.TabIndex = 4;
            this.plQLHocSinh.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel7_Paint);
            // 
            // btnQLHS
            // 
            this.btnQLHS.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnQLHS, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnQLHS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLHS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLHS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLHS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLHS.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLHS.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnQLHS.ForeColor = System.Drawing.Color.White;
            this.btnQLHS.HoverState.FillColor = System.Drawing.Color.White;
            this.btnQLHS.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLHS.Image = global::GUI.Properties.Resources.icons8_student_50;
            this.btnQLHS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLHS.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQLHS.Location = new System.Drawing.Point(0, 0);
            this.btnQLHS.Name = "btnQLHS";
            this.btnQLHS.Size = new System.Drawing.Size(191, 67);
            this.btnQLHS.TabIndex = 3;
            this.btnQLHS.Text = "QL Học Sinh";
            this.btnQLHS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLHS.Click += new System.EventHandler(this.button1_Click);
            // 
            // plQLDiemHS
            // 
            this.plQLDiemHS.Controls.Add(this.btnQLDiem);
            this.sidebarTransition.SetDecoration(this.plQLDiemHS, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plQLDiemHS.Location = new System.Drawing.Point(3, 173);
            this.plQLDiemHS.Name = "plQLDiemHS";
            this.plQLDiemHS.Size = new System.Drawing.Size(194, 67);
            this.plQLDiemHS.TabIndex = 4;
            this.plQLDiemHS.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel4_Paint);
            // 
            // btnQLDiem
            // 
            this.btnQLDiem.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnQLDiem, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnQLDiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLDiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLDiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLDiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnQLDiem.ForeColor = System.Drawing.Color.White;
            this.btnQLDiem.HoverState.FillColor = System.Drawing.Color.White;
            this.btnQLDiem.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLDiem.Image = global::GUI.Properties.Resources.icons8_inspection_50;
            this.btnQLDiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLDiem.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQLDiem.Location = new System.Drawing.Point(0, 0);
            this.btnQLDiem.Name = "btnQLDiem";
            this.btnQLDiem.Size = new System.Drawing.Size(194, 67);
            this.btnQLDiem.TabIndex = 3;
            this.btnQLDiem.Text = "QL điểm học sinh";
            this.btnQLDiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLDiem.Click += new System.EventHandler(this.button2_Click);
            // 
            // plQLLop
            // 
            this.plQLLop.Controls.Add(this.btnQLLop);
            this.sidebarTransition.SetDecoration(this.plQLLop, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plQLLop.Location = new System.Drawing.Point(3, 246);
            this.plQLLop.Name = "plQLLop";
            this.plQLLop.Size = new System.Drawing.Size(194, 67);
            this.plQLLop.TabIndex = 4;
            this.plQLLop.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel5_Paint);
            // 
            // btnQLLop
            // 
            this.btnQLLop.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnQLLop, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnQLLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLLop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnQLLop.ForeColor = System.Drawing.Color.White;
            this.btnQLLop.HoverState.FillColor = System.Drawing.Color.White;
            this.btnQLLop.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLLop.Image = global::GUI.Properties.Resources.icons8_classroom_100;
            this.btnQLLop.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLLop.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQLLop.Location = new System.Drawing.Point(0, 0);
            this.btnQLLop.Name = "btnQLLop";
            this.btnQLLop.Size = new System.Drawing.Size(191, 67);
            this.btnQLLop.TabIndex = 3;
            this.btnQLLop.Text = "QL lớp";
            this.btnQLLop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLLop.Click += new System.EventHandler(this.button3_Click);
            // 
            // plQLMonHoc
            // 
            this.plQLMonHoc.Controls.Add(this.btnQLMonHoc);
            this.sidebarTransition.SetDecoration(this.plQLMonHoc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plQLMonHoc.Location = new System.Drawing.Point(3, 319);
            this.plQLMonHoc.Name = "plQLMonHoc";
            this.plQLMonHoc.Size = new System.Drawing.Size(194, 67);
            this.plQLMonHoc.TabIndex = 4;
            this.plQLMonHoc.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // btnQLMonHoc
            // 
            this.btnQLMonHoc.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnQLMonHoc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnQLMonHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLMonHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLMonHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLMonHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLMonHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLMonHoc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnQLMonHoc.ForeColor = System.Drawing.Color.White;
            this.btnQLMonHoc.HoverState.FillColor = System.Drawing.Color.White;
            this.btnQLMonHoc.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLMonHoc.Image = global::GUI.Properties.Resources.icons8_open_book_50;
            this.btnQLMonHoc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLMonHoc.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQLMonHoc.Location = new System.Drawing.Point(0, 0);
            this.btnQLMonHoc.Name = "btnQLMonHoc";
            this.btnQLMonHoc.Size = new System.Drawing.Size(191, 67);
            this.btnQLMonHoc.TabIndex = 3;
            this.btnQLMonHoc.Text = "QL môn học";
            this.btnQLMonHoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLMonHoc.Click += new System.EventHandler(this.button4_Click);
            // 
            // plQLGiaoVien
            // 
            this.plQLGiaoVien.Controls.Add(this.btnQLGiaoVien);
            this.sidebarTransition.SetDecoration(this.plQLGiaoVien, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plQLGiaoVien.Location = new System.Drawing.Point(3, 392);
            this.plQLGiaoVien.Name = "plQLGiaoVien";
            this.plQLGiaoVien.Size = new System.Drawing.Size(194, 67);
            this.plQLGiaoVien.TabIndex = 4;
            this.plQLGiaoVien.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // btnQLGiaoVien
            // 
            this.btnQLGiaoVien.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnQLGiaoVien, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnQLGiaoVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLGiaoVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLGiaoVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLGiaoVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLGiaoVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnQLGiaoVien.ForeColor = System.Drawing.Color.White;
            this.btnQLGiaoVien.HoverState.FillColor = System.Drawing.Color.White;
            this.btnQLGiaoVien.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnQLGiaoVien.Image = global::GUI.Properties.Resources.icons8_teacher_50;
            this.btnQLGiaoVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLGiaoVien.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQLGiaoVien.Location = new System.Drawing.Point(0, 0);
            this.btnQLGiaoVien.Name = "btnQLGiaoVien";
            this.btnQLGiaoVien.Size = new System.Drawing.Size(191, 67);
            this.btnQLGiaoVien.TabIndex = 3;
            this.btnQLGiaoVien.Text = "QL giáo viên";
            this.btnQLGiaoVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLGiaoVien.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // plDangXuat
            // 
            this.plDangXuat.Controls.Add(this.btnThongKe);
            this.sidebarTransition.SetDecoration(this.plDangXuat, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plDangXuat.Location = new System.Drawing.Point(3, 465);
            this.plDangXuat.Name = "plDangXuat";
            this.plDangXuat.Size = new System.Drawing.Size(194, 67);
            this.plDangXuat.TabIndex = 4;
            this.plDangXuat.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel6_Paint);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnThongKe.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.btnThongKe, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.HoverState.FillColor = System.Drawing.Color.White;
            this.btnThongKe.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnThongKe.Image = global::GUI.Properties.Resources.icons8_analytics_30;
            this.btnThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.ImageSize = new System.Drawing.Size(30, 30);
            this.btnThongKe.Location = new System.Drawing.Point(0, 0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(191, 67);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.Click += new System.EventHandler(this.buttonThongKe_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.sidebar.BorderColor = System.Drawing.Color.White;
            this.sidebar.Controls.Add(this.guna2Button1);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.plQLHocSinh);
            this.sidebar.Controls.Add(this.plQLMonHoc);
            this.sidebar.Controls.Add(this.plQLGiaoVien);
            this.sidebar.Controls.Add(this.plQLLop);
            this.sidebar.Controls.Add(this.plDangXuat);
            this.sidebar.Controls.Add(this.plQLDiemHS);
            this.sidebarTransition.SetDecoration(this.sidebar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 39);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(194, 710);
            this.sidebar.TabIndex = 5;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebar_Paint);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.guna2Button1.BorderRadius = 8;
            this.sidebarTransition.SetDecoration(this.guna2Button1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.guna2Button1.Image = global::GUI.Properties.Resources.icons8_logout_50;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(6, 527);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(191, 67);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Đăng xuất";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenTaiKhoan);
            this.panel1.Controls.Add(this.ptbavatar);
            this.sidebarTransition.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 100);
            this.panel1.TabIndex = 6;
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.sidebarTransition.SetDecoration(this.lblTenTaiKhoan, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTenTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTenTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(57, 36);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(90, 30);
            this.lblTenTaiKhoan.TabIndex = 6;
            this.lblTenTaiKhoan.Text = "ADmin";
            this.lblTenTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbavatar
            // 
            this.sidebarTransition.SetDecoration(this.ptbavatar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.ptbavatar.ImageRotate = 0F;
            this.ptbavatar.Location = new System.Drawing.Point(6, 22);
            this.ptbavatar.Name = "ptbavatar";
            this.ptbavatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptbavatar.Size = new System.Drawing.Size(51, 55);
            this.ptbavatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbavatar.TabIndex = 5;
            this.ptbavatar.TabStop = false;
            this.ptbavatar.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // plView
            // 
            this.sidebarTransition.SetDecoration(this.plView, Guna.UI2.AnimatorNS.DecorationType.None);
            this.plView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plView.Location = new System.Drawing.Point(194, 39);
            this.plView.Name = "plView";
            this.plView.Size = new System.Drawing.Size(1068, 710);
            this.plView.TabIndex = 6;
            this.plView.Paint += new System.Windows.Forms.PaintEventHandler(this.plView_Paint);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.sidebarTransition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.sidebarTransition.DefaultAnimation = animation1;
            this.sidebarTransition.MaxAnimationTime = 800;
            this.sidebarTransition.TimeStep = 0.03F;
            // 
            // frmTrangChinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1262, 749);
            this.Controls.Add(this.plView);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.guna2Panel1);
            this.sidebarTransition.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.Name = "frmTrangChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTrangChinh";
            this.Load += new System.EventHandler(this.fTrangChinh_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.plQLHocSinh.ResumeLayout(false);
            this.plQLDiemHS.ResumeLayout(false);
            this.plQLLop.ResumeLayout(false);
            this.plQLMonHoc.ResumeLayout(false);
            this.plQLGiaoVien.ResumeLayout(false);
            this.plDangXuat.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbavatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btnHam;
        private Guna.UI2.WinForms.Guna2Panel plQLHocSinh;
        private Guna.UI2.WinForms.Guna2Panel plQLDiemHS;
        private Guna.UI2.WinForms.Guna2Panel plQLLop;
        private Guna.UI2.WinForms.Guna2Panel plQLMonHoc;
        private Guna.UI2.WinForms.Guna2Panel plQLGiaoVien;
        private Guna.UI2.WinForms.Guna2Panel plDangXuat;
        private Guna.UI2.WinForms.Guna2Panel sidebar;
        private Guna.UI2.WinForms.Guna2Panel plView;
        private Guna.UI2.WinForms.Guna2Button btnQLHS;
        private Guna.UI2.WinForms.Guna2Button btnQLDiem;
        private Guna.UI2.WinForms.Guna2Button btnQLLop;
        private Guna.UI2.WinForms.Guna2Button btnQLMonHoc;
        private Guna.UI2.WinForms.Guna2Button btnQLGiaoVien;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbavatar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTenTaiKhoan;
        private Guna.UI2.WinForms.Guna2Transition sidebarTransition;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}