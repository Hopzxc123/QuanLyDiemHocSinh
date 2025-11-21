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
            string query = "select Diem.MaMonHoc, MonHoc.TenMonHoc, HocKy.MaHocKy, HocKy.TenHocKy, NamHoc.MaNamHoc, NamHoc.TenNamHoc, AVG(Diem.DiemTongKet) DTB from Diem " +
                            " join MonHoc on Diem.MaMonHoc = MonHoc.MaMonHoc" +
                            " join HocKy on Diem.MaHocKy = HocKy.MaHocKy " +
                            " join NamHoc on HocKy.MaNamHoc = NamHoc.MaNamHoc " +
                            " group by Diem.MaMonHoc, MonHoc.TenMonHoc, HocKy.MaHocKy, HocKy.TenHocKy, NamHoc.MaNamHoc, NamHoc.TenNamHoc";

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
        public DataTable GetBaoCaoHocKy(string maNamHoc, string maHocKy)
        {
            // ĐÂY LÀ PHIÊN BẢN SQL CHUẨN
            string query = @"
        SELECT 
	        l.MaLop,
	        l.TenLop,
            
            -- Sĩ số: Đếm tất cả học sinh trong lớp (l.MaLop)
	        COUNT(hs.MaHocSinh) AS SiSo,
            
            -- Số lượng đạt: Chỉ đếm khi d.DiemTongKet >= 5 CỦA HỌC KỲ ĐÓ
	        SUM(CASE WHEN d.DiemTongKet >= 5 THEN 1 ELSE 0 END) AS SoLuongDat,
            
            -- Tỉ lệ:
	        CAST(SUM(CASE WHEN d.DiemTongKet >= 5 THEN 1 ELSE 0 END) * 100.0 
                 / COUNT(hs.MaHocSinh) AS DECIMAL(10,2)) AS TiLe
            
        FROM Lop l
	    
        -- Join với Học Sinh để lấy Sĩ số
        JOIN HocSinh hs ON hs.MaLop = l.MaLop
	    
        -- LEFT JOIN với Điểm
        LEFT JOIN Diem d 
            ON d.MaHocSinh = hs.MaHocSinh 
           
           -- !!! DÒNG QUAN TRỌNG NHẤT LÀ ĐÂY !!!
           -- Phải lọc Mã Học Kỳ NGAY TẠI ĐIỀU KIỆN JOIN
           -- Nếu thiếu dòng này, logic sẽ bị sai hoàn toàn
           AND d.MaHocKy = @MaHocKy  -- Tham số 1
	    
        -- Lọc Lớp theo Năm học
        WHERE l.NamHoc = @MaNamHoc      -- Tham số 2
	    
        GROUP BY l.MaLop, l.TenLop
	    ORDER BY l.MaLop";


            // --- CỰC KỲ QUAN TRỌNG ---
            // Vì @MaHocKy xuất hiện TRƯỚC @MaNamHoc trong SQL
            // Bạn BẮT BUỘC phải truyền tham số theo đúng thứ tự này:
            return DataProvider.Instance.ExecuteQuery(
                query,
                new object[] { maHocKy, maNamHoc }
            );
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
