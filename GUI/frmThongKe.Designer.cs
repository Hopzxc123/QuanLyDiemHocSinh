namespace GUI
{
    partial class frmThongKe
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
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grThongKe = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart = new Guna.Charts.WinForms.GunaChart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cbbHocKy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLineDataset1 = new Guna.Charts.WinForms.GunaLineDataset();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnBaoCao = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaoCaoHK = new Guna.UI2.WinForms.Guna2Button();
            this.btnDiemCaNam = new Guna.UI2.WinForms.Guna2Button();
            this.btnDSHS = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoHS = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoMH = new Guna.UI2.WinForms.Guna2Button();
            this.tabThongKe = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grThongKe.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabThongKe.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(278, 111);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1197, 686);
            this.panel3.TabIndex = 2;
            // 
            // grThongKe
            // 
            this.grThongKe.Controls.Add(this.panel5);
            this.grThongKe.Controls.Add(this.panel4);
            this.grThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.grThongKe.Location = new System.Drawing.Point(3, 73);
            this.grThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grThongKe.Name = "grThongKe";
            this.grThongKe.Padding = new System.Windows.Forms.Padding(4);
            this.grThongKe.Size = new System.Drawing.Size(1199, 669);
            this.grThongKe.TabIndex = 0;
            this.grThongKe.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chart);
            this.panel5.Location = new System.Drawing.Point(3, 76);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1187, 582);
            this.panel5.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont1.FontName = "Arial";
            this.chart.Legend.LabelFont = chartFont1;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1187, 582);
            this.chart.TabIndex = 0;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chart.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            this.chart.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chart.Tooltips.TitleFont = chartFont4;
            this.chart.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            this.chart.XAxes.Ticks = tick1;
            this.chart.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            this.chart.YAxes.Ticks = tick2;
            this.chart.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            this.chart.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            this.chart.ZAxes.Ticks = tick3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLoc);
            this.panel4.Controls.Add(this.cbbHocKy);
            this.panel4.Controls.Add(this.cbbNamHoc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 21);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1191, 69);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnLoc
            // 
            this.btnLoc.AutoSize = true;
            this.btnLoc.Image = global::GUI.Properties.Resources.icons8_search_30;
            this.btnLoc.Location = new System.Drawing.Point(369, 2);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(48, 44);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.BackColor = System.Drawing.Color.Transparent;
            this.cbbHocKy.BorderRadius = 8;
            this.cbbHocKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbHocKy.ItemHeight = 30;
            this.cbbHocKy.Location = new System.Drawing.Point(213, 2);
            this.cbbHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(145, 36);
            this.cbbHocKy.TabIndex = 1;
            this.cbbHocKy.SelectedIndexChanged += new System.EventHandler(this.cbbHocKy_SelectedIndexChanged);
            // 
            // cbbNamHoc
            // 
            this.cbbNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cbbNamHoc.BorderRadius = 8;
            this.cbbNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNamHoc.ItemHeight = 30;
            this.cbbNamHoc.Location = new System.Drawing.Point(15, 2);
            this.cbbNamHoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbNamHoc.Name = "cbbNamHoc";
            this.cbbNamHoc.Size = new System.Drawing.Size(145, 36);
            this.cbbNamHoc.TabIndex = 0;
            this.cbbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cbbNamHoc_SelectedIndexChanged);
            // 
            // gunaLineDataset1
            // 
            this.gunaLineDataset1.BorderColor = System.Drawing.Color.Empty;
            this.gunaLineDataset1.FillColor = System.Drawing.Color.Empty;
            this.gunaLineDataset1.Label = "Phổ điểm học sinh";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(366, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(361, 41);
            this.label7.TabIndex = 0;
            this.label7.Text = "THỐNG KÊ TỔNG QUAN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pnBaoCao);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1199, 739);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pnBaoCao
            // 
            this.pnBaoCao.BorderColor = System.Drawing.Color.White;
            this.pnBaoCao.BorderThickness = 3;
            this.pnBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBaoCao.Location = new System.Drawing.Point(0, 122);
            this.pnBaoCao.Margin = new System.Windows.Forms.Padding(4);
            this.pnBaoCao.Name = "pnBaoCao";
            this.pnBaoCao.Size = new System.Drawing.Size(1199, 617);
            this.pnBaoCao.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.groupBox1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1199, 122);
            this.guna2Panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCaoHK);
            this.groupBox1.Controls.Add(this.btnDiemCaNam);
            this.groupBox1.Controls.Add(this.btnDSHS);
            this.groupBox1.Controls.Add(this.btnBaoCaoHS);
            this.groupBox1.Controls.Add(this.btnBaoCaoMH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1199, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnBaoCaoHK
            // 
            this.btnBaoCaoHK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoHK.BorderRadius = 8;
            this.btnBaoCaoHK.BorderThickness = 1;
            this.btnBaoCaoHK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoHK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoHK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBaoCaoHK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBaoCaoHK.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoHK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCaoHK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoHK.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoHK.Location = new System.Drawing.Point(647, 22);
            this.btnBaoCaoHK.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaoCaoHK.Name = "btnBaoCaoHK";
            this.btnBaoCaoHK.Size = new System.Drawing.Size(131, 57);
            this.btnBaoCaoHK.TabIndex = 4;
            this.btnBaoCaoHK.Text = "Báo cáo học kỳ";
            this.btnBaoCaoHK.Click += new System.EventHandler(this.btnBaoCaoHK_Click);
            // 
            // btnDiemCaNam
            // 
            this.btnDiemCaNam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnDiemCaNam.BorderRadius = 8;
            this.btnDiemCaNam.BorderThickness = 1;
            this.btnDiemCaNam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDiemCaNam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDiemCaNam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDiemCaNam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDiemCaNam.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiemCaNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiemCaNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnDiemCaNam.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiemCaNam.Location = new System.Drawing.Point(491, 22);
            this.btnDiemCaNam.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiemCaNam.Name = "btnDiemCaNam";
            this.btnDiemCaNam.Size = new System.Drawing.Size(131, 57);
            this.btnDiemCaNam.TabIndex = 3;
            this.btnDiemCaNam.Text = "Báo cáo cả năm";
            this.btnDiemCaNam.Click += new System.EventHandler(this.btnDiemCaNam_Click);
            // 
            // btnDSHS
            // 
            this.btnDSHS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnDSHS.BorderRadius = 8;
            this.btnDSHS.BorderThickness = 1;
            this.btnDSHS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDSHS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDSHS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDSHS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDSHS.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnDSHS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDSHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnDSHS.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnDSHS.Location = new System.Drawing.Point(335, 22);
            this.btnDSHS.Margin = new System.Windows.Forms.Padding(4);
            this.btnDSHS.Name = "btnDSHS";
            this.btnDSHS.Size = new System.Drawing.Size(131, 57);
            this.btnDSHS.TabIndex = 2;
            this.btnDSHS.Text = "Danh sách học sinh";
            this.btnDSHS.Click += new System.EventHandler(this.btnDSHS_Click);
            // 
            // btnBaoCaoHS
            // 
            this.btnBaoCaoHS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoHS.BorderRadius = 8;
            this.btnBaoCaoHS.BorderThickness = 1;
            this.btnBaoCaoHS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoHS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoHS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBaoCaoHS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBaoCaoHS.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoHS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCaoHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoHS.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoHS.Location = new System.Drawing.Point(179, 22);
            this.btnBaoCaoHS.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaoCaoHS.Name = "btnBaoCaoHS";
            this.btnBaoCaoHS.Size = new System.Drawing.Size(131, 57);
            this.btnBaoCaoHS.TabIndex = 1;
            this.btnBaoCaoHS.Text = "Báo cáo học sinh";
            this.btnBaoCaoHS.Click += new System.EventHandler(this.btnBaoCaoHS_Click);
            // 
            // btnBaoCaoMH
            // 
            this.btnBaoCaoMH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoMH.BorderRadius = 8;
            this.btnBaoCaoMH.BorderThickness = 1;
            this.btnBaoCaoMH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoMH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBaoCaoMH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBaoCaoMH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBaoCaoMH.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoMH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCaoMH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnBaoCaoMH.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBaoCaoMH.Location = new System.Drawing.Point(23, 22);
            this.btnBaoCaoMH.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaoCaoMH.Name = "btnBaoCaoMH";
            this.btnBaoCaoMH.Size = new System.Drawing.Size(131, 57);
            this.btnBaoCaoMH.TabIndex = 0;
            this.btnBaoCaoMH.Text = "Báo cáo môn học";
            this.btnBaoCaoMH.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // tabThongKe
            // 
            this.tabThongKe.Controls.Add(this.tabPage3);
            this.tabThongKe.Controls.Add(this.tabPage4);
            this.tabThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThongKe.ItemSize = new System.Drawing.Size(180, 40);
            this.tabThongKe.Location = new System.Drawing.Point(0, 0);
            this.tabThongKe.Name = "tabThongKe";
            this.tabThongKe.SelectedIndex = 0;
            this.tabThongKe.Size = new System.Drawing.Size(1213, 793);
            this.tabThongKe.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabThongKe.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.tabThongKe.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabThongKe.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabThongKe.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.tabThongKe.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabThongKe.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tabThongKe.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabThongKe.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabThongKe.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.tabThongKe.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabThongKe.TabButtonSelectedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tabThongKe.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabThongKe.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tabThongKe.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.tabThongKe.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabThongKe.TabIndex = 4;
            this.tabThongKe.TabMenuBackColor = System.Drawing.Color.White;
            this.tabThongKe.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grThongKe);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1205, 745);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Thống kê";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.guna2Panel1);
            this.tabPage4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1205, 745);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Báo cáo";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 793);
            this.Controls.Add(this.tabThongKe);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.grThongKe.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabThongKe.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grThongKe;
        private Guna.Charts.WinForms.GunaChart chart;
        private Guna.Charts.WinForms.GunaLineDataset gunaLineDataset1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2ComboBox cbbHocKy;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNamHoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnBaoCao;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoHK;
        private Guna.UI2.WinForms.Guna2Button btnDiemCaNam;
        private Guna.UI2.WinForms.Guna2Button btnDSHS;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoHS;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoMH;
        private Guna.UI2.WinForms.Guna2TabControl tabThongKe;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}