// ==================== LopDAL.cs ====================
using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class LopDAL
    {
        private static LopDAL _instance;

        public static LopDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LopDAL();
                return _instance;
            }
        }

        private LopDAL() { }

        // Lấy tất cả lớp
        public List<LopDTO> GetAllLop()
        {
            List<LopDTO> list = new List<LopDTO>();
            string query = "SELECT * FROM Lop";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                LopDTO lop = new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    KhoiLop = row["KhoiLop"].ToString(),
                    SSo = row["SSo"] != DBNull.Value ? Convert.ToInt32(row["SSo"]) : 0,
                    NamHoc = row["NamHoc"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
                list.Add(lop);
            }

            return list;
        }

        // Lấy lớp theo mã
        public LopDTO GetLopByMa(string maLop)
        {
            string query = "SELECT * FROM Lop WHERE MaLop = @MaLop";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLop });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    KhoiLop = row["KhoiLop"].ToString(),
                    SSo = row["SSo"] != DBNull.Value ? Convert.ToInt32(row["SSo"]) : 0,
                    NamHoc = row["NamHoc"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }

        // Lấy lớp theo năm học
        public List<LopDTO> GetLopByNamHoc(string namHoc)
        {
            List<LopDTO> list = new List<LopDTO>();
            string query = "SELECT * FROM Lop WHERE NamHoc = @NamHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { namHoc });

            foreach (DataRow row in data.Rows)
            {
                LopDTO lop = new LopDTO
                {
                    MaLop = row["MaLop"].ToString(),
                    TenLop = row["TenLop"].ToString(),
                    KhoiLop = row["KhoiLop"].ToString(),
                    SSo = row["SSo"] != DBNull.Value ? Convert.ToInt32(row["SSo"]) : 0,
                    NamHoc = row["NamHoc"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                };
                list.Add(lop);
            }

            return list;
        }

        // Thêm lớp mới
        public bool InsertLop(LopDTO lop)
        {
            string query = "INSERT INTO Lop (MaLop, TenLop, KhoiLop, SSo, NamHoc, GhiChu) " +
                          "VALUES ( @MaLop , @TenLop , @KhoiLop , @SSo , @NamHoc , @GhiChu )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                lop.MaLop, lop.TenLop, lop.KhoiLop, lop.SSo, lop.NamHoc, lop.GhiChu
            });

            return result > 0;
        }

        // Cập nhật lớp
        public bool UpdateLop(LopDTO lop)
        {
            string query = "UPDATE Lop SET TenLop = @TenLop , KhoiLop = @KhoiLop , " +
                          "SSo = @SSo , NamHoc = @NamHoc , GhiChu = @GhiChu " +
                          "WHERE MaLop = @MaLop";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                lop.TenLop, lop.KhoiLop, lop.SSo, lop.NamHoc, lop.GhiChu, lop.MaLop
            });

            return result > 0;
        }

        // Xóa lớp
        public bool DeleteLop(string maLop)
        {
            string query = "DELETE FROM Lop WHERE MaLop = @MaLop";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLop });
            return result > 0;
        }

        // Đếm số học sinh trong lớp
        public int CountHocSinhInLop(string maLop)
        {
            string query = "SELECT COUNT(*) FROM HocSinh WHERE MaLop = @MaLop";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maLop });
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}