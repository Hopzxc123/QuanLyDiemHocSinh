using System;

namespace DTO
{
    public class GiaoVienDTO
    {
        public int MaGiaoVien { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string ChuyenMon { get; set; }
        public bool TrangThai { get; set; }

        public GiaoVienDTO() { }

        public GiaoVienDTO(int maGiaoVien, string hoTen, DateTime? ngaySinh,
                           string gioiTinh, string diaChi, string dienThoai,
                           string email, string chuyenMon, bool trangThai)
        {
            MaGiaoVien = maGiaoVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            Email = email;
            ChuyenMon = chuyenMon;
            TrangThai = trangThai;
        }
    }
}
