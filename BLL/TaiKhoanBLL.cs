using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        // ======================== ĐĂNG NHẬP ========================

        /// <summary>
        /// Đăng nhập vào hệ thống
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <param name="matKhau">Mật khẩu</param>
        /// <returns>Thông tin tài khoản nếu thành công, null nếu thất bại</returns>
        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(tenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống");

                if (string.IsNullOrWhiteSpace(matKhau))
                    throw new Exception("Mật khẩu không được để trống");

                // Kiểm tra đăng nhập
                TaiKhoanDTO taiKhoan = TaiKhoanDAL.Instance.CheckLogin(tenDangNhap, matKhau);

                if (taiKhoan == null)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng");

                // Kiểm tra trạng thái tài khoản
                if (taiKhoan.TrangThai != "Hoạt động")
                    throw new Exception("Tài khoản đã bị vô hiệu hóa. Vui lòng liên hệ quản trị viên");

                // Cập nhật lần đăng nhập cuối
                TaiKhoanDAL.Instance.UpdateLastLogin(taiKhoan.MaTaiKhoan);

                return taiKhoan;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng nhập: " + ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra tên đăng nhập đã tồn tại chưa
        /// </summary>
        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            try
            {
                return TaiKhoanDAL.Instance.CheckTenDangNhapExists(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra tên đăng nhập: " + ex.Message);
            }
        }

        // ======================== QUẢN LÝ TÀI KHOẢN ========================

        /// <summary>
        /// Lấy danh sách tất cả tài khoản
        /// </summary>
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

        /// <summary>
        /// Lấy thông tin tài khoản theo mã
        /// </summary>
        public TaiKhoanDTO LayTaiKhoanTheoMa(string maTaiKhoan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                return TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông tin tài khoản theo tên đăng nhập
        /// </summary>
        public TaiKhoanDTO LayTaiKhoanTheoUsername(string tenDangNhap)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống");

                return TaiKhoanDAL.Instance.GetTaiKhoanByUsername(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm tài khoản mới
        /// </summary>
        public bool ThemTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                // Validation đầy đủ
                ValidateTaiKhoan(tk, true);

                // Kiểm tra trùng tên đăng nhập
                if (TaiKhoanDAL.Instance.CheckTenDangNhapExists(tk.TenDangNhap))
                    throw new Exception("Tên đăng nhập đã tồn tại");

                // Kiểm tra trùng mã
                if (TaiKhoanDAL.Instance.GetTaiKhoanByMa(tk.MaTaiKhoan) != null)
                    throw new Exception("Mã tài khoản đã tồn tại");

                // Set giá trị mặc định
                if (string.IsNullOrWhiteSpace(tk.TrangThai))
                    tk.TrangThai = "Hoạt động";

                // Thêm vào database
                return TaiKhoanDAL.Instance.InsertTaiKhoan(tk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản
        /// </summary>
        public bool CapNhatTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                // Validation
                ValidateTaiKhoan(tk, false);

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

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                // Kiểm tra tồn tại
                TaiKhoanDTO tk = TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan);
                if (tk == null)
                    throw new Exception("Không tìm thấy tài khoản");

                // Không cho xóa tài khoản admin
                if (tk.VaiTro == "Admin")
                    throw new Exception("Không thể xóa tài khoản Admin");

                return TaiKhoanDAL.Instance.DeleteTaiKhoan(maTaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        // ======================== ĐỔI MẬT KHẨU ========================

        /// <summary>
        /// Đổi mật khẩu (người dùng tự đổi)
        /// </summary>
        public bool DoiMatKhau(string maTaiKhoan, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                if (string.IsNullOrWhiteSpace(matKhauCu))
                    throw new Exception("Mật khẩu cũ không được để trống");

                if (string.IsNullOrWhiteSpace(matKhauMoi))
                    throw new Exception("Mật khẩu mới không được để trống");

                if (string.IsNullOrWhiteSpace(xacNhanMatKhau))
                    throw new Exception("Xác nhận mật khẩu không được để trống");

                // Kiểm tra mật khẩu mới
                if (matKhauMoi != xacNhanMatKhau)
                    throw new Exception("Mật khẩu mới và xác nhận mật khẩu không khớp");

                if (matKhauMoi == matKhauCu)
                    throw new Exception("Mật khẩu mới phải khác mật khẩu cũ");

                // Validate độ mạnh mật khẩu
                if (!KiemTraMatKhauManh(matKhauMoi))
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");

                // Đổi mật khẩu
                bool result = TaiKhoanDAL.Instance.ChangePassword(maTaiKhoan, matKhauCu, matKhauMoi);

                if (!result)
                    throw new Exception("Mật khẩu cũ không đúng");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

        /// <summary>
        /// Reset mật khẩu (admin reset cho user)
        /// </summary>
        public bool ResetMatKhau(string maTaiKhoan, string matKhauMoi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                if (string.IsNullOrWhiteSpace(matKhauMoi))
                    throw new Exception("Mật khẩu mới không được để trống");

                // Validate độ mạnh mật khẩu
                if (!KiemTraMatKhauManh(matKhauMoi))
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");

                // Kiểm tra tài khoản tồn tại
                if (TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan) == null)
                    throw new Exception("Không tìm thấy tài khoản");

                return TaiKhoanDAL.Instance.ResetPassword(maTaiKhoan, matKhauMoi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi reset mật khẩu: " + ex.Message);
            }
        }

        // ======================== QUẢN LÝ TRẠNG THÁI ========================

        /// <summary>
        /// Kích hoạt hoặc vô hiệu hóa tài khoản
        /// </summary>
        public bool CapNhatTrangThai(string maTaiKhoan, string trangThai)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTaiKhoan))
                    throw new Exception("Mã tài khoản không được để trống");

                if (string.IsNullOrWhiteSpace(trangThai))
                    throw new Exception("Trạng thái không được để trống");

                // Validate trạng thái hợp lệ
                if (trangThai != "Hoạt động" && trangThai != "Vô hiệu hóa")
                    throw new Exception("Trạng thái không hợp lệ");

                // Kiểm tra tài khoản tồn tại
                TaiKhoanDTO tk = TaiKhoanDAL.Instance.GetTaiKhoanByMa(maTaiKhoan);
                if (tk == null)
                    throw new Exception("Không tìm thấy tài khoản");

                // Không cho vô hiệu hóa tài khoản admin
                if (tk.VaiTro == "Admin" && trangThai == "Vô hiệu hóa")
                    throw new Exception("Không thể vô hiệu hóa tài khoản Admin");

                return TaiKhoanDAL.Instance.UpdateTrangThai(maTaiKhoan, trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách tài khoản đang hoạt động
        /// </summary>
        public List<TaiKhoanDTO> LayDanhSachTaiKhoanHoatDong()
        {
            try
            {
                return TaiKhoanDAL.Instance.GetActiveTaiKhoan();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản hoạt động: " + ex.Message);
            }
        }

        // ======================== TÌM KIẾM & THỐNG KÊ ========================

        /// <summary>
        /// Tìm kiếm tài khoản
        /// </summary>
        public List<TaiKhoanDTO> TimKiemTaiKhoan(string tuKhoa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return LayDanhSachTaiKhoan();

                return TaiKhoanDAL.Instance.SearchTaiKhoan(tuKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Đếm số tài khoản theo trạng thái
        /// </summary>
        public int DemTaiKhoanTheoTrangThai(string trangThai)
        {
            try
            {
                return TaiKhoanDAL.Instance.CountTaiKhoanByTrangThai(trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Đếm tổng số tài khoản
        /// </summary>
        public int DemTongSoTaiKhoan()
        {
            try
            {
                return TaiKhoanDAL.Instance.CountAllTaiKhoan();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đếm tổng số tài khoản: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách tài khoản đăng nhập gần đây
        /// </summary>
        public List<TaiKhoanDTO> LayTaiKhoanDangNhapGanDay(int soLuong = 10)
        {
            try
            {
                if (soLuong <= 0)
                    soLuong = 10;

                return TaiKhoanDAL.Instance.GetRecentLoginAccounts(soLuong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách đăng nhập gần đây: " + ex.Message);
            }
        }

        // ======================== VALIDATION HELPERS ========================

        /// <summary>
        /// Validate thông tin tài khoản
        /// </summary>
        private void ValidateTaiKhoan(TaiKhoanDTO tk, bool isInsert)
        {
            // Validate mã tài khoản
            if (string.IsNullOrWhiteSpace(tk.MaTaiKhoan))
                throw new Exception("Mã tài khoản không được để trống");

            // Validate tên đăng nhập
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap))
                throw new Exception("Tên đăng nhập không được để trống");

            if (tk.TenDangNhap.Length < 3)
                throw new Exception("Tên đăng nhập phải có ít nhất 3 ký tự");

            if (!Regex.IsMatch(tk.TenDangNhap, @"^[a-zA-Z0-9_]+$"))
                throw new Exception("Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới");

            // Validate mật khẩu (chỉ khi thêm mới)
            if (isInsert)
            {
                if (string.IsNullOrWhiteSpace(tk.MatKhau))
                    throw new Exception("Mật khẩu không được để trống");

                if (!KiemTraMatKhauManh(tk.MatKhau))
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");
            }

            // Validate họ tên
            if (string.IsNullOrWhiteSpace(tk.HoTen))
                throw new Exception("Họ tên không được để trống");

            if (tk.HoTen.Length < 3)
                throw new Exception("Họ tên phải có ít nhất 3 ký tự");

            // Validate vai trò
            if (string.IsNullOrWhiteSpace(tk.VaiTro))
                throw new Exception("Vai trò không được để trống");

            if (tk.VaiTro != "Admin" && tk.VaiTro != "Giáo viên" && tk.VaiTro != "Nhân viên")
                throw new Exception("Vai trò không hợp lệ");
        }

        /// <summary>
        /// Kiểm tra mật khẩu đủ mạnh
        /// </summary>
        private bool KiemTraMatKhauManh(string matKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhau))
                return false;

            // Tối thiểu 6 ký tự
            if (matKhau.Length < 6)
                return false;

            // Có thể thêm các rule khác như:
            // - Phải có chữ hoa
            // - Phải có chữ số
            // - Phải có ký tự đặc biệt
            // bool hasUpperCase = Regex.IsMatch(matKhau, @"[A-Z]");
            // bool hasLowerCase = Regex.IsMatch(matKhau, @"[a-z]");
            // bool hasDigit = Regex.IsMatch(matKhau, @"[0-9]");
            // bool hasSpecialChar = Regex.IsMatch(matKhau, @"[!@#$%^&*(),.?""':{}|<>]");

            return true;
        }

        /// <summary>
        /// Kiểm tra vai trò có quyền admin không
        /// </summary>
        public bool KiemTraQuyenAdmin(TaiKhoanDTO tk)
        {
            if (tk == null)
                return false;

            return tk.VaiTro == "Admin";
        }

        /// <summary>
        /// Kiểm tra vai trò có quyền giáo viên không
        /// </summary>
        public bool KiemTraQuyenGiaoVien(TaiKhoanDTO tk)
        {
            if (tk == null)
                return false;

            return tk.VaiTro == "Admin" || tk.VaiTro == "Giáo viên";
        }
    }
}