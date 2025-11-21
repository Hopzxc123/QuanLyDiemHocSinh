using DTO.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reports
{
    public class KQLHHocKyDAL
    {

        private static KQLHHocKyDAL _instance;
        public static KQLHHocKyDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KQLHHocKyDAL();
                return _instance;
            }
        }

        private KQLHHocKyDAL() { }

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
    }
}
