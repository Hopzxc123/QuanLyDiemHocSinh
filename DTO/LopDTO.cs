using System;
using System.Runtime.InteropServices;

namespace DTO
{
    public class LopDTO
    {
        public string  MaLop { get; set; }
        public string TenLop { get; set; }
        public int KhoiLop { get; set; }
        public int SiSo { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public LopDTO() { }

        public LopDTO(string maLop, string tenLop, int khoiLop,
                      int siSo, string namHoc, string ghiChu)
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
