// ==================== HocSinhDAL.cs ====================
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
            string query = "SELECT * FROM HocSinh WHERE MaHocSinh = @MaHocSinh";
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

        // Thêm học sinh mới
        public bool InsertHocSinh(HocSinhDTO hs)
        {
            string query = "INSERT INTO HocSinh (MaHocSinh, HoTen, NgaySinh, GioiTinh, DiaChi, Email, MaLop, TrangThai) " +
                          "VALUES ( @MaHocSinh , @HoTen , @NgaySinh , @GioiTinh , @DiaChi , @Email , @MaLop , @TrangThai )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                hs.MaHocSinh, hs.HoTen, hs.NgaySinh, hs.GioiTinh,
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
            string query = "SELECT * FROM Diem WHERE MaHocSinh = @MaHocSinh AND MaMonHoc = @MaMonHoc AND MaHocKy = @MaHocKy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maHocSinh, maMonHoc, maHocKy });

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
            string query = @"INSERT INTO Diem (MaDiem, MaHocSinh, MaMonHoc, MaHocKy, 
                            DiemTrenLop, DiemGiuaKy, DiemThi, DiemTongKet)
                            VALUES (@MaDiem, @MaHocSinh, @MaMonHoc, @MaHocKy, 
                            @DiemTrenLop, @DiemGiuaKy, @DiemThi, @DiemTongKet)";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                diem.MaDiem, diem.MaHocSinh, diem.MaMonHoc, diem.MaHocKy,
                diem.DiemTrenLop ?? (object)DBNull.Value,
                diem.DiemGiuaKy ?? (object)DBNull.Value,
                diem.DiemThi ?? (object)DBNull.Value,
                diem.DiemTongKet ?? (object)DBNull.Value
            });

            return result > 0;
        }

        // Cập nhật điểm
        public bool UpdateDiem(DiemDTO diem)
        {
            string query = @"UPDATE Diem SET 
                            MaHocSinh = @MaHocSinh, 
                            MaMonHoc = @MaMonHoc, 
                            MaHocKy = @MaHocKy, 
                            DiemTrenLop = @DiemTrenLop, 
                            DiemGiuaKy = @DiemGiuaKy, 
                            DiemThi = @DiemThi, 
                            DiemTongKet = @DiemTongKet
                            WHERE MaDiem = @MaDiem";

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
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1
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
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1
                };
            }

            return null;
        }

        // Thêm môn học mới
        public bool InsertMonHoc(MonHocDTO mh)
        {
            string query = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, HeSo) " +
                          "VALUES ( @MaMonHoc , @TenMonHoc , @HeSo )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                mh.MaMonHoc, mh.TenMonHoc, mh.HeSo
            });

            return result > 0;
        }

        // Cập nhật môn học
        public bool UpdateMonHoc(MonHocDTO mh)
        {
            string query = "UPDATE MonHoc SET TenMonHoc = @TenMonHoc , HeSo = @HeSo " +
                          "WHERE MaMonHoc = @MaMonHoc";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                mh.TenMonHoc, mh.HeSo, mh.MaMonHoc
            });

            return result > 0;
        }

        // Xóa môn học
        public bool DeleteMonHoc(string maMonHoc)
        {
            string query = "DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc";
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
                    HeSo = row["HeSo"] != DBNull.Value ? Convert.ToInt32(row["HeSo"]) : 1
                };
                list.Add(mh);
            }

            return list;
        }
    }
}

// ==================== NamHocDAL.cs ====================
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
            string query = "INSERT INTO NamHoc (MaNamHoc, TenNamHoc, NgayBatDau, NgayKetThuc, TrangThai) " +
                          "VALUES ( @MaNamHoc , @TenNamHoc , @NgayBatDau , @NgayKetThuc , @TrangThai )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                nh.MaNamHoc, nh.TenNamHoc, nh.NgayBatDau, nh.NgayKetThuc, nh.TrangThai
            });

            return result > 0;
        }

        // Cập nhật năm học
        public bool UpdateNamHoc(NamHocDTO nh)
        {
            string query = "UPDATE NamHoc SET TenNamHoc = @TenNamHoc , NgayBatDau = @NgayBatDau , " +
                          "NgayKetThuc = @NgayKetThuc , TrangThai = @TrangThai " +
                          "WHERE MaNamHoc = @MaNamHoc";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                nh.TenNamHoc, nh.NgayBatDau, nh.NgayKetThuc, nh.TrangThai, nh.MaNamHoc
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

// ==================== HocKyDAL.cs ====================
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

        // Lấy tất cả học kỳ
        public List<HocKyDTO> GetAllHocKy()
        {
            List<HocKyDTO> list = new List<HocKyDTO>();
            string query = "SELECT * FROM HocKy";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                HocKyDTO hk = new HocKyDTO
                {
                    MaHocKy = row["MaHocKy"].ToString(),
                    TenHocKy = row["TenHocKy"].ToString(),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    MaNamHoc = row["MaNamHoc"].ToString()
                };
                list.Add(hk);
            }

            return list;
        }

        // Lấy học kỳ theo mã
        public HocKyDTO GetHocKyByMa(string maHocKy)
        {
            string query = "SELECT * FROM HocKy WHERE MaHocKy = @MaH