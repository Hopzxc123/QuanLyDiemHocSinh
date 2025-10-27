using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        private static TaiKhoanBLL _instance;

        public static TaiKhoanBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TaiKhoanBLL();
                return _instance;
            }
        }

        private TaiKhoanBLL() { }

        // Đăng nhập
        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống");

                if (string.IsNullOrWhiteSpace(matKhau))
                    throw new Exception("Mật khẩu không được để trống");

                TaiKhoanDTO taiKhoan = TaiKhoanDAL.Instance.DangNhap(tenDangNhap, matKhau);

                if (taiKhoan == null)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng");

                if (taiKhoan.TrangThai != "Hoạt động")
                    throw new Exception("Tài khoản đã bị khóa");

                return taiKhoan;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng nhập: " + ex.Message);
            }
        }

        // Lấy danh sách tài khoản
        public List<TaiKhoanDTO> LayDanhSachTaiKhoan()
        {
            try
            {
                return TaiKhoanDAL.Instance.GetAllTaiKhoan();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
        }

        // Tìm tài khoản theo mã
        public TaiKhoanDTO TimTaiKhoanTheoMa(string maTaiKhoan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                return TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm tài khoản: " + ex.Message);
            }
        }

        // Thêm tài khoản
        public bool ThemTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tk.MaTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                if (string.IsNullOrWhiteSpace(tk.TenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống");

                if (string.IsNullOrWhiteSpace(tk.MatKhau))
                    throw new Exception("Mật khẩu không được để trống");

                if (tk.MatKhau.Length < 6)
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");

                if (string.IsNullOrWhiteSpace(tk.LoaiTaiKhoan))
                    throw new Exception("Loại tài khoản không được để trống");

                // Kiểm tra trùng tên đăng nhập
                if (TaiKhoanDAL.Instance.CheckTenDangNhapTonTai(tk.TenDangNhap))
                    throw new Exception("Tên đăng nhập đã tồn tại");

                return TaiKhoanDAL.Instance.InsertTaiKhoan(tk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        // Cập nhật tài khoản
        public bool CapNhatTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tk.MaTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                // Kiểm tra tồn tại
                if (TaiKhoanDAL.Instance.GetTaiKhoanByMa(tk.MaTaiKhoan) == null)
                    throw new Exception("Không tìm thấy tài khoản");

                return TaiKhoanDAL.Instance.UpdateTaiKhoan(tk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(string maTaiKhoan, string matKhauCu, string matKhauMoi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(matKhauCu))
                    throw new Exception("Mật khẩu cũ không được để trống");

                if (string.IsNullOrWhiteSpace(matKhauMoi))
                    throw new Exception("Mật khẩu mới không được để trống");

                if (matKhauMoi.Length < 6)
                    throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự");

                if (matKhauCu == matKhauMoi)
                    throw new Exception("Mật khẩu mới phải khác mật khẩu cũ");

                // Kiểm tra mật khẩu cũ
                TaiKhoanDTO tk = TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan);
                if (tk == null)
                    throw new Exception("Không tìm thấy tài khoản");

                if (tk.MatKhau != matKhauCu)
                    throw new Exception("Mật khẩu cũ không đúng");

                return TaiKhoanDAL.Instance.DoiMatKhau(maTaiKhoan, matKhauMoi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

        // Xóa tài khoản
        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                // Kiểm tra tồn tại
                if (TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan) == null)
                    throw new Exception("Không tìm thấy tài khoản");

                return TaiKhoanDAL.Instance.DeleteTaiKhoan(maTaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        // Kiểm tra tên đăng nhập tồn tại
        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            return TaiKhoanDAL.Instance.CheckTenDangNhapTonTai(tenDangNhap);
        }
    }
}
