using System;

namespace DTO
{
    public class HocSinhDTO
    {
        public string MaHocSinh { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string MaLop { get; set; }
        public string TrangThai { get; set; }

        public HocSinhDTO() { }

        public HocSinhDTO(string maHocSinh, string hoTen, DateTime ngaySinh,
                          string gioiTinh, string diaChi, string email,
                          string maLop, string trangThai)
        {
            MaHocSinh = maHocSinh;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            Email = email;
            MaLop = maLop;
            TrangThai = trangThai;
        }
    }
}
