// ===================================================================
// File: TaiKhoanDAL.cs
// Mô tả: Data Access Layer cho bảng TaiKhoan
// Chức năng: Đăng nhập, quản lý tài khoản, đổi mật khẩu
// ===================================================================

using System;
using System.Data;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL _instance;

        public static TaiKhoanDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TaiKhoanDAL();
                return _instance;
            }
        }

        private TaiKhoanDAL() { }

        // ======================== ĐĂNG NHẬP ========================

        // Kiểm tra đăng nhập
        public TaiKhoanDTO CheckLogin(string taiKhoan, string matKhau)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { taiKhoan, matKhau });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),                  
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

        // Kiểm tra tên đăng nhập tồn tại
        public bool CheckTenDangNhapExists(string tenDangNhap)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            int count = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { tenDangNhap });
            return count > 0;
        }

        // Cập nhật lần đăng nhập cuối
        public bool UpdateLastLogin(string maTaiKhoan)
        {
            string query = "UPDATE TaiKhoan SET LanDangNhapCuoi = GETDATE() WHERE MaTaiKhoan = @MaTaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maTaiKhoan });
            return result > 0;
        }

        // ======================== CRUD OPERATIONS ========================

        // Lấy tất cả tài khoản
        public List<TaiKhoanDTO> GetAllTaiKhoan()
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = "SELECT * FROM TaiKhoan ORDER BY NgayTao DESC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),               
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(tk);
            }

            return list;
        }

        // Lấy tài khoản theo mã
        public TaiKhoanDTO GetTaiKhoanByMa(string maTaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maTaiKhoan });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),                   
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

        // Lấy tài khoản theo tên đăng nhập
        public TaiKhoanDTO GetTaiKhoanByUsername(string tenDangNhap)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),                   
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
            }

            return null;
        }

        // Thêm tài khoản mới
        public bool InsertTaiKhoan(TaiKhoanDTO tk)
        {
            string query = "INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, TenDangNhap, MatKhau, NgayTao, TrangThai) " +
                          "VALUES ( @MaTaiKhoan , @TenDangNhap , @MatKhau , @TenDangNhap , @MatKhau , GETDATE() , @TrangThai )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                tk.MaTaiKhoan,
                tk.TenDangNhap,
                tk.MatKhau,
                tk.TenDangNhap,
                tk.MatKhau,
                tk.TrangThai
            });

            return result > 0;
        }

        // Cập nhật tài khoản
        public bool UpdateTaiKhoan(TaiKhoanDTO tk)
        {
            string query = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap , " +
                          "TenDangNhap = @TenDangNhap , MatKhau = @MatKhau , TrangThai = @TrangThai " +
                          "WHERE MaTaiKhoan = @MaTaiKhoan";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                tk.TenDangNhap,
                tk.TenDangNhap,
                tk.MatKhau,
                tk.TrangThai,
                tk.MaTaiKhoan
            });

            return result > 0;
        }

        // Xóa tài khoản
        public bool DeleteTaiKhoan(string maTaiKhoan)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maTaiKhoan });
            return result > 0;
        }

        // ======================== ĐỔI MẬT KHẨU ========================

        // Đổi mật khẩu
        public bool ChangePassword(string maTaiKhoan, string matKhauCu, string matKhauMoi)
        {
            // Kiểm tra mật khẩu cũ
            string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan AND MatKhau = @MatKhauCu";
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery, new object[] { maTaiKhoan, matKhauCu });

            if (count == 0)
                return false; // Mật khẩu cũ không đúng

            // Cập nhật mật khẩu mới
            string updateQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE MaTaiKhoan = @MaTaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(updateQuery, new object[] { matKhauMoi, maTaiKhoan });

            return result > 0;
        }

        // Reset mật khẩu (cho admin)
        public bool ResetPassword(string maTaiKhoan, string matKhauMoi)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE MaTaiKhoan = @MaTaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matKhauMoi, maTaiKhoan });
            return result > 0;
        }

        // ======================== QUẢN LÝ TRẠNG THÁI ========================

        // Kích hoạt/Vô hiệu hóa tài khoản
        public bool UpdateTrangThai(string maTaiKhoan, string trangThai)
        {
            string query = "UPDATE TaiKhoan SET TrangThai = @TrangThai WHERE MaTaiKhoan = @MaTaiKhoan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { trangThai, maTaiKhoan });
            return result > 0;
        }

        // Lấy tài khoản đang hoạt động
        public List<TaiKhoanDTO> GetActiveTaiKhoan()
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = "SELECT * FROM TaiKhoan WHERE TrangThai = N'Hoạt động' ORDER BY TenDangNhap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(tk);
            }

            return list;
        }

        // ======================== TÌM KIẾM & THỐNG KÊ ========================

        // Tìm kiếm tài khoản theo tên đăng nhập hoặc họ tên
        public List<TaiKhoanDTO> SearchTaiKhoan(string tuKhoa)
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE N'%' + @TuKhoa + '%' " +
                          "OR TenDangNhap LIKE N'%' + @TuKhoa + '%' " +
                          "ORDER BY TenDangNhap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tuKhoa });

            foreach (DataRow row in data.Rows)
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(tk);
            }

            return list;
        }

        // Đếm số tài khoản theo trạng thái
        public int CountTaiKhoanByTrangThai(string trangThai)
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TrangThai = @TrangThai";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { trangThai });
        }

        // Đếm tổng số tài khoản
        public int CountAllTaiKhoan()
        {
            string query = "SELECT COUNT(*) FROM TaiKhoan";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        // Lấy tài khoản đăng nhập gần đây
        public List<TaiKhoanDTO> GetRecentLoginAccounts(int soLuong)
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = "SELECT TOP ( @SoLuong ) * FROM TaiKhoan " +
                          "WHERE LanDangNhapCuoi IS NOT NULL " +
                          "ORDER BY LanDangNhapCuoi DESC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { soLuong });

            foreach (DataRow row in data.Rows)
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    MaTaiKhoan = row["MaTaiKhoan"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    LanDangNhapCuoi = row["LanDangNhapCuoi"] != DBNull.Value ?
                                      Convert.ToDateTime(row["LanDangNhapCuoi"]) : (DateTime?)null,
                    NgayTao = row["NgayTao"] != DBNull.Value ?
                             Convert.ToDateTime(row["NgayTao"]) : DateTime.Now,
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(tk);
            }

            return list;
        }
    }
}