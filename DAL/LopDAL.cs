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
        public LopDTO GetLopByMa(int maLop)
        {
            string query = "SELECT * FROM Lop WHERE MaLop = @MaLop";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLop });

            if (data.Rows.Count > 0)
                return MapToDTO(data.Rows[0]);

            return null;
        }

        // Lấy lớp theo năm học
        public List<LopDTO> GetLopByNamHoc(int namHoc)
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
            string query = $"INSERT INTO Lop(TenLop, KhoiLop, SiSo, NamHoc,GhiChu)" +
                $" VALUES(N'{lop.TenLop}', {lop.KhoiLop}, {lop.SiSo}, {lop.NamHoc}, N'{lop.GhiChu}')";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // ====================== UPDATE ======================

        public bool UpdateLop(LopDTO lop)
        {
            string query = $"UPDATE Lop SET TenLop = N'{lop.TenLop}'," +
                $" KhoiLop = {lop.KhoiLop}, SiSo = {lop.SiSo}, NamHoc = {lop.NamHoc}, GhiChu = N'{lop.GhiChu}'" +
                $"WHERE MaLop = {lop.MaLop}";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        // ====================== DELETE ======================

        public bool DeleteLop(int maLop)
        {
            string query = "DELETE FROM Lop WHERE MaLop = @MaLop";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLop });
            return result > 0;
        }

        // ====================== SUPPORT ======================

        public int CountHocSinhInLop(int maLop)
        {
            string query = "SELECT COUNT(*) FROM HocSinh WHERE MaLop = @MaLop";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maLop });
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool CheckMaLopExists(int maLop)
        {
            return GetLopByMa(maLop) != null;
        }

        // ====================== PRIVATE HELPER ======================

        private LopDTO MapToDTO(DataRow row)
        {
            return new LopDTO
            {
                MaLop = row["MaLop"] != DBNull.Value ? Convert.ToInt32(row["MaLop"]) : 0,
                TenLop = row["TenLop"]?.ToString(),
                KhoiLop = row["KhoiLop"] != DBNull.Value ? Convert.ToInt32(row["KhoiLop"]) : 0,
                SiSo = row["SiSo"] != DBNull.Value ? Convert.ToInt32(row["SiSo"]) : 0,
                NamHoc = row["NamHoc"] != DBNull.Value ? Convert.ToInt32(row["NamHoc"]) : 0,
                GhiChu = row["GhiChu"]?.ToString()
            };
        }
    }
}
