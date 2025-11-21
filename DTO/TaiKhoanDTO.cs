using System;

namespace DTO
{
    public class TaiKhoanDTO
    {
        // Properties
        public string MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public DateTime? LanDangNhapCuoi { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }

        public string Avatar { get; set; }

        // Constructor không tham số
        public TaiKhoanDTO() { }

        // Constructor đầy đủ tham số
        public TaiKhoanDTO(string maTaiKhoan, string tenDangNhap, string matKhau,
                          string hoTen, string vaiTro, DateTime? lanDangNhapCuoi,
                          DateTime ngayTao, string trangThai,string avatar)
        {
            MaTaiKhoan = maTaiKhoan;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            HoTen = hoTen;
            VaiTro = vaiTro;
            LanDangNhapCuoi = lanDangNhapCuoi;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            Avatar = avatar;
        }

        // Constructor cho đăng nhập (không cần tất cả thông tin)
        public TaiKhoanDTO(string tenDangNhap, string matKhau)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
    }
}