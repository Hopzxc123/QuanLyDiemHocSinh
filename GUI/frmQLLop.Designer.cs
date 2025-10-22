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
            this.grbLuaChon = new System.Windows.Forms.GroupBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lbTenLop = new System.Windows.Forms.Label();
            this.lbMaLop = new System.Windows.Forms.Label();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.lstDanhSach = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grbLuaChon.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLuaChon
            // 
            this.grbLuaChon.BackColor = System.Drawing.Color.MediumTurquoise;
            this.grbLuaChon.Controls.Add(this.txtTenLop);
            this.grbLuaChon.Controls.Add(this.txtMaLop);
            this.grbLuaChon.Controls.Add(this.lbTenLop);
            this.grbLuaChon.Controls.Add(this.lbMaLop);
            this.grbLuaChon.Location = new System.Drawing.Point(12, 126);
            this.grbLuaChon.Name = "grbLuaChon";
            this.grbLuaChon.Size = new System.Drawing.Size(279, 318);
            this.grbLuaChon.TabIndex = 0;
            this.grbLuaChon.TabStop = false;
            this.grbLuaChon.Text = "Lựa chọn";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(93, 87);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(166, 20);
            this.txtTenLop.TabIndex = 11;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(93, 38);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(166, 20);
            this.txtMaLop.TabIndex = 10;
            // 
            // lbTenLop
            // 
            this.lbTenLop.AutoSize = true;
            this.lbTenLop.Location = new System.Drawing.Point(15, 90);
            this.lbTenLop.Name = "lbTenLop";
            this.lbTenLop.Size = new System.Drawing.Size(43, 13);
            this.lbTenLop.TabIndex = 8;
            this.lbTenLop.Text = "Tên lớp";
            // 
            // lbMaLop
            // 
            this.lbMaLop.AutoSize = true;
            this.lbMaLop.Location = new System.Drawing.Point(15, 45);
            this.lbMaLop.Name = "lbMaLop";
            this.lbMaLop.Size = new System.Drawing.Size(39, 13);
            this.lbMaLop.TabIndex = 7;
            this.lbMaLop.Text = "Mã lớp";
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.lstDanhSach);
            this.grbDanhSach.Location = new System.Drawing.Point(297, 126);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Size = new System.Drawing.Size(387, 318);
            this.grbDanhSach.TabIndex = 1;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách";
            // 
            // lstDanhSach
            // 
            this.lstDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lstDanhSach.FullRowSelect = true;
            this.lstDanhSach.GridLines = true;
            this.lstDanhSach.HideSelection = false;
            this.lstDanhSach.Location = new System.Drawing.Point(7, 19);
            this.lstDanhSach.Name = "lstDanhSach";
            this.lstDanhSach.Size = new System.Drawing.Size(374, 293);
            this.lstDanhSach.TabIndex = 0;
            this.lstDanhSach.UseCompatibleStateImageBehavior = false;
            this.lstDanhSach.View = System.Windows.Forms.View.Details;
            this.lstDanhSach.SelectedIndexChanged += new System.EventHandler(this.lstDanhSach_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mã Lớp";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tên Lớp";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(702, 171);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(702, 216);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(70, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(702, 257);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(70, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(702, 300);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(70, 23);
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
            this.label1.Location = new System.Drawing.Point(250, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "QUẢN LÝ LỚP";
            // 
            // frmQLLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbDanhSach);
            this.Controls.Add(this.grbLuaChon);
            this.Name = "frmQLLop";
            this.Text = "QUẢN LÝ LỚP";
            this.Load += new System.EventHandler(this.QLLop_Load);
            this.grbLuaChon.ResumeLayout(false);
            this.grbLuaChon.PerformLayout();
            this.grbDanhSach.ResumeLayout(false);
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
        private System.Windows.Forms.ListView lstDanhSach;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}