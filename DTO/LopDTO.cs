using System;

namespace DTO
{
    public class LopDTO
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public int KhoiLop { get; set; }
        public int SiSo { get; set; }
        public int NamHoc { get; set; }
        public string GhiChu { get; set; }

        public LopDTO() { }

        public LopDTO(int maLop, string tenLop, int khoiLop,
                      int siSo, int namHoc, string ghiChu)
        {
            MaLop = maLop;
            TenLop = tenLop;
            KhoiLop = khoiLop;
            SiSo = siSo;
            NamHoc = namHoc;
            GhiChu = ghiChu;
        }
    }
}
