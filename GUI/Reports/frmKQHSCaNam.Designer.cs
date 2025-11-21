namespace GUI.Reports
{
    partial class frmKQHSCaNam
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rpvKQHSCaNam = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cbbNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 560);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rpvKQHSCaNam);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1027, 436);
            this.panel3.TabIndex = 1;
            // 
            // rpvKQHSCaNam
            // 
            this.rpvKQHSCaNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvKQHSCaNam.Location = new System.Drawing.Point(0, 0);
            this.rpvKQHSCaNam.Name = "rpvKQHSCaNam";
            this.rpvKQHSCaNam.ServerReport.BearerToken = null;
            this.rpvKQHSCaNam.Size = new System.Drawing.Size(1027, 436);
            this.rpvKQHSCaNam.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXem);
            this.panel2.Controls.Add(this.cbbLop);
            this.panel2.Controls.Add(this.lblLop);
            this.panel2.Controls.Add(this.cbbNamHoc);
            this.panel2.Controls.Add(this.lblNamHoc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 124);
            this.panel2.TabIndex = 0;
            // 
            // cbbLop
            // 
            this.cbbLop.BackColor = System.Drawing.Color.Transparent;
            this.cbbLop.BorderRadius = 10;
            this.cbbLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbLop.ItemHeight = 30;
            this.cbbLop.Location = new System.Drawing.Point(500, 44);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(163, 36);
            this.cbbLop.TabIndex = 1;
            // 
            // lblLop
            // 
            this.lblLop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(407, 44);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(100, 36);
            this.lblLop.TabIndex = 3;
            this.lblLop.Text = "Lớp:";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbbNamHoc.Location = new System.Drawing.Point(174, 44);
            this.cbbNamHoc.Name = "cbbNamHoc";
            this.cbbNamHoc.Size = new System.Drawing.Size(163, 36);
            this.cbbNamHoc.TabIndex = 0;
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamHoc.Location = new System.Drawing.Point(54, 44);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(100, 36);
            this.lblNamHoc.TabIndex = 0;
            this.lblNamHoc.Text = "Năm học:";
            this.lblNamHoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnXem.Location = new System.Drawing.Point(738, 44);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 36);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmKQHSCaNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 560);
            this.Controls.Add(this.panel1);
            this.Name = "frmKQHSCaNam";
            this.Text = "frmKQHSCaNam";
            this.Load += new System.EventHandler(this.frmKQHSCaNam_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Microsoft.Reporting.WinForms.ReportViewer rpvKQHSCaNam;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNamHoc;
        private System.Windows.Forms.Label lblNamHoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbbLop;
        private System.Windows.Forms.Label lblLop;
        private Guna.UI2.WinForms.Guna2Button btnXem;
    }
}