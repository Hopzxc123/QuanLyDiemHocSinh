namespace GUI
{
    partial class frmQLLop
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
            this.grbLuaChon = new System.Windows.Forms.GroupBox();
            this.txtNamHoc = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtKhoiLop = new System.Windows.Forms.TextBox();
            this.txtSiSo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lbTenLop = new System.Windows.Forms.Label();
            this.lbMaLop = new System.Windows.Forms.Label();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhoiLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipMaLop = new System.Windows.Forms.ToolTip(this.components);
            this.grbLuaChon.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // grbLuaChon
            // 
            this.grbLuaChon.BackColor = System.Drawing.Color.MediumTurquoise;
            this.grbLuaChon.Controls.Add(this.txtNamHoc);
            this.grbLuaChon.Controls.Add(this.txtGhiChu);
            this.grbLuaChon.Controls.Add(this.txtKhoiLop);
            this.grbLuaChon.Controls.Add(this.txtSiSo);
            this.grbLuaChon.Controls.Add(this.label5);
            this.grbLuaChon.Controls.Add(this.label4);
            this.grbLuaChon.Controls.Add(this.label3);
            this.grbLuaChon.Controls.Add(this.label2);
            this.grbLuaChon.Controls.Add(this.txtTenLop);
            this.grbLuaChon.Controls.Add(this.txtMaLop);
            this.grbLuaChon.Controls.Add(this.lbTenLop);
            this.grbLuaChon.Controls.Add(this.lbMaLop);
            this.grbLuaChon.Location = new System.Drawing.Point(16, 155);
            this.grbLuaChon.Margin = new System.Windows.Forms.Padding(4);
            this.grbLuaChon.Name = "grbLuaChon";
            this.grbLuaChon.Padding = new System.Windows.Forms.Padding(4);
            this.grbLuaChon.Size = new System.Drawing.Size(372, 391);
            this.grbLuaChon.TabIndex = 0;
            this.grbLuaChon.TabStop = false;
            this.grbLuaChon.Text = "Lựa chọn";
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(121, 240);
            this.txtNamHoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Size = new System.Drawing.Size(220, 22);
            this.txtNamHoc.TabIndex = 19;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(121, 289);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(220, 60);
            this.txtGhiChu.TabIndex = 18;
            // 
            // txtKhoiLop
            // 
            this.txtKhoiLop.Location = new System.Drawing.Point(121, 141);
            this.txtKhoiLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhoiLop.Name = "txtKhoiLop";
            this.txtKhoiLop.Size = new System.Drawing.Size(220, 22);
            this.txtKhoiLop.TabIndex = 17;
            // 
            // txtSiSo
            // 
            this.txtSiSo.Location = new System.Drawing.Point(121, 191);
            this.txtSiSo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSiSo.Name = "txtSiSo";
            this.txtSiSo.Size = new System.Drawing.Size(220, 22);
            this.txtSiSo.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ghi Chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Năm Học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sĩ số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Khối lớp";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(121, 84);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(220, 22);
            this.txtTenLop.TabIndex = 11;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(121, 38);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(220, 22);
            this.txtMaLop.TabIndex = 10;
            this.toolTipMaLop.SetToolTip(this.txtMaLop, "Thêm lớp mới không cần nhập mã lớp");
            // 
            // lbTenLop
            // 
            this.lbTenLop.AutoSize = true;
            this.lbTenLop.Location = new System.Drawing.Point(17, 90);
            this.lbTenLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenLop.Name = "lbTenLop";
            this.lbTenLop.Size = new System.Drawing.Size(53, 16);
            this.lbTenLop.TabIndex = 8;
            this.lbTenLop.Text = "Tên lớp";
            // 
            // lbMaLop
            // 
            this.lbMaLop.AutoSize = true;
            this.lbMaLop.Location = new System.Drawing.Point(17, 38);
            this.lbMaLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaLop.Name = "lbMaLop";
            this.lbMaLop.Size = new System.Drawing.Size(48, 16);
            this.lbMaLop.TabIndex = 7;
            this.lbMaLop.Text = "Mã lớp";
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvLop);
            this.grbDanhSach.Location = new System.Drawing.Point(396, 155);
            this.grbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Size = new System.Drawing.Size(516, 391);
            this.grbDanhSach.TabIndex = 1;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách";
            // 
            // dgvLop
            // 
            this.dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.TenLop,
            this.KhoiLop,
            this.SiSo,
            this.NamHoc,
            this.GhiChu});
            this.dgvLop.Location = new System.Drawing.Point(7, 22);
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.RowTemplate.Height = 24;
            this.dgvLop.Size = new System.Drawing.Size(502, 362);
            this.dgvLop.TabIndex = 0;
            this.dgvLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLop_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(936, 210);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(93, 28);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(936, 266);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(93, 28);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(936, 316);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(93, 28);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(936, 369);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(93, 28);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(333, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 57);
            this.label1.TabIndex = 6;
            this.label1.Text = "QUẢN LÝ LỚP";
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 80;
            // 
            // TenLop
            // 
            this.TenLop.DataPropertyName = "TenLop";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.Width = 125;
            // 
            // KhoiLop
            // 
            this.KhoiLop.DataPropertyName = "KhoiLop";
            this.KhoiLop.HeaderText = "Khối Lớp";
            this.KhoiLop.MinimumWidth = 6;
            this.KhoiLop.Name = "KhoiLop";
            this.KhoiLop.Width = 125;
            // 
            // SiSo
            // 
            this.SiSo.DataPropertyName = "SiSo";
            this.SiSo.HeaderText = "Sĩ Số";
            this.SiSo.MinimumWidth = 6;
            this.SiSo.Name = "SiSo";
            this.SiSo.Width = 80;
            // 
            // NamHoc
            // 
            this.NamHoc.DataPropertyName = "NamHoc";
            this.NamHoc.HeaderText = "Năm Học";
            this.NamHoc.MinimumWidth = 6;
            this.NamHoc.Name = "NamHoc";
            this.NamHoc.Width = 80;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 125;
            // 
            // frmQLLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbDanhSach);
            this.Controls.Add(this.grbLuaChon);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLLop";
            this.Text = "QUẢN LÝ LỚP";
            this.Load += new System.EventHandler(this.frmQLLop_Load);
            this.grbLuaChon.ResumeLayout(false);
            this.grbLuaChon.PerformLayout();
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLuaChon;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lbTenLop;
        private System.Windows.Forms.Label lbMaLop;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamHoc;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtKhoiLop;
        private System.Windows.Forms.TextBox txtSiSo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhoiLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.ToolTip toolTipMaLop;
    }
}