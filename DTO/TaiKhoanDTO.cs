using System;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public string MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }
        public string MaGiaoVien { get; set; }
        public string TrangThai { get; set; }

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(string maTaiKhoan, string tenDangNhap, string matKhau,
                           string loaiTaiKhoan, string maGiaoVien, string trangThai)
        {
            MaTaiKhoan = maTaiKhoan;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiTaiKhoan = loaiTaiKhoan;
            MaGiaoVien = maGiaoVien;
            TrangThai = trangThai;
        }
    }
}
