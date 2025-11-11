using System;

namespace DTO
{
    public class MonHocDTO
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int HeSo { get; set; }

        public string GhiChu { get; set; }
        public MonHocDTO() { }

        public MonHocDTO(string maMonHoc, string tenMonHoc, int heSo, string ghiChu)
        {
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            HeSo = heSo;
            GhiChu = ghiChu;
        }
    }
}
