namespace GUI.UserControls
{
    partial class ucThongKeTongQuan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblHocSinh = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHocSinhGioi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinhGioi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 71);
            this.panel1.TabIndex = 0;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(299, 25);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(280, 32);
            this.label.TabIndex = 0;
            this.label.Text = "THỐNG KÊ TỔNG QUAN";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.lblMonHoc);
            this.panel2.Controls.Add(this.lblLop);
            this.panel2.Controls.Add(this.lblHocSinh);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 295);
            this.panel2.TabIndex = 1;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnXuatExcel.BorderRadius = 8;
            this.btnXuatExcel.BorderThickness = 1;
            this.btnXuatExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(53, 191);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(91, 38);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "In File";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonHoc.ForeColor = System.Drawing.Color.Black;
            this.lblMonHoc.Location = new System.Drawing.Point(138, 139);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(43, 17);
            this.lblMonHoc.TabIndex = 5;
            this.lblMonHoc.Text = "label6";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.ForeColor = System.Drawing.Color.Black;
            this.lblLop.Location = new System.Drawing.Point(138, 99);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(43, 17);
            this.lblLop.TabIndex = 4;
            this.lblLop.Text = "label5";
            // 
            // lblHocSinh
            // 
            this.lblHocSinh.AutoSize = true;
            this.lblHocSinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocSinh.ForeColor = System.Drawing.Color.Black;
            this.lblHocSinh.Location = new System.Drawing.Point(138, 54);
            this.lblHocSinh.Name = "lblHocSinh";
            this.lblHocSinh.Size = new System.Drawing.Size(43, 17);
            this.lblHocSinh.TabIndex = 3;
            this.lblHocSinh.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng số môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng số lớp học:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số học sinh:";
            // 
            // dgvHocSinhGioi
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocSinhGioi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHocSinhGioi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHocSinhGioi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHocSinhGioi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocSinhGioi.GridColor = System.Drawing.Color.White;
            this.dgvHocSinhGioi.Location = new System.Drawing.Point(200, 71);
            this.dgvHocSinhGioi.Name = "dgvHocSinhGioi";
            this.dgvHocSinhGioi.Size = new System.Drawing.Size(685, 295);
            this.dgvHocSinhGioi.TabIndex = 2;
            // 
            // ucThongKeTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHocSinhGioi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucThongKeTongQuan";
            this.Size = new System.Drawing.Size(885, 366);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinhGioi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
       
        
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblHocSinh;
        private System.Windows.Forms.Label label;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvHocSinhGioi;
    }
}
