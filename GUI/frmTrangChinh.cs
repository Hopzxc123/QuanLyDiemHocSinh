using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI
{
    public partial class frmTrangChinh : Form
    {
        bool sidebarExpand = true; // Trạng thái sidebar
        public event EventHandler LogoutRequested;
        public TaiKhoanDTO Account { get; private set; }
        public bool IsLoggedOut { get; private set; }

        // Định nghĩa hằng số cho kích thước, dễ dàng bảo trì
        private const int sidebarWidthExpanded = 192;
        private const int sidebarWidthCollapsed = 55;

        public frmTrangChinh(TaiKhoanDTO account)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            Account = account;

        }



        private Form currentFormChild;
        private void openChildForm(Form childForm)
        {


            // Nếu form đang mở là cùng loại (ví dụ cùng là frmQLLop) thì không mở lại
            if (currentFormChild != null && currentFormChild.GetType() == childForm.GetType())
            {
                currentFormChild.BringToFront();
                return;
            }

            // Đóng form cũ (nếu khác loại)
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            plView.Controls.Clear(); // Dọn sạch panel trước khi thêm form mới
            plView.Controls.Add(childForm);
            plView.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void fTrangChinh_Load(object sender, EventArgs e)
        {
            CapNhatThongTinNguoiDangNhap();
            openChildForm(new frmThongKe());
        }

        private void CapNhatThongTinNguoiDangNhap()
        {
            lblTenTaiKhoan.Text = Account.TenDangNhap;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            openChildForm(new frmQLThongTinHocSinh());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            openChildForm(new FrmQLDiemHS());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLLop());
        }


        private void button4_Click(object sender, EventArgs e)
        {

            openChildForm(new frmQuanLyMonHoc());
        }

        private void plBody_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKe());
        }
        private void button5_Click_1(object sender, EventArgs e)
        {

            openChildForm(new frmQuanLyGiaoVien());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                // Người dùng đồng ý đăng xuất
                IsLoggedOut = true;
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Người dùng bấm "Không" → không làm gì cả
                return;
            }
        }

        // ====================================================================
        // HÀM ĐÃ ĐƯỢC VIẾT LẠI VÀ ĐƠN GIẢN HÓA
        // ====================================================================
        private void ToggleSidebar()
        {
           

            if (sidebarExpand)
            {
                // --- THU GỌN SIDEBAR ---

                // 1. Ẩn text của các button
               
                HideButtonText();

                // 2. Thay đổi Width ngay lập tức (Snap)
                
                sidebar.Width = sidebarWidthCollapsed;

                
                sidebarExpand = false;
            }
            else
            {
                // --- MỞ RỘNG SIDEBAR ---

                // 1. Thay đổi Width ngay lập tức (Snap)
               
                sidebar.Width = sidebarWidthExpanded;

                // 2. Hiển thị lại text cho các button
                ShowButtonText();

                // 3. Cập nhật lại trạng thái
                sidebarExpand = true;
            }

            
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            ToggleSidebar();
        }


        private void HideButtonText()
        {
            btnQLHS.Text = "";
            btnQLDiem.Text = "";
            btnQLLop.Text = "";
            btnQLMonHoc.Text = "";
            btnQLGiaoVien.Text = "";
            btnThongKe.Text = "";
        }

        private void ShowButtonText()
        {
            btnQLHS.Text = "     Quản lý học sinh";
            btnQLDiem.Text = "     Quản lý điểm";
            btnQLLop.Text = "     Quản lý lớp";
            btnQLMonHoc.Text = "     Quản lý môn học";
            btnQLGiaoVien.Text = "     Quản lý giáo viên";
            btnThongKe.Text = "     Đăng xuất";
        }


        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHoSo(Account));
        }
    }
}