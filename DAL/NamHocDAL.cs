using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class NamHocDAL
    {
        private static NamHocDAL _instance;

        public static NamHocDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NamHocDAL();
                return _instance;
            }
        }

        private NamHocDAL() { }

        // Lấy tất cả năm học
        public List<NamHocDTO> GetAllNamHoc()
        {
            List<NamHocDTO> list = new List<NamHocDTO>();
            string query = "SELECT * FROM NamHoc ORDER BY MaNamHoc DESC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NamHocDTO nh = new NamHocDTO
                {
                    MaNamHoc = row["MaNamHoc"].ToString(),
                    TenNamHoc = row["TenNamHoc"].ToString(),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(nh);
            }

            return list;
        }

        // Lấy năm học theo mã
        public NamHocDTO GetNamHocByMa(string maNamHoc)
        {
            string query = "SELECT * FROM NamHoc WHERE MaNamHoc = @MaNamHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maNamHoc });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NamHocDTO
                {
                    MaNamHoc = row["MaNamHoc"].ToString(),
                    TenNamHoc = row["TenNamHoc"].ToString(),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

        // Lấy năm học đang hoạt động
        public NamHocDTO GetNamHocHienTai()
        {
            string query = "SELECT TOP 1 * FROM NamHoc WHERE TrangThai = N'Đang hoạt động'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NamHocDTO
                {
                    MaNamHoc = row["MaNamHoc"].ToString(),
                    TenNamHoc = row["TenNamHoc"].ToString(),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

        // Thêm năm học mới
        public bool InsertNamHoc(NamHocDTO nh)
        {
            string query = "INSERT INTO NamHoc (TenNamHoc, NgayBatDau, NgayKetThuc, TrangThai) " +
                           "VALUES ( @TenNamHoc , @NgayBatDau , @NgayKetThuc , @TrangThai )";

            // Nếu TrangThai là chuỗi → chuyển sang bit
            bool trangThaiBit = nh.TrangThai == "Đang hoạt động";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                nh.TenNamHoc, nh.NgayBatDau, nh.NgayKetThuc, trangThaiBit
            });

            return result > 0;
        }




        // Cập nhật năm học
        public bool UpdateNamHoc(NamHocDTO nh)
        {
            string query = "UPDATE NamHoc SET TenNamHoc = @TenNamHoc , NgayBatDau = @NgayBatDau , " +
                           "NgayKetThuc = @NgayKetThuc , TrangThai = @TrangThai " +
                           "WHERE MaNamHoc = @MaNamHoc";

            // Nếu TrangThai là chuỗi → chuyển sang bit
            bool trangThaiBit = nh.TrangThai == "Đang hoạt động";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                nh.TenNamHoc, nh.NgayBatDau, nh.NgayKetThuc, trangThaiBit, nh.MaNamHoc
            });

            return result > 0;
        }

        // Xóa năm học
        public bool DeleteNamHoc(string maNamHoc)
        {
            string query = "DELETE FROM NamHoc WHERE MaNamHoc = @MaNamHoc";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maNamHoc });
            return result > 0;
        }
    }
}