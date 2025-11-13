using BLL;
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
    public partial class frmHoSo : Form
    {
        private TaiKhoanDTO _taiKhoan;
        public frmHoSo(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmHoSo_Load(object sender, EventArgs e)
        {
            if (_taiKhoan != null)
            {
                txtTenDangNhap.Text = _taiKhoan.TenDangNhap;
                txtLoaiTaiKhoan.Text = _taiKhoan.VaiTro;
                txtTrangThai.Text = _taiKhoan.TrangThai;
                txtLanDangNhapCuoi.Text = _taiKhoan.LanDangNhapCuoi?.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
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
