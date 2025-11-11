namespace GUI.frmQLDiemHS
{
    partial class frmChiTietDiemHocSinh
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtDiemCuoiKy = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiemTrenLop = new System.Windows.Forms.TextBox();
            this.txtDiemGiuaKy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.v = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbHocKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.diemTrenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemGiuaKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemTongKet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cbbtHocKy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 586);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.txtLop);
            this.groupBox1.Controls.Add(this.txtDiemCuoiKy);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDiemTrenLop);
            this.groupBox1.Controls.Add(this.txtDiemGiuaKy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.v);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbbHocKy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbMonHoc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 586);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin học sinh";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoa.Location = new System.Drawing.Point(189, 517);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 44);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSua.Location = new System.Drawing.Point(103, 517);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 44);
            this.btnSua.TabIndex = 33;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtLop
            // 
            this.txtLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtLop.Location = new System.Drawing.Point(37, 131);
            this.txtLop.Name = "txtLop";
            this.txtLop.ReadOnly = true;
            this.txtLop.Size = new System.Drawing.Size(209, 23);
            this.txtLop.TabIndex = 32;
            // 
            // txtDiemCuoiKy
            // 
            this.txtDiemCuoiKy.Location = new System.Drawing.Point(132, 425);
            this.txtDiemCuoiKy.Name = "txtDiemCuoiKy";
            this.txtDiemCuoiKy.Size = new System.Drawing.Size(113, 23);
            this.txtDiemCuoiKy.TabIndex = 25;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThem.Location = new System.Drawing.Point(18, 517);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 44);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Điểm cuối kì";
            // 
            // txtDiemTrenLop
            // 
            this.txtDiemTrenLop.Location = new System.Drawing.Point(132, 331);
            this.txtDiemTrenLop.Name = "txtDiemTrenLop";
            this.txtDiemTrenLop.Size = new System.Drawing.Size(113, 23);
            this.txtDiemTrenLop.TabIndex = 21;
            // 
            // txtDiemGiuaKy
            // 
            this.txtDiemGiuaKy.Location = new System.Drawing.Point(133, 375);
            this.txtDiemGiuaKy.Name = "txtDiemGiuaKy";
            this.txtDiemGiuaKy.Size = new System.Drawing.Size(113, 23);
            this.txtDiemGiuaKy.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Điểm giữa kì";
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(34, 337);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(92, 17);
            this.v.TabIndex = 20;
            this.v.Text = "Điểm trên lớp";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHoTen.Location = new System.Drawing.Point(37, 62);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(209, 23);
            this.txtHoTen.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(34, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Họ tên HS";
            // 
            // cbbHocKy
            // 
            this.cbbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbHocKy.FormattingEnabled = true;
            this.cbbHocKy.Location = new System.Drawing.Point(36, 283);
            this.cbbHocKy.Name = "cbbHocKy";
            this.cbbHocKy.Size = new System.Drawing.Size(209, 24);
            this.cbbHocKy.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(33, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(33, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Học kì";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(33, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Môn học";
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(36, 207);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(209, 24);
            this.cbbMonHoc.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(282, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 586);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 71);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(748, 456);
            this.panel5.TabIndex = 31;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDiem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 456);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách điểm ";
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diemTrenLop,
            this.diemGiuaKy,
            this.diemThi,
            this.diemTongKet,
            this.monHoc,
            this.hocKy});
            this.dgvDiem.Location = new System.Drawing.Point(3, 18);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowHeadersWidth = 51;
            this.dgvDiem.RowTemplate.Height = 24;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(742, 435);
            this.dgvDiem.TabIndex = 0;
            this.dgvDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellClick);
            this.dgvDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellContentClick);
            // 
            // diemTrenLop
            // 
            this.diemTrenLop.HeaderText = "Điểm trên lớp";
            this.diemTrenLop.MinimumWidth = 6;
            this.diemTrenLop.Name = "diemTrenLop";
            // 
            // diemGiuaKy
            // 
            this.diemGiuaKy.HeaderText = "Điểm Giữa Kỳ";
            this.diemGiuaKy.MinimumWidth = 6;
            this.diemGiuaKy.Name = "diemGiuaKy";
            // 
            // diemThi
            // 
            this.diemThi.HeaderText = "Điểm Thi";
            this.diemThi.MinimumWidth = 6;
            this.diemThi.Name = "diemThi";
            // 
            // diemTongKet
            // 
            this.diemTongKet.HeaderText = "Điểm Tổng Kết";
            this.diemTongKet.MinimumWidth = 6;
            this.diemTongKet.Name = "diemTongKet";
            // 
            // monHoc
            // 
            this.monHoc.HeaderText = "Môn học";
            this.monHoc.MinimumWidth = 6;
            this.monHoc.Name = "monHoc";
            // 
            // hocKy
            // 
            this.hocKy.HeaderText = "Học Kỳ";
            this.hocKy.MinimumWidth = 6;
            this.hocKy.Name = "hocKy";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnIn);
            this.panel4.Controls.Add(this.btnThoat);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 527);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(748, 59);
            this.panel4.TabIndex = 30;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(662, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 44);
            this.btnThoat.TabIndex = 28;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 71);
            this.panel3.TabIndex = 29;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLoc);
            this.groupBox3.Controls.Add(this.cbbtHocKy);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnReload);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(748, 71);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnIn
            // 
            this.btnIn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIn.Image = global::GUI.Properties.Resources.icons8_teacher_50;
            this.btnIn.Location = new System.Drawing.Point(581, 6);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 44);
            this.btnIn.TabIndex = 37;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLoc.Location = new System.Drawing.Point(608, 23);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 42);
            this.btnLoc.TabIndex = 36;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cbbtHocKy
            // 
            this.cbbtHocKy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbbtHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbtHocKy.FormattingEnabled = true;
            this.cbbtHocKy.Location = new System.Drawing.Point(310, 33);
            this.cbbtHocKy.Name = "cbbtHocKy";
            this.cbbtHocKy.Size = new System.Drawing.Size(209, 24);
            this.cbbtHocKy.TabIndex = 35;
            this.cbbtHocKy.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(307, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Học kì";
            // 
            // btnReload
            // 
            this.btnReload.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReload.Image = global::GUI.Properties.Resources.btnreload;
            this.btnReload.Location = new System.Drawing.Point(699, 21);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(37, 40);
            this.btnReload.TabIndex = 35;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmChiTietDiemHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 586);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmChiTietDiemHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChiTietDiemHocSinh";
            this.Load += new System.EventHandler(this.frmChiTietDiemHocSinh_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbbHocKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtDiemCuoiKy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiemGiuaKy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiemTrenLop;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemTrenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemGiuaKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemTongKet;
        private System.Windows.Forms.DataGridViewTextBoxColumn monHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hocKy;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbtHocKy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}