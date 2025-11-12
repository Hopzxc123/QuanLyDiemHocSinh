using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class HocSinhDAL
    {
        private static HocSinhDAL _instance;

        public static HocSinhDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HocSinhDAL();
                return _instance;
            }
        }

        private HocSinhDAL() { }

        // Lấy tất cả học sinh
        public List<HocSinhDTO> GetAllHocSinh()
        {
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            string query = "SELECT * FROM HocSinh";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                HocSinhDTO hs = new HocSinhDTO
                {
                    MaHocSinh = row["MaHocSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(hs);
            }

            return list;
        }

        // Lấy học sinh theo mã
        public HocSinhDTO GetHocSinhByMa(string maHocSinh)
        {
            string query = $"SELECT * FROM HocSinh WHERE MaHocSinh = '{maHocSinh}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maHocSinh });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new HocSinhDTO
                {
                    MaHocSinh = row["MaHocSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }
        public List<HocSinhDTO> GetHocSinhByNamHoc(string maNamHoc)
        {
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            string query = "SELECT hs.* FROM HocSinh as hs " +
                           "JOIN Lop as l ON hs.MaLop = l.MaLop " +
                           $"WHERE l.NamHoc = '{maNamHoc}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                HocSinhDTO hs = new HocSinhDTO
                {
                    MaHocSinh = row["MaHocSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(hs);
            }
            return list;
        }
        // Thêm học sinh mới
        public bool InsertHocSinh(HocSinhDTO hs)
        {
            string query = "INSERT INTO HocSinh ( HoTen, NgaySinh, GioiTinh, DiaChi, Email, MaLop, TrangThai) " +
                          "VALUES (  @HoTen , @NgaySinh , @GioiTinh , @DiaChi , @Email , @MaLop , @TrangThai )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                hs.HoTen, hs.NgaySinh, hs.GioiTinh,
                hs.DiaChi, hs.Email, hs.MaLop, hs.TrangThai
            });

            return result > 0;
        }

        // Cập nhật học sinh
        public bool UpdateHocSinh(HocSinhDTO hs)
        {
            string query = "UPDATE HocSinh SET HoTen = @HoTen , NgaySinh = @NgaySinh , " +
                          "GioiTinh = @GioiTinh , DiaChi = @DiaChi , Email = @Email , " +
                          "MaLop = @MaLop , TrangThai = @TrangThai " +
                          "WHERE MaHocSinh = @MaHocSinh";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                hs.HoTen, hs.NgaySinh, hs.GioiTinh, hs.DiaChi,
                hs.Email, hs.MaLop, hs.TrangThai, hs.MaHocSinh
            });

            return result > 0;
        }

        // Xóa học sinh
        public bool DeleteHocSinh(string maHocSinh)
        {
            string query = "DELETE FROM HocSinh WHERE MaHocSinh = @MaHocSinh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHocSinh });
            return result > 0;
        }

        // Tìm kiếm học sinh theo tên
        public List<HocSinhDTO> SearchHocSinhByName(string tenHocSinh)
        {
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            string query = "SELECT * FROM HocSinh WHERE HoTen LIKE N'%' + @TenHocSinh + '%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenHocSinh });

            foreach (DataRow row in data.Rows)
            {
                HocSinhDTO hs = new HocSinhDTO
                {
                    MaHocSinh = row["MaHocSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(hs);
            }

            return list;
        }

        // Lấy học sinh theo lớp
        public List<HocSinhDTO> GetHocSinhByLop(string maLop)
        {
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            string query = "SELECT * FROM HocSinh WHERE MaLop = @MaLop";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLop });

            foreach (DataRow row in data.Rows)
            {
                HocSinhDTO hs = new HocSinhDTO
                {
                    MaHocSinh = row["MaHocSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    MaLop = row["MaLop"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(hs);
            }

            return list;
        }
    }
}