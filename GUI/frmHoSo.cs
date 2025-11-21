using BLL;
using DAL;
using DTO;
using GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoSo : Form
    {
        private TaiKhoanDTO _taiKhoan;
        private frmTrangChinh _frmCha;
        public frmHoSo(frmTrangChinh frmcha,TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _frmCha = frmcha;
            _taiKhoan = taiKhoan;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmHoSo_Load(object sender, EventArgs e)
        {
            _taiKhoan = TaiKhoanBLL.Instance.LayTaiKhoanTheoMa(_taiKhoan.MaTaiKhoan);
            if (_taiKhoan != null)
            {
                txtTenDangNhap.Text = _taiKhoan.TenDangNhap;
                txtLoaiTaiKhoan.Text = _taiKhoan.VaiTro;
                txtTrangThai.Text = _taiKhoan.TrangThai;
                txtLanDangNhapCuoi.Text = _taiKhoan.LanDangNhapCuoi?.ToString("dd/MM/yyyy HH:mm:ss");
                if (!string.IsNullOrEmpty(_taiKhoan.Avatar))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _taiKhoan.Avatar);
                    if (File.Exists(fullPath))
                    {
                        // Tải ảnh
                        // Lưu ý: Dùng FileStream để tránh khóa tệp (file locking)
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            ptbavatar.Image = System.Drawing.Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        // Hiển thị ảnh mặc định nếu tệp không tồn tại
                        // ptbavatar.Image = Properties.Resources.DefaultAvatar;
                    }
                }
            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            
            //lưu avatar nếu thay đổi
            string maTaiKhoan = _taiKhoan.MaTaiKhoan;
            if (ptbavatar.Tag != null)
            {
                //MessageBox.Show("Vui lòng chọn ảnh mới hoặc ảnh chưa được thay đổi.");
                //return;
                //Resources

                string originalFilePath = ptbavatar.Tag.ToString();
                string extension = Path.GetExtension(originalFilePath);
                string name = Path.GetFileName(originalFilePath);
                string fileName = name + extension;
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                string newFilePath = Path.Combine(targetDirectory, fileName);
                try
                {
                    // Sao chép tệp từ vị trí gốc sang thư mục lưu trữ
                    File.Copy(originalFilePath, newFilePath, true);

                    // Đường dẫn tương đối để lưu vào DB
                    // Chúng ta chỉ lưu tên tệp (fileName) hoặc đường dẫn tương đối (Avatars/file.png)
                    // để dễ dàng di chuyển ứng dụng sau này.
                    string relativePathToSave = Path.Combine("Resources", fileName);

                    // 2. Cập nhật đường dẫn vào Database
                    //UpdateAvatarPathInDatabase(currentUserId, relativePathToSave);
                    string sql = $"UPDATE TaiKhoan SET avatar = '{relativePathToSave}' WHERE MaTaiKhoan='{maTaiKhoan}'";
                    DataProvider.Instance.ExecuteNonQuery(sql);



                    // 3. Xóa Tag tạm thời sau khi lưu thành công
                    ptbavatar.Tag = null;
                    _frmCha.LoadAvatar();
                    MessageBox.Show("Cập nhật Avatar thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu ảnh hoặc cập nhật DB: {ex.Message}");
                }
            }


        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập bộ lọc cho các loại tệp hình ảnh
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ảnh đã chọn lên PictureBox
                    ptbavatar.Image = new System.Drawing.Bitmap(openFileDialog.FileName);

                    // Lưu đường dẫn gốc của tệp TẠM THỜI (để dùng trong bước Update)
                    // Ta dùng Tag để lưu đường dẫn tạm thời này
                    ptbavatar.Tag = openFileDialog.FileName;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string matKhauCu = txtMatKhauCu.Text.Trim();
                string matKhauMoi = txtMatKhauMoi.Text.Trim();
                string xacNhan = txtXacNhan.Text.Trim();

                bool result = TaiKhoanBLL.Instance.DoiMatKhau(
                    _taiKhoan.MaTaiKhoan,
                    matKhauCu,
                    matKhauMoi,
                    xacNhan
                );

                if (result)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauCu.Clear();
                    txtMatKhauMoi.Clear();
                    txtXacNhan.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
