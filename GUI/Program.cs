using System;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmTrangChinh());
            // Mở form đăng nhập
            //using (frmDangNhap frmLogin = new frmDangNhap())
            //{
            //    if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.CurrentUser != null)
            //    {
            //        // Đăng nhập thành công, mở form chính
            //        Application.Run(new frmTrangChinh());
            //    }
            //}
        }
    }
}
