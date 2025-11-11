using GUI.Properties;
namespace GUI
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.lblThongBao = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongBao
            // 
            resources.ApplyResources(this.lblThongBao, "lblThongBao");
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblThongBao.Name = "lblThongBao";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BorderRadius = 8;
            this.txtTenDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDangNhap.DefaultText = "";
            this.txtTenDangNhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDangNhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDangNhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            resources.ApplyResources(this.txtTenDangNhap, "txtTenDangNhap");
            this.txtTenDangNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PlaceholderText = "Username";
            this.txtTenDangNhap.SelectedText = "";
            this.txtTenDangNhap.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderRadius = 8;
            this.txtMatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhau.DefaultText = "";
            this.txtMatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            resources.ApplyResources(this.txtMatKhau, "txtMatKhau");
            this.txtMatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PlaceholderText = "Password";
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // guna2CheckBox1
            // 
            resources.ApplyResources(this.guna2CheckBox1, "guna2CheckBox1");
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.White;
            this.guna2CheckBox1.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.BorderRadius = 4;
            this.btnDangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            resources.ApplyResources(this.btnDangNhap, "btnDangNhap");
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(81)))), ((int)(((byte)(221)))));
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnThoat.BorderRadius = 4;
            this.btnThoat.BorderThickness = 1;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(101)))), ((int)(((byte)(241)))));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GUI.Properties.Resources._lock;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.user;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::GUI.Properties.Resources.login__2_;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            resources.ApplyResources(this.guna2CirclePictureBox1, "guna2CirclePictureBox1");
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.guna2CheckBox1);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblThongBao);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private Guna.UI2.WinForms.Guna2Button btnDangNhap;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}