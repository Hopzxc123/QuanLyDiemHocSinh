using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class HocKyBLL
    {
        private static HocKyBLL _instance;

        public static HocKyBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HocKyBLL();
                return _instance;
            }
        }

        private HocKyBLL() { }

        public List<HocKyDTO> GetAllHocKy()
        {
            return HocKyDAL.Instance.GetAllHocKy();
        }

        public bool InsertHocKy(HocKyDTO hk)
        {
            if (string.IsNullOrWhiteSpace(hk.MaHocKy))
                throw new Exception("Mã học kỳ không được để trống");
            if (string.IsNullOrWhiteSpace(hk.TenHocKy))
                throw new Exception("Tên học kỳ không được để trống");

            if (HocKyDAL.Instance.CheckMaHocKyExists(hk.MaHocKy))
                throw new Exception("Mã học kỳ đã tồn tại");

            return HocKyDAL.Instance.InsertHocKy(hk);
        }

        public bool UpdateHocKy(HocKyDTO hk)
        {
            if (string.IsNullOrWhiteSpace(hk.MaHocKy))
                throw new Exception("Mã học kỳ không được để trống");

            return HocKyDAL.Instance.UpdateHocKy(hk);
        }

        public bool DeleteHocKy(string maHocKy)
        {
            if (string.IsNullOrWhiteSpace(maHocKy))
                throw new Exception("Mã học kỳ không được để trống");

            return HocKyDAL.Instance.DeleteHocKy(maHocKy);
        }
    }
}
