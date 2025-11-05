
using System;
using System.Collections.Generic;
using DAL;
using DTO; 
namespace BLL
{
    public class HocSinhBLL
    {
        private static HocSinhBLL _instance;

        public static HocSinhBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HocSinhBLL();
                return _instance;
            }
        }

        private HocSinhBLL() { }

        public List<HocSinhDTO> GetAllHocSinh()
        {
            return HocSinhDAL.Instance.GetAllHocSinh();
        }
        public HocSinhDTO GetHocSinhByMa(string maHS)
        {
            return HocSinhDAL.Instance.GetHocSinhByMa(maHS);
        }
        
        public bool InsertHocSinh(HocSinhDTO hs)
        {
            if (string.IsNullOrWhiteSpace(hs.MaHocSinh))
                throw new Exception("Mã học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(hs.HoTen))
                throw new Exception("Tên học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(hs.GioiTinh))
                throw new Exception("Giới tính không được để trống");
            if (hs.NgaySinh == DateTime.MinValue)
                throw new Exception("Ngày sinh không hợp lệ");

            int tuoi = DateTime.Now.Year - hs.NgaySinh.Year;
            if (hs.NgaySinh.AddYears(tuoi) > DateTime.Now) tuoi--;
            if (tuoi < 15 || tuoi > 20)
                throw new Exception("Tuổi học sinh phải từ 15 đến 20");

            if (string.IsNullOrWhiteSpace(hs.DiaChi))
                throw new Exception("Địa chỉ không được để trống");

            if (string.IsNullOrWhiteSpace(hs.MaLop))
                throw new Exception("Mã lớp không được để trống");
            if (string.IsNullOrWhiteSpace(hs.TrangThai))
                hs.TrangThai = "1";
            if (string.IsNullOrWhiteSpace(hs.Email))
                throw new Exception("Email không được để trống");
            if (!IsValidEmail(hs.Email))
                throw new Exception("Email không hợp lệ");

            

            if (HocSinhDAL.Instance.GetHocSinhByMa(hs.MaHocSinh) != null)
                throw new Exception("Mã học sinh đã tồn tại");

            return HocSinhDAL.Instance.InsertHocSinh(hs);
        }

        public bool UpdateHocSinh(HocSinhDTO hs)
        {
            if (string.IsNullOrWhiteSpace(hs.MaHocSinh))
                throw new Exception("Mã học sinh không được để trống");

            return HocSinhDAL.Instance.UpdateHocSinh(hs);
        }

        public bool DeleteHocSinh(string maHS)
        {
            if (string.IsNullOrWhiteSpace(maHS))
                throw new Exception("Mã học sinh không được để trống");

            return HocSinhDAL.Instance.DeleteHocSinh(maHS);
        }

        public List<HocSinhDTO> GetHocSinhByLop(string maLop)
        {
            return HocSinhDAL.Instance.GetHocSinhByLop(maLop);
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

