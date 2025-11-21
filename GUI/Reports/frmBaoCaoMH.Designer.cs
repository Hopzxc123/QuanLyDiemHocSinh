namespace GUI.Reports
{
    partial class frmBaoCaoMH
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.rpBaoCaoMH = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsTongKetMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.cbbMonHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbHocKy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTongKetMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cbbNamHoc);
            this.guna2Panel1.Controls.Add(this.cbbHocKy);
            this.guna2Panel1.Controls.Add(this.cbbMonHoc);
            this.guna2Panel1.Controls.Add(this.btnXem);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(969, 81);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.rpBaoCaoMH);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 81);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(969, 609);
            this.guna2Panel2.TabIndex = 1;
            // 
            // rpBaoCaoMH
            // 
            this.rpBaoCaoMH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpBaoCaoMH.Location = new System.Drawing.Point(0, 0);
            this.rpBaoCaoMH.Name = "rpBaoCaoMH";
            this.rpBaoCaoMH.ServerReport.BearerToken = null;
            this.rpBaoCaoMH.Size = new System.Drawing.Size(969, 609);
            this.rpBaoCaoMH.TabIndex = 0;
            // 
            // btnXem
            // 
            this.btnXem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnXem.BorderRadius = 4;
            this.btnXem.BorderThickness = 1;
            this.btnXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXem.FillColor = System.Drawing.Color.White;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnXem.Location = new System.Drawing.Point(599, 23);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 36);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.BackColor = System.Drawing.Color.Transparent;
            this.cbbMonHoc.BorderRadius = 10;
            this.cbbMonHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMonHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMonHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMonHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbMonHoc.ItemHeight = 30;
            this.cbbMonHoc.Location = new System.Drawing.Point(430, 23);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(163, 36);
            this.cbbMonHoc.TabIndex = 8;
            this.cbbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cbbMonHoc_SelectedIndexChanged);
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.BackColor = System.Drawing.Color.Transparent;
            this.cbbHocKy.BorderRadius = 10;
            this.cbbHocKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHocKy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbHocKy.ItemHeight = 30;
            this.cbbHocKy.Location = new System.Drawing.Point(261, 23);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(163, 36);
            this.cbbHocKy.TabIndex = 8;
            this.cbbHocKy.SelectedIndexChanged += new System.EventHandler(this.cbbLop_SelectedIndexChanged);
            // 
            // cbbNamHoc
            // 
            this.cbbNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cbbNamHoc.BorderRadius = 10;
            this.cbbNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNamHoc.ItemHeight = 30;
            this.cbbNamHoc.Location = new System.Drawing.Point(92, 23);
            this.cbbNamHoc.Name = "cbbNamHoc";
            this.cbbNamHoc.Size = new System.Drawing.Size(163, 36);
            this.cbbNamHoc.TabIndex = 8;
            this.cbbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cbbNamHoc_SelectedIndexChanged);
            // 
            // frmBaoCaoMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 690);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "frmBaoCaoMH";
            this.Text = "frmBaoCaoMH";
            this.Load += new System.EventHandler(this.frmBaoCaoMH_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsTongKetMonHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Microsoft.Reporting.WinForms.ReportViewer rpBaoCaoMH;
        private System.Windows.Forms.BindingSource bsTongKetMonHoc;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2ComboBox cbbMonHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNamHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbbHocKy;
    }
}