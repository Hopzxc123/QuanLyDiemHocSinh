using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class LopBLL
    {
        private static LopBLL _instance;

        public static LopBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LopBLL();
                return _instance;
            }
        }

        private LopBLL() { }

        // ====================== READ ======================

        public List<LopDTO> GetAllLop()
        {
            return LopDAL.Instance.GetAllLop();
        }

        public LopDTO GetLopByMa(int maLop)
        {
            if (maLop <= 0)
                throw new Exception("Mã lớp không hợp lệ.");
            return LopDAL.Instance.GetLopByMa(maLop);
        }

        public List<LopDTO> GetLopByNamHoc(int namHoc)
        {
            if (namHoc <= 0)
                throw new Exception("Năm học không hợp lệ.");
            return LopDAL.Instance.GetLopByNamHoc(namHoc);
        }

        // ====================== CREATE ======================

        public bool InsertLop(LopDTO lop)
        {
            ValidateLop(lop, isInsert: true);
            return LopDAL.Instance.InsertLop(lop);
        }

        // ====================== UPDATE ======================

        public bool UpdateLop(LopDTO lop)
        {
            ValidateLop(lop, isInsert: false);
            return LopDAL.Instance.UpdateLop(lop);
        }

        // ====================== DELETE ======================

        public bool DeleteLop(int maLop)
        {
            if (maLop <= 0)
                throw new Exception("Mã lớp không hợp lệ.");

            int soHocSinh = LopDAL.Instance.CountHocSinhInLop(maLop);
            if (soHocSinh > 0)
                throw new Exception($"Không thể xóa lớp vì còn {soHocSinh} học sinh.");

            return LopDAL.Instance.DeleteLop(maLop);
        }

        // ====================== VALIDATION ======================

        private void ValidateLop(LopDTO lop, bool isInsert)
        {
            if (lop == null)
                throw new Exception("Thông tin lớp không hợp lệ.");
            if (string.IsNullOrWhiteSpace(lop.TenLop))
                throw new Exception("Tên lớp không được để trống.");
            if (lop.KhoiLop <= 0)
                throw new Exception("Khối lớp phải lớn hơn 0.");
            if (lop.NamHoc <= 0)
                throw new Exception("Năm học phải hợp lệ.");

            if (isInsert && LopDAL.Instance.CheckMaLopExists(lop.MaLop))
                throw new Exception("Mã lớp đã tồn tại.");
        }
    }
}
