using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class NamHocBLL
    {
        private static NamHocBLL _instance;

        public static NamHocBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NamHocBLL();
                return _instance;
            }
        }

        private NamHocBLL() { }

        public List<NamHocDTO> GetAllNamHoc()
        {
            return NamHocDAL.Instance.GetAllNamHoc();
        }

        public bool InsertNamHoc(NamHocDTO nh)
        {
            if (string.IsNullOrWhiteSpace(nh.MaNamHoc))
                throw new Exception("Mã năm học không được để trống");
            if (string.IsNullOrWhiteSpace(nh.TenNamHoc))
                throw new Exception("Tên năm học không được để trống");

            if (NamHocDAL.Instance.CheckMaNamHocExists(nh.MaNamHoc))
                throw new Exception("Mã năm học đã tồn tại");

            return NamHocDAL.Instance.InsertNamHoc(nh);
        }
        public NamHocDTO GetNamHocByMa(string maNamHoc)
        {
            return NamHocDAL.Instance.GetNamHocByMa(maNamHoc);
        }
        public bool UpdateNamHoc(NamHocDTO nh)
        {
            if (string.IsNullOrWhiteSpace(nh.MaNamHoc))
                throw new Exception("Mã năm học không được để trống");

            return NamHocDAL.Instance.UpdateNamHoc(nh);
        }

        public bool DeleteNamHoc(string maNamHoc)
        {
            if (string.IsNullOrWhiteSpace(maNamHoc))
                throw new Exception("Mã năm học không được để trống");

            return NamHocDAL.Instance.DeleteNamHoc(maNamHoc);
        }
    }
}
