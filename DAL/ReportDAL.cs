using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ReportDAL
    {
        private static ReportDAL _instance;

        public static ReportDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReportDAL();
                return _instance;
            }
        }

        private ReportDAL() { }
        public List<frmBaoCaoTKMHDTO> ReportTongKetMon(string maHocKy, string maMonHoc)
        {
            List<frmBaoCaoTKMHDTO> list = new List<frmBaoCaoTKMHDTO>();
            string query = $" select l.MaLop,l.TenLop,l.SiSo,count(hs.MaHocSinh) as soluongDat from Diem as d join HocSinh as hs on d.MaHocSinh=hs.MaHocSinh\r\n join Lop as l on hs.MaLop=l.MaLop\r\n where MaHocKy='{maHocKy}' and MaMonHoc='{maMonHoc}' and DiemTongKet>5\r\n group by l.MaLop,l.TenLop,l.SiSo\r\n order by l.TenLop asc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                frmBaoCaoTKMHDTO dto = new frmBaoCaoTKMHDTO
                {
                    maLop = row["MaLop"].ToString(),
                    tenLop = row["TenLop"].ToString(),
                    siSo = Convert.ToInt32(row["SiSo"]),
                    soLuongDat = Convert.ToInt32(row["soluongDat"])
                };
                list.Add(dto);
            }
            return list;
        }

        public List<ReportMonHocDTO> ReportMonHoc()
        {
            List<ReportMonHocDTO> list = new List<ReportMonHocDTO>();
            string query = "select BangDiem.MaMonHoc, MonHoc.TenMonHoc, HocKy.MaHocKy, HocKy.TenHocKy, NamHoc.MaNamHoc, NamHoc.TenNamHoc, AVG(DiemTBHK) DTB from BangDiem " +
                            " join MonHoc on BangDiem.MaMonHoc = MonHoc.MaMonHoc" +
                            " join HocKy on BangDiem.MaHocKy = HocKy.MaHocKy " +
                            " join NamHoc on HocKy.MaNamHoc = NamHoc.MaNamHoc " +
                            " group by BangDiem.MaMonHoc, MonHoc.TenMonHoc, HocKy.MaHocKy, HocKy.TenHocKy, NamHoc.MaNamHoc, NamHoc.TenNamHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ReportMonHocDTO mh = new ReportMonHocDTO
                {
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString(),
                    MaHocKy = row["MaHocKy"].ToString(),
                    TenHocKy = row["TenHocKy"].ToString(),
                    MaNamHoc = row["MaNamHoc"].ToString(),
                    TenNamHoc = row["TenNamHoc"].ToString(),
                    DTB = row["DTB"] != DBNull.Value ? Math.Round(Convert.ToDouble(row["DTB"]), 1): 0

                };
                list.Add(mh);
            }
            return list;
        }

        public DataTable ReportKQHSCaNam(string maNamHoc, string maLop)
        {
            string query = $"EXEC ReportKQHSCaNam {maNamHoc}, {maLop}";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                maNamHoc,
                maLop
            });
        }

    }
}
