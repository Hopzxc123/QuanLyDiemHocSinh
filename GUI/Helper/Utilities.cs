using System;
using System.Collections.Generic;
using System.IO;
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
        //public static string SaveFileAvatar(string maTaiKhoan,PictureBox pictureBoxAvatar)
        //{
        //    string originalFilePath = pictureBoxAvatar.Tag.ToString();
        //    string extension = Path.GetExtension(originalFilePath);

        //    // Tên tệp mới: Dùng UserID và GUID để đảm bảo tên duy nhất
        //    string fileName = $"{currentUserId}_{Guid.NewGuid()}{extension}";

        //    // Đường dẫn thư mục lưu trữ (Hãy đảm bảo thư mục này tồn tại!)
        //    // Ví dụ: Lưu vào thư mục "Avatars" trong thư mục chạy ứng dụng
        //    string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars");
        //    if (!Directory.Exists(targetDirectory))
        //    {
        //        Directory.CreateDirectory(targetDirectory);
        //    }

        //    string newFilePath = Path.Combine(targetDirectory, fileName);

        //    try
        //    {
        //        // Sao chép tệp từ vị trí gốc sang thư mục lưu trữ
        //        File.Copy(originalFilePath, newFilePath, true);

        //        // Đường dẫn tương đối để lưu vào DB
        //        // Chúng ta chỉ lưu tên tệp (fileName) hoặc đường dẫn tương đối (Avatars/file.png)
        //        // để dễ dàng di chuyển ứng dụng sau này.
        //        string relativePathToSave = Path.Combine("Avatars", fileName);

        //        // 2. Cập nhật đường dẫn vào Database
        //        //UpdateAvatarPathInDatabase(currentUserId, relativePathToSave);

        //        // 3. Xóa Tag tạm thời sau khi lưu thành công
        //        pictureBoxAvatar.Tag = null;

        //        MessageBox.Show("Cập nhật Avatar thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi lưu ảnh hoặc cập nhật DB: {ex.Message}");
        //    }
        //}
    }
}
