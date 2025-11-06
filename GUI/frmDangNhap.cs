using BLL;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        // ⭐ Property để trả về user đã đăng nhập
        public TaiKhoanDTO CurrentUser { get; private set; }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            txtTenDangNhap.Focus();
            txtMatKhau.UseSystemPasswordChar = true;
            // Khi nhấn Enter trên form => gọi nút đăng nhập
            this.AcceptButton = btnDangNhap;

            // Khi nhấn Esc => gọi nút thoát (tùy chọn)
            this.CancelButton = btnThoat;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Visible = true;
                return;
            }

            try
            {
                // Đăng nhập qua BLL
                CurrentUser = TaiKhoanBLL.Instance.DangNhap(tenDangNhap, matKhau);

                if (CurrentUser != null)
                {
                    // Set DialogResult và đóng form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Visible = true;
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có muốn thoát không?",
       "Xác nhận thoát",
       MessageBoxButtons.OKCancel,
       MessageBoxIcon.Question
   );

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            } else
                txtMatKhau.UseSystemPasswordChar= true;
        }
    }
}



