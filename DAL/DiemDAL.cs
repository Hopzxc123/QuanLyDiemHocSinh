// ==================== DiemDAL.cs ====================
using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class DiemDAL
    {
        private static DiemDAL _instance;

        public static DiemDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DiemDAL();
                return _instance;
            }
        }

        private DiemDAL() { }

        // Lấy tất cả điểm
        public List<DiemDTO> GetAllDiem()
        {
            List<DiemDTO> list = new List<DiemDTO>();
            string query = "SELECT * FROM Diem";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapRowToDiemDTO(row));
            }

            return list;
        }

        // Lấy điểm theo mã
        public DiemDTO GetDiemByMa(string maDiem)
        {
            string query = "SELECT * FROM Diem WHERE MaDiem = @MaDiem";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maDiem });

            if (data.Rows.Count > 0)
                return MapRowToDiemDTO(data.Rows[0]);

            return null;
        }

        // Lấy điểm theo học sinh và môn học
        public DiemDTO GetDiemByHocSinhMonHoc(string maHocSinh, string maMonHoc, string maHocKy)
        {
            string query = $"SELECT * FROM Diem WHERE MaHocSinh ={maHocSinh} AND MaMonHoc = {maMonHoc} AND MaHocKy = {maHocKy}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
                return MapRowToDiemDTO(data.Rows[0]);

            return null;
        }

        // Lấy tất cả điểm của học sinh
        public List<DiemDTO> GetDiemByHocSinh(string maHocSinh)
        {
            List<DiemDTO> list = new List<DiemDTO>();
            string query = "SELECT * FROM Diem WHERE MaHocSinh = @MaHocSinh";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maHocSinh });

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapRowToDiemDTO(row));
            }

            return list;
        }

        // Thêm điểm mới
        public bool InsertDiem(DiemDTO diem)
        {
            string query = @"INSERT INTO Diem (MaHocSinh, MaMonHoc, MaHocKy, 
                            DiemTrenLop, DiemGiuaKy, DiemThi, DiemTongKet)"+
                            $"VALUES ({diem.MaHocSinh}, {diem.MaMonHoc},{diem.MaHocKy}, {diem.DiemTrenLop}, {diem.DiemGiuaKy}, {diem.DiemThi}, {diem.DiemTongKet})";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Cập nhật điểm
        public bool UpdateDiem(DiemDTO diem)
        {
            string query = @"UPDATE Diem SET "+
                            
                            $"MaMonHoc = {diem.MaMonHoc}, MaHocKy = {diem.MaHocKy}, DiemTrenLop = {diem.DiemTrenLop}, DiemGiuaKy = {diem.DiemGiuaKy}, DiemThi = {diem.DiemThi}, DiemTongKet = {diem.DiemTongKet} WHERE MaDiem = {diem.MaDiem}";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                diem.MaHocSinh, diem.MaMonHoc, diem.MaHocKy,
                diem.DiemTrenLop ?? (object)DBNull.Value,
                diem.DiemGiuaKy ?? (object)DBNull.Value,
                diem.DiemThi ?? (object)DBNull.Value,
                diem.DiemTongKet ?? (object)DBNull.Value,
                diem.MaDiem
            });

            return result > 0;
        }

        // Xóa điểm
        public bool DeleteDiem(string maDiem)
        {
            string query = "DELETE FROM Diem WHERE MaDiem = @MaDiem";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDiem });
            return result > 0;
        }

        // Tính điểm tổng kết tự động
        public bool TinhDiemTongKet(string maDiem)
        {
            string query = @"UPDATE Diem SET DiemTongKet = 
                            (ISNULL(DiemTrenLop, 0) * 0.3 + 
                             ISNULL(DiemGiuaKy, 0) * 0.3 + 
                             ISNULL(DiemThi, 0) * 0.4)
                             WHERE MaDiem = @MaDiem";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDiem });
            return result > 0;
        }

        // Map DataRow sang DiemDTO
        private DiemDTO MapRowToDiemDTO(DataRow row)
        {
            return new DiemDTO
            {
                MaDiem = row["MaDiem"].ToString(),
                MaHocSinh = row["MaHocSinh"].ToString(),
                MaMonHoc = row["MaMonHoc"].ToString(),
                MaHocKy = row["MaHocKy"].ToString(),
                DiemTrenLop = row["DiemTrenLop"] != DBNull.Value ? (float?)Convert.ToSingle(row["DiemTrenLop"]) : null,
                DiemGiuaKy = row["DiemGiuaKy"] != DBNull.Value ? (float?)Convert.ToSingle(row["DiemGiuaKy"]) : null,
                DiemThi = row["DiemThi"] != DBNull.Value ? (float?)Convert.ToSingle(row["DiemThi"]) : null,
                DiemTongKet = row["DiemTongKet"] != DBNull.Value ? (float?)Convert.ToSingle(row["DiemTongKet"]) : null
            };
        }
    }
}
