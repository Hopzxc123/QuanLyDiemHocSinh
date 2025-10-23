using System;

namespace DTO
{
    public class LopDTO
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string KhoiLop { get; set; }
        public int SSo { get; set; }
        public string NamHoc { get; set; }
        public string GhiChu { get; set; }

        public LopDTO() { }

        public LopDTO(string maLop, string tenLop, string khoiLop,
                      int sSo, string namHoc, string ghiChu)
        {
            MaLop = maLop;
            TenLop = tenLop;
            KhoiLop = khoiLop;
            SSo = sSo;
            NamHoc = namHoc;
            GhiChu = ghiChu;
        }
    }
}
