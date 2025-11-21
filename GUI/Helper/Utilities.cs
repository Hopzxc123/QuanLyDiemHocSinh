using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Helper
{
    public static class Utilities
    {
        public static void ShowForm(String formName,Panel containerPanel)
        {
            Type type = Type.GetType($"GUI.Reports.{formName}");
            Form frm = (Form)Activator.CreateInstance(type);

            // Quan trọng: biến Form thành non-top-level để nhúng vào Panel
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;      // Cho Form con tự lấp đầy Panel


            // 3. **Nhúng vào Panel**
            containerPanel.Controls.Clear(); // Xóa bất kỳ Control nào hiện có trong Panel

            containerPanel.Controls.Add(frm); // Thêm Form con vào Panel
            

            // 4. Hiển thị
            frm.Show();
        }
    }
}
