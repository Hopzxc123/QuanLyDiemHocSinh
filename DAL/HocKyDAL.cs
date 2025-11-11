using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class HocKyDAL
    {
        private static HocKyDAL _instance;

        public static HocKyDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HocKyDAL();
                return _instance;
            }
        }

        private HocKyDAL() { }

        // 🔹 Lấy tất cả học kỳ
        public List<HocKyDTO> GetAllHocKy()
        {
            List<HocKyDTO> list = new List<HocKyDTO>();
            string query = "SELECT * FROM HocKy";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }
        public List<HocKyDTO> GetHocKyByNamHoc(string maNamHoc)
        {
            List<HocKyDTO> list = new List<HocKyDTO>();
            string query = $"SELECT * FROM HocKy where MaNamHoc ='{maNamHoc}'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }
        // 🔹 Lấy học kỳ theo mã
        public HocKyDTO GetHocKyById(string maHocKy)
        {
            string query = "SELECT * FROM HocKy WHERE MaHocKy = @MaHocKy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maHocKy });

            if (data.Rows.Count > 0)
                return MapToDTO(data.Rows[0]);

            return null;
        }

        // 🔹 Lấy học kỳ theo năm học
        public List<HocKyDTO> GetHocKyByNamHoc(int maNamHoc)
        {
            List<HocKyDTO> list = new List<HocKyDTO>();
            string query = "SELECT * FROM HocKy WHERE MaNamHoc = @MaNamHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maNamHoc });

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }

        // 🔹 Thêm mới học kỳ
        public bool InsertHocKy(HocKyDTO hk)
        {
            // Ghép chuỗi trực tiếp thay vì dùng tham số
            string query =
                "INSERT INTO HocKy (MaNamHoc, TenHocKy, NgayBatDau, NgayKetThuc) VALUES (" +
                $"'{hk.MaNamHoc}', " +
                $"N'{hk.TenHocKy.Replace("'", "''")}', " +
                $"'{hk.NgayBatDau:yyyy-MM-dd}', " +
                $"'{hk.NgayKetThuc:yyyy-MM-dd}')";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


        // 🔹 Cập nhật học kỳ
        public bool UpdateHocKy(HocKyDTO hk)
        {
            string query = $@"
        UPDATE HocKy
        SET MaNamHoc = N'{hk.MaNamHoc}',
            TenHocKy = N'{hk.TenHocKy}',
            NgayBatDau = '{hk.NgayBatDau:yyyy-MM-dd}',
            NgayKetThuc = '{hk.NgayKetThuc:yyyy-MM-dd}'
        WHERE MaHocKy = N'{hk.MaHocKy}'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }



        // 🔹 Xóa học kỳ
        public bool DeleteHocKy(int maHocKy)
        {
            string query = "DELETE FROM HocKy WHERE MaHocKy = @MaHocKy";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHocKy });
            return result > 0;
        }

        // 🔹 Hàm chuyển DataRow -> DTO
        private HocKyDTO MapToDTO(DataRow row)
        {
            return new HocKyDTO
            {
                MaHocKy = row["MaHocKy"].ToString(),
                MaNamHoc = row["MaNamHoc"].ToString(),
                TenHocKy = row["TenHocKy"].ToString(),
                NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"])
            };
        }
        public bool CheckMaHocKyExists(string maHocKy)
        {
            var allHocKy = GetAllHocKy();
            return allHocKy.Exists(hk => hk.MaHocKy == maHocKy);
        }
    }
}