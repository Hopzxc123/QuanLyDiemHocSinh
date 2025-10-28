using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class GiaoVienDAL
    {
        private static GiaoVienDAL _instance;
        public static GiaoVienDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GiaoVienDAL();
                return _instance;
            }
        }

        private GiaoVienDAL() { }

        // Lấy toàn bộ danh sách giáo viên
        public List<GiaoVienDTO> GetAllGiaoVien()
        {
            List<GiaoVienDTO> list = new List<GiaoVienDTO>();
            string query = "SELECT * FROM GiaoVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }

        // Lấy giáo viên theo mã
        public GiaoVienDTO GetGiaoVienById(int maGiaoVien)
        {
            string query = "SELECT * FROM GiaoVien WHERE MaGiaoVien = @MaGiaoVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maGiaoVien });

            if (data.Rows.Count > 0)
                return MapToDTO(data.Rows[0]);

            return null;
        }

        // Thêm mới
        public bool InsertGiaoVien(GiaoVienDTO gv)
        {
            string query = @"
                INSERT INTO GiaoVien (HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, Email, ChuyenMon, TrangThai)
                VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @DienThoai, @Email, @ChuyenMon, @TrangThai)";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                gv.HoTen, gv.NgaySinh, gv.GioiTinh, gv.DiaChi, gv.DienThoai,
                gv.Email, gv.ChuyenMon, gv.TrangThai
            });

            return result > 0;
        }

        // Cập nhật
        public bool UpdateGiaoVien(GiaoVienDTO gv)
        {
            string query = @"
                UPDATE GiaoVien
                SET HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    DiaChi = @DiaChi,
                    DienThoai = @DienThoai,
                    Email = @Email,
                    ChuyenMon = @ChuyenMon,
                    TrangThai = @TrangThai
                WHERE MaGiaoVien = @MaGiaoVien";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                gv.HoTen, gv.NgaySinh, gv.GioiTinh, gv.DiaChi, gv.DienThoai,
                gv.Email, gv.ChuyenMon, gv.TrangThai, gv.MaGiaoVien
            });

            return result > 0;
        }

        // Xóa
        public bool DeleteGiaoVien(int maGiaoVien)
        {
            string query = "DELETE FROM GiaoVien WHERE MaGiaoVien = @MaGiaoVien";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maGiaoVien });
            return result > 0;
        }

        // Tìm kiếm theo tên
        public List<GiaoVienDTO> SearchGiaoVienByName(string keyword)
        {
            List<GiaoVienDTO> list = new List<GiaoVienDTO>();
            string query = "SELECT * FROM GiaoVien WHERE HoTen LIKE N'%' + @keyword + '%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });

            foreach (DataRow row in data.Rows)
            {
                list.Add(MapToDTO(row));
            }

            return list;
        }

        // Helper: chuyển DataRow sang DTO
        private GiaoVienDTO MapToDTO(DataRow row)
        {
            return new GiaoVienDTO
            {
                MaGiaoVien = Convert.ToInt32(row["MaGiaoVien"]),
                HoTen = row["HoTen"].ToString(),
                NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                GioiTinh = row["GioiTinh"].ToString(),
                DiaChi = row["DiaChi"].ToString(),
                DienThoai = row["DienThoai"].ToString(),
                Email = row["Email"].ToString(),
                ChuyenMon = row["ChuyenMon"].ToString(),
                TrangThai = Convert.ToBoolean(row["TrangThai"])
            };
        }
    }
}
