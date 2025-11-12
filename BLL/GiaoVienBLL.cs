using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class GiaoVienBLL
    {
        // 1. Tạo Singleton Pattern (giống như DAL)
        private static GiaoVienBLL _instance;
        public static GiaoVienBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GiaoVienBLL();
                return _instance;
            }
        }
        private GiaoVienBLL() { }

        // 2. Hàm lấy toàn bộ danh sách
        // (Thường không có logic gì, chỉ gọi DAL)
        //public List<GiaoVienDTO> GetAllGiaoVien()
        // {
        // Gọi trực tiếp GiaoVienDAL qua Singleton
        //    return GiaoVienDAL.Instance.GetAllGiaoVien();

        //  }
        public List<GiaoVienDTO> GetAllGiaoVien()
        {
            return GiaoVienDAL.Instance.GetAllGiaoVien();
        }
        // 3. Hàm thêm mới (Nơi chứa logic nghiệp vụ)
        // Trả về string để thông báo lỗi cụ thể cho GUI
        public string InsertGiaoVien(GiaoVienDTO gv)
        {
            // --- KIỂM TRA LOGIC NGHIỆP VỤ ---

            // Ví dụ 1: Họ tên không được để trống
            if (string.IsNullOrWhiteSpace(gv.HoTen))
            {
                return "Họ tên giáo viên không được để trống.";
            }

            // Ví dụ 2: Email phải hợp lệ (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(gv.Email) && !gv.Email.Contains("@"))
            {
                return "Email không đúng định dạng.";
            }

            // Ví dụ 3: Ngày sinh phải hợp lệ (ví dụ: giáo viên phải > 18 tuổi)
            if (gv.NgaySinh > DateTime.Now.AddYears(-18))
            {
                return "Giáo viên phải ít nhất 18 tuổi.";
            }

            // (Thêm các quy tắc kiểm tra khác của bạn ở đây...)

            // --- Sau khi kiểm tra OK, gọi DAL ---
            if (GiaoVienDAL.Instance.InsertGiaoVien(gv))
            {
                return "Thêm giáo viên thành công.";
            }
            else
            {
                return "Thêm thất bại. Đã có lỗi xảy ra ở tầng CSDL.";
            }
        }

        // 4. Hàm cập nhật (Tương tự hàm Thêm)
        public string UpdateGiaoVien(GiaoVienDTO gv)
        {
            // --- KIỂM TRA LOGIC NGHIỆP VỤ ---

            // Phải có MaGiaoVien để biết cập nhật ai
            if (string.IsNullOrWhiteSpace(gv.MaGiaoVien))
            {
                return "Mã giáo viên không hợp lệ.";
            }

            if (string.IsNullOrWhiteSpace(gv.HoTen))
            {
                return "Họ tên giáo viên không được để trống.";
            }

            if (gv.NgaySinh > DateTime.Now.AddYears(-18))
            {
                return "Giáo viên phải ít nhất 18 tuổi.";
            }

            // --- Sau khi kiểm tra OK, gọi DAL ---
            if (GiaoVienDAL.Instance.UpdateGiaoVien(gv))
            {
                return "Cập nhật thành công.";
            }
            else
            {
                return "Cập nhật thất bại. Đã có lỗi xảy ra ở tầng CSDL.";
            }
        }

        // 5. Hàm xóa
        public string DeleteGiaoVien(string maGiaoVien)
        {
            string maGV = maGiaoVien?.Trim();
            if (string.IsNullOrEmpty(maGV))
            {
                return "Mã giáo viên không hợp lệ.";
            }

            // --- KIỂM TRA LOGIC NGHIỆP VỤ PHỨC TẠP ---
            // Ví dụ: trước khi xóa, BLL phải kiểm tra xem
            // giáo viên này có đang dạy lớp nào không?
            // (Giả sử bạn có LopHocBLL.Instance.KiemTraGiaoVienDangDay(maGiaoVien))

            // if (LopHocBLL.Instance.KiemTraGiaoVienDangDay(maGiaoVien))
            // {
            //    return "Không thể xóa giáo viên đang có lớp dạy.";
            // }

            // --- Nếu mọi logic đều OK, gọi DAL ---
            if (GiaoVienDAL.Instance.DeleteGiaoVien(maGiaoVien))
            {
                return "Xóa thành công.";
            }
            else
            {
                return "Xóa thất bại. Đã có lỗi xảy ra ở tầng CSDL.";
            }
        }

        // 6. Hàm tìm kiếm
        public List<GiaoVienDTO> SearchGiaoVienByName(string keyword)
        {
            // Logic nghiệp vụ: Nếu keyword rỗng, trả về tất cả
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllGiaoVien();
            }

            // Gọi DAL
            return GiaoVienDAL.Instance.SearchGiaoVienByName(keyword.Trim());
        }
    }
}