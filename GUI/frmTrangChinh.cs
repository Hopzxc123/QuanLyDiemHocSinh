using DTO;
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
        public event EventHandler LogoutRequested;
        public bool IsLoggedOut { get; private set; }
        public frmTrangChinh()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

         

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openChildForm(new frmQLThongTinHocSinh ());
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

        private void button5_Click_1(object sender, EventArgs e)
        {
           
            openChildForm(new QuanLyGiangVien());
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

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            sidebar.SuspendLayout(); // 🧩 Ngắt layout tạm thời
            plView.SuspendLayout();

            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if(sidebar.Width <= 55)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    plQLHocSinh.Width = sidebar.Width;
                    plQLDiemHS.Width = sidebar.Width;
                    plQLLop.Width = sidebar.Width;
                    plQLMonHoc.Width = sidebar.Width;
                    plQLGiaoVien.Width = sidebar.Width;
                    plDangXuat.Width = sidebar.Width;
                    HideButtonText();
                }
            }else
            {
                sidebar.Width += 5;
                if(sidebar.Width >= 245)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    plQLHocSinh.Width = sidebar.Width;
                    plQLDiemHS.Width = sidebar.Width;
                    plQLLop.Width = sidebar.Width;
                    plQLMonHoc.Width = sidebar.Width;
                    plQLGiaoVien.Width = sidebar.Width;
                    plDangXuat.Width = sidebar.Width;
                    ShowButtonText();
                }
            }
            sidebar.ResumeLayout(); // 🔧 Bật lại layout sau khi thay đổi
            plView.ResumeLayout();
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void HideButtonText()
        {
            btnQLHS.Text = "";
            btnQLDiem.Text = "";
            btnQLLop.Text = "";
            btnQLMonHoc.Text = "";
            btnQLGiaoVien.Text = "";
            btnDangXuat.Text = "";
        }

        private void ShowButtonText()
        {
            btnQLHS.Text = "   Quản lý học sinh";
            btnQLDiem.Text = "   Quản lý điểm";
            btnQLLop.Text = "   Quản lý lớp";
            btnQLMonHoc.Text = "   Quản lý môn học";
            btnQLGiaoVien.Text = "   Quản lý giáo viên";
            btnDangXuat.Text = "   Đăng xuất";
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

        
    }
}
