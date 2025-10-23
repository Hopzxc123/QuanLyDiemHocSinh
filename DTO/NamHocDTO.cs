using System;

namespace DTO
{
    public class NamHocDTO
    {
        public string MaNamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }

        public NamHocDTO() { }

        public NamHocDTO(string maNamHoc, string tenNamHoc,
                         DateTime ngayBatDau, DateTime ngayKetThuc, string trangThai)
        {
            MaNamHoc = maNamHoc;
            TenNamHoc = tenNamHoc;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            TrangThai = trangThai;
        }
    }
}
