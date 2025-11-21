using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportMonHocDTO
    {
        public string MaMonHoc { get; set; }
        public string MaNamHoc { get; set; }
        public string MaHocKy { get; set; }
        public string TenMonHoc { get; set; }
        public string TenNamHoc { get; set; }
        public string TenHocKy { get; set; }
        public double DTB { get; set; }
        public ReportMonHocDTO() { }

    }
}
