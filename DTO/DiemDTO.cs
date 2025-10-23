using System;

namespace DTO
{
    public class DiemDTO
    {
        public string MaDiem { get; set; }
        public string MaHocSinh { get; set; }
        public string MaMonHoc { get; set; }
        public string MaHocKy { get; set; }
        public float? DiemTrenLop { get; set; }
        public float? DiemGiuaKy { get; set; }
        public float? DiemThi { get; set; }
        public float? DiemTongKet { get; set; }

        public DiemDTO() { }

        public DiemDTO(string maDiem, string maHocSinh, string maMonHoc, string maHocKy,
                       float? diemTrenLop, float? diemGiuaKy, float? diemThi, float? diemTongKet)
        {
            MaDiem = maDiem;
            MaHocSinh = maHocSinh;
            MaMonHoc = maMonHoc;
            MaHocKy = maHocKy;
            DiemTrenLop = diemTrenLop;
            DiemGiuaKy = diemGiuaKy;
            DiemThi = diemThi;
            DiemTongKet = diemTongKet;
        }

        public void TinhDiemTongKet()
        {
            float diemTrenLop = DiemTrenLop ?? 0;
            float diemGiuaKy = DiemGiuaKy ?? 0;
            float diemThi = DiemThi ?? 0;

            if (DiemTrenLop.HasValue || DiemGiuaKy.HasValue || DiemThi.HasValue)
            {
                DiemTongKet = (diemTrenLop * 0.3f) + (diemGiuaKy * 0.3f) + (diemThi * 0.4f);
            }
            else
            {
                DiemTongKet = null;
            }
        }
    }
}
