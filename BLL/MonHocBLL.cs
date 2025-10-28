using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class MonHocBLL
    {
        private static MonHocBLL _instance;

        public static MonHocBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MonHocBLL();
                return _instance;
            }
        }

        private MonHocBLL() { }

        public List<MonHocDTO> GetAllMonHoc()
        {
            return MonHocDAL.Instance.GetAllMonHoc();
        }

        public bool InsertMonHoc(MonHocDTO mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMonHoc))
                throw new Exception("Mã môn học không được để trống");
            if (string.IsNullOrWhiteSpace(mh.TenMonHoc))
                throw new Exception("Tên môn học không được để trống");

            if (MonHocDAL.Instance.CheckMaMonHocExists(mh.MaMonHoc))
                throw new Exception("Mã môn học đã tồn tại");

            return MonHocDAL.Instance.InsertMonHoc(mh);
        }

        public bool UpdateMonHoc(MonHocDTO mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMonHoc))
                throw new Exception("Mã môn học không được để trống");

            return MonHocDAL.Instance.UpdateMonHoc(mh);
        }

        public bool DeleteMonHoc(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                throw new Exception("Mã môn học không được để trống");

            return MonHocDAL.Instance.DeleteMonHoc(maMonHoc);
        }
    }
}
