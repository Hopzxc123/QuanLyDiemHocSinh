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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grThongKe = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart = new Guna.Charts.WinForms.GunaChart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cbbHocKy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLineDataset1 = new Guna.Charts.WinForms.GunaLineDataset();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grThongKe.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 78);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(353, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(361, 41);
            this.label7.TabIndex = 0;
            this.label7.Text = "THỐNG KÊ TỔNG QUAN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grThongKe);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 476);
            this.panel3.TabIndex = 2;
            // 
            // grThongKe
            // 
            this.grThongKe.Controls.Add(this.panel5);
            this.grThongKe.Controls.Add(this.panel4);
            this.grThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.grThongKe.Location = new System.Drawing.Point(0, 0);
            this.grThongKe.Name = "grThongKe";
            this.grThongKe.Size = new System.Drawing.Size(1067, 476);
            this.grThongKe.TabIndex = 0;
            this.grThongKe.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1061, 397);
            this.panel5.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont1.FontName = "Arial";
            this.chart.Legend.LabelFont = chartFont1;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1061, 397);
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
            this.panel4.Location = new System.Drawing.Point(3, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1061, 56);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnLoc
            // 
            this.btnLoc.AutoSize = true;
            this.btnLoc.Image = global::GUI.Properties.Resources.icons8_search_30;
            this.btnLoc.Location = new System.Drawing.Point(369, 3);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(47, 36);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.BackColor = System.Drawing.Color.Transparent;
            this.cbbHocKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbHocKy.ItemHeight = 30;
            this.cbbHocKy.Location = new System.Drawing.Point(213, 3);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(146, 36);
            this.cbbHocKy.TabIndex = 1;
            this.cbbHocKy.SelectedIndexChanged += new System.EventHandler(this.cbbHocKy_SelectedIndexChanged);
            // 
            // cbbNamHoc
            // 
            this.cbbNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cbbNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNamHoc.ItemHeight = 30;
            this.cbbNamHoc.Location = new System.Drawing.Point(15, 3);
            this.cbbNamHoc.Name = "cbbNamHoc";
            this.cbbNamHoc.Size = new System.Drawing.Size(146, 36);
            this.cbbNamHoc.TabIndex = 0;
            this.cbbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cbbNamHoc_SelectedIndexChanged);
            // 
            // gunaLineDataset1
            // 
            this.gunaLineDataset1.BorderColor = System.Drawing.Color.Empty;
            this.gunaLineDataset1.FillColor = System.Drawing.Color.Empty;
            this.gunaLineDataset1.Label = "Phổ điểm học sinh";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.grThongKe.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grThongKe;
        private Guna.Charts.WinForms.GunaChart chart;
        private Guna.Charts.WinForms.GunaLineDataset gunaLineDataset1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2ComboBox cbbHocKy;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNamHoc;
        private System.Windows.Forms.Button btnLoc;
    }
}