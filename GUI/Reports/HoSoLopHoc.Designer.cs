namespace GUI.Reports
{
    partial class HoSoLopHoc
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cboLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.reportViewer1);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(937, 557);
            this.guna2Panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 80);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(937, 477);
            this.reportViewer1.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.cboLop);
            this.guna2Panel2.Controls.Add(this.cboNamHoc);
            this.guna2Panel2.Controls.Add(this.btnXem);
            this.guna2Panel2.Controls.Add(this.lblLop);
            this.guna2Panel2.Controls.Add(this.lblNamHoc);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(937, 80);
            this.guna2Panel2.TabIndex = 0;
            // 
            // cboLop
            // 
            this.cboLop.BackColor = System.Drawing.Color.Transparent;
            this.cboLop.BorderRadius = 10;
            this.cboLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLop.ItemHeight = 30;
            this.cboLop.Location = new System.Drawing.Point(335, 17);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(163, 36);
            this.cboLop.TabIndex = 10;
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboNamHoc.BorderRadius = 10;
            this.cboNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNamHoc.ItemHeight = 30;
            this.cboNamHoc.Location = new System.Drawing.Point(105, 17);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(163, 36);
            this.cboNamHoc.TabIndex = 9;
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
            this.btnXem.Location = new System.Drawing.Point(516, 17);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 36);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(288, 26);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(38, 20);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp:";
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamHoc.Location = new System.Drawing.Point(18, 26);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(77, 20);
            this.lblNamHoc.TabIndex = 1;
            this.lblNamHoc.Text = "Năm Học:";
            // 
            // HoSoLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 557);
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HoSoLopHoc";
            this.Text = "HoSoLopHoc";
            this.Load += new System.EventHandler(this.HoSoLopHoc_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblNamHoc;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2ComboBox cboLop;
        private Guna.UI2.WinForms.Guna2ComboBox cboNamHoc;
    }
}