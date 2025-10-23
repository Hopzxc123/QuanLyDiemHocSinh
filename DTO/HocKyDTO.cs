using System;

namespace DTO
{
    public class HocKyDTO
    {
        public string MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MaNamHoc { get; set; }

        public HocKyDTO() { }

        public HocKyDTO(string maHocKy, string tenHocKy,
                        DateTime ngayBatDau, DateTime ngayKetThuc, string maNamHoc)
        {
            MaHocKy = maHocKy;
            TenHocKy = tenHocKy;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            MaNamHoc = maNamHoc;
        }
    }
}
