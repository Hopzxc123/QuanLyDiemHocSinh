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

        // ====================== READ ======================

        // Lấy tất cả lớp
        public List<LopDTO> GetAllLop()
        {
            List<LopDTO> list = new List<LopDTO>();
            string query = "SELECT * FROM Lop";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }

        // Lấy lớp theo mã
        public LopDTO GetLopByMa(string maLop)
        {
            string query = "SELECT * FROM Lop WHERE MaLop = @MaLop";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLop });

            if (data.Rows.Count > 0)
                return MapToDTO(data.Rows[0]);

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
                list.Add(MapToDTO(row));
            }

            return list;
        }

        // ====================== CREATE ======================

        public bool InsertLop(LopDTO lop)
        {
            string query = $"INSERT INTO Lop(MaLop, TenLop, KhoiLop, SiSo, NamHoc,GhiChu)" +
                $" VALUES(N'{lop.MaLop}', N'{lop.TenLop}', {lop.KhoiLop}, {lop.SiSo}, N'{lop.NamHoc}', N'{lop.GhiChu}')";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // ====================== UPDATE ======================

        public bool UpdateLop(LopDTO lop)
        {
            string query = $"UPDATE Lop SET TenLop = N'{lop.TenLop}'," +
                $" KhoiLop = {lop.KhoiLop}, SiSo = {lop.SiSo}, NamHoc = N'{lop.NamHoc}', GhiChu = N'{lop.GhiChu}'" +
                $"WHERE MaLop = N'{lop.MaLop}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // ====================== DELETE ======================

        public bool DeleteLop(string maLop)
        {
            string query = "DELETE FROM Lop WHERE MaLop = @MaLop";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLop });
            return result > 0;
        }

        // ====================== SUPPORT ======================

        public int CountHocSinhInLop(string maLop)
        {
            string query = "SELECT COUNT(*) FROM HocSinh WHERE MaLop = @MaLop";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maLop });
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool CheckMaLopExists(string maLop)
        {
            return GetLopByMa(maLop) != null;
        }

        // ====================== PRIVATE HELPER ======================

        private LopDTO MapToDTO(DataRow row)
        {
            return new LopDTO
            {
                MaLop = row["MaLop"].ToString(),
                TenLop = row["TenLop"].ToString(),
                KhoiLop = row["KhoiLop"] != DBNull.Value ? Convert.ToInt32(row["KhoiLop"]) : 0,
                SiSo = row["SiSo"] != DBNull.Value ? Convert.ToInt32(row["SiSo"]) : 0,
                NamHoc = row["NamHoc"].ToString(),
                GhiChu = row["GhiChu"]?.ToString()
            };
        }

        // ====================== SEARCH CLASS ======================
        public List<LopDTO> SearchLop(string maLop, string tenLop, int? khoiLop, string namHoc)
        {
            List<LopDTO> list = new List<LopDTO>();

            string query = $"SELECT * FROM Lop WHERE 1 = 1";

            
            if (!string.IsNullOrWhiteSpace(maLop))
            {
                query += $" AND MaLop = N'{maLop}'";
            }

            if (!string.IsNullOrWhiteSpace(tenLop))
            {
                query += $" AND TenLop = N'{tenLop}'";
            }

            if (khoiLop.HasValue)
            {
                query += $" AND KhoiLop = {khoiLop}";
            }

            if (!string.IsNullOrWhiteSpace(namHoc))
            {
                query += $" AND NamHoc = N'{namHoc}'";
            }

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }
        public int LaySiSo(string maLop)
        {
            string query = $"SELECT SiSo FROM LOP WHERE MaLop = '{maLop}'";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            return Convert.ToInt32(dataTable.Rows[0]["SiSo"]);
        }
    }
}
