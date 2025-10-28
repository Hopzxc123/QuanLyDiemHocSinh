using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class LopBLL
    {
        private LopDAL dal = new LopDAL();

        public List<LopDTO> GetAll() => dal.GetAll();
        public bool Insert(LopDTO dto) => dal.Insert(dto);
        public bool Update(LopDTO dto) => dal.Update(dto);
        public bool Delete(int id) => dal.Delete(id);
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

        public List<LopDTO> GetAllLop()
        {
            return LopDAL.Instance.GetAllLop();
        }

        public bool InsertLop(LopDTO lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new Exception("Mã lớp không được để trống");
            if (string.IsNullOrWhiteSpace(lop.TenLop))
                throw new Exception("Tên lớp không được để trống");
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new Exception("Mã khối không được để trống");

            if (LopDAL.Instance.CheckMaLopExists(lop.MaLop))
                throw new Exception("Mã lớp đã tồn tại");

            return LopDAL.Instance.InsertLop(lop);
        }

        public bool UpdateLop(LopDTO lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new Exception("Mã lớp không được để trống");

            return LopDAL.Instance.UpdateLop(lop);
        }

        public bool DeleteLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new Exception("Mã lớp không được để trống");

            int soHocSinh = LopDAL.Instance.CountHocSinhInLop(maLop);
            if (soHocSinh > 0)
                throw new Exception($"Không thể xóa lớp vì còn {soHocSinh} học sinh");

            return LopDAL.Instance.DeleteLop(maLop);
        }
    }
}
