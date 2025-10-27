using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class DiemBLL
    {
        private static DiemBLL _instance;

        public static DiemBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DiemBLL();
                return _instance;
            }
        }

        private DiemBLL() { }

        public List<DiemDTO> GetAllDiem()
        {
            return DiemDAL.Instance.GetAllDiem();
        }

        public bool InsertDiem(DiemDTO diem)
        {
            if (string.IsNullOrWhiteSpace(diem.MaHS))
                throw new Exception("Mã học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(diem.MaMonHoc))
                throw new Exception("Mã môn học không được để trống");
            if (string.IsNullOrWhiteSpace(diem.MaHocKy))
                throw new Exception("Mã học kỳ không được để trống");

            ValidateDiem(diem);

            if (string.IsNullOrEmpty(diem.MaDiem))
                diem.MaDiem = TaoMaDiemTuDong();

            return DiemDAL.Instance.InsertDiem(diem);
        }

        public bool UpdateDiem(DiemDTO diem)
        {
            if (string.IsNullOrWhiteSpace(diem.MaDiem))
                throw new Exception("Mã điểm không được để trống");

            ValidateDiem(diem);
            return DiemDAL.Instance.UpdateDiem(diem);
        }

        public bool DeleteDiem(string maDiem)
        {
            if (string.IsNullOrWhiteSpace(maDiem))
                throw new Exception("Mã điểm không được để trống");

            return DiemDAL.Instance.DeleteDiem(maDiem);
        }

        private void ValidateDiem(DiemDTO diem)
        {
            if (!KiemTraDiemHopLe(diem.DiemTrenLop ?? 0) ||
                !KiemTraDiemHopLe(diem.DiemGiuaKy ?? 0) ||
                !KiemTraDiemHopLe(diem.DiemThi ?? 0))
                throw new Exception("Điểm phải nằm trong khoảng 0-10");
        }

        private bool KiemTraDiemHopLe(float diem)
        {
            return diem >= 0 && diem <= 10;
        }

        private string TaoMaDiemTuDong()
        {
            List<DiemDTO> list = DiemDAL.Instance.GetAllDiem();
            int max = 0;
            foreach (var d in list)
            {
                if (d.MaDiem.StartsWith("D"))
                {
                    string numPart = d.MaDiem.Substring(1);
                    if (int.TryParse(numPart, out int so) && so > max)
                        max = so;
                }
            }
            return $"D{(max + 1).ToString("D3")}";
        }
    }
}
