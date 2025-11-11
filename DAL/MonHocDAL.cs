
// ==================== MonHocDAL.cs ====================
using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class MonHocDAL
    {
        private static MonHocDAL _instance;

        public static MonHocDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MonHocDAL();
                return _instance;
            }
        }

        private MonHocDAL() { }

        // Lấy tất cả môn học
        public List<MonHocDTO> GetAllMonHoc()
        {
            List<MonHocDTO> list = new List<MonHocDTO>();
            string query = "SELECT * FROM MonHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                MonHocDTO mh = new MonHocDTO
                {
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString(),
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1,
                    GhiChu = row["GhiChu"].ToString()
                };
                list.Add(mh);
            }

            return list;
        }

        // Lấy môn học theo mã
        public MonHocDTO GetMonHocByMa(string maMonHoc)
        {
            string query = "SELECT * FROM MonHoc WHERE MaMonHoc = @MaMonHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maMonHoc });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new MonHocDTO
                {
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString(),
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1,
                    GhiChu = row["GhiChu"].ToString()
                };
            }

            return null;
        }

        //Lấy môn học theo tên
        public MonHocDTO GetMonHocByTen(string tenMonHoc)
        {
            string query = "SELECT * FROM MonHoc WHERE MaMonHoc = @MaMonHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenMonHoc });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new MonHocDTO
                {
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString(),
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1
                };
            }

            return null;
        }

        // Thêm môn học mới
        public bool InsertMonHoc(MonHocDTO mh)
        {
            string query = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, HeSo, GhiChu) " +
                          "VALUES ( @MaMonHoc , @TenMonHoc , @HeSo , @GhiChu )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                mh.MaMonHoc, mh.TenMonHoc, mh.HeSo, mh.GhiChu
            });

            return result > 0;
        }

        // Cập nhật môn học
        public bool UpdateMonHoc(MonHocDTO mh)
        {
            string query = "UPDATE MonHoc SET TenMonHoc = @TenMonHoc , HeSo = @HeSo , GhiChu = @GhiChu " +
                          "WHERE MaMonHoc = @MaMonHoc ";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                mh.TenMonHoc, mh.HeSo, mh.GhiChu , mh.MaMonHoc
            });

            return result > 0;
        }

        // Xóa môn học
        public bool DeleteMonHoc(string maMonHoc)
        {
            string query = "DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc });
            return result > 0;
        }

        // Tìm kiếm môn học theo tên
        public List<MonHocDTO> SearchMonHocByName(string tenMonHoc)
        {
            List<MonHocDTO> list = new List<MonHocDTO>();
            string query = "SELECT * FROM MonHoc WHERE TenMonHoc LIKE N'%' + @TenMonHoc + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenMonHoc });

            foreach (DataRow row in data.Rows)
            {
                MonHocDTO mh = new MonHocDTO
                {
                    MaMonHoc = row["MaMonHoc"].ToString(),
                    TenMonHoc = row["TenMonHoc"].ToString(),
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1,
                    GhiChu = row["GhiChu"].ToString()
                };
                list.Add(mh);
            }

            return list;
        }
        public bool CheckMaMonHocExists(string maMonHoc)
        {
            return GetMonHocByMa(maMonHoc) != null;
        }
    }
}