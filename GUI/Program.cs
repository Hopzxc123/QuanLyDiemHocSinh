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

            while (true)
            {
                using (frmDangNhap frmLogin = new frmDangNhap())
                {
                    // Mở form đăng nhập
                    if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.CurrentUser != null)
                    {
                        // Đăng nhập thành công
                        frmTrangChinh mainForm = new frmTrangChinh();

                        // Gắn sự kiện khi người dùng đăng xuất
                        mainForm.LogoutRequested += (s, e) =>
                        {
                            mainForm.Close(); // Đóng form chính
                        };

                        Application.Run(mainForm);

                        // Nếu người dùng chọn đăng xuất → lặp lại từ đầu (đăng nhập lại)
                        if (mainForm.IsLoggedOut)
                            continue;
                    }

                    // Nếu không đăng nhập hoặc nhấn Hủy → thoát hẳn chương trình
                    break;
                }
            }
        }
    }
}
