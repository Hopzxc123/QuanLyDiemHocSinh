using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

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
        public List<DiemDTO> GetDiemByHocSinhHocKy(string maHocSinh, string maHocKy)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
                throw new Exception("Mã học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(maHocKy))
                throw new Exception("Mã học kỳ không được để trống");
            return DiemDAL.Instance.GetDiemByHocSinhHocKy(maHocSinh, maHocKy);
        }
        public List<DiemDTO> GetDiemByHocSinhNamHoc(string maHocSinh, string maNamHoc)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
                throw new Exception("Mã học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(maNamHoc))
                throw new Exception("Mã học kỳ không được để trống");
            List<DiemDTO> diems = new List<DiemDTO>();
            List<HocKyDTO> hocKys = HocKyBLL.Instance.GetHocKyByNamHoc(maNamHoc);
            foreach(HocKyDTO hocKy in hocKys)
            {
                diems.AddRange(DiemDAL.Instance.GetDiemByHocSinhHocKy(maHocSinh, hocKy.MaHocKy));
            }
            return diems;
            
        }
        public List<DiemDTO> GetDiemByHocSinh(string maHocSinh)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
                throw new Exception("Mã học sinh không được để trống");
            return DiemDAL.Instance.GetDiemByHocSinh(maHocSinh);
        }
        public DiemDTO GetDiemByHocSinhMonHoc(string maHocSinh, string maMonHoc, string maHocKy)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
                throw new Exception("Mã học sinh không được để trống");
            if (string.IsNullOrWhiteSpace(maMonHoc))
                throw new Exception("Mã môn học không được để trống");
            if (string.IsNullOrWhiteSpace(maHocKy))
                throw new Exception("Mã học kỳ không được để trống");
            return DiemDAL.Instance.GetDiemByHocSinhMonHoc(maHocSinh, maMonHoc, maHocKy);
        }

        public bool InsertDiem(DiemDTO diem)
        {
            if (string.IsNullOrWhiteSpace(diem.MaHocSinh))
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
        public float getDiemTongKet(string maHocSinh, string maHocKy)
        {
            return DiemDAL.Instance.getDiemTongKet(maHocSinh, maHocKy);
        }
        public int LaySoLuongDat(string maLop, string maNamHoc, string maHocKy)
        {
            DataTable dataTable = HocSinhDAL.Instance.LayDanhSachHocSinh(maNamHoc, maLop);
            int diemDat = 5;
            int soLuongDat = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                float diemTBHK = LayDiemTBHKChung(row["MaHocSinh"].ToString(), maLop, maNamHoc, maHocKy);
                soLuongDat += Convert.ToInt32(diemTBHK >= diemDat);
            }
            return soLuongDat;
        }
        public float LayDiemTBHKChung(string maHocSinh, string maLop, string maNamHoc, string maHocKy)
        {
            DataTable dataTable = MonHocDAL.Instance.LayDanhSachMonHoc(maNamHoc, maLop);
            float tongDiemCacMon = 0;
            int tongHeSoCacMon = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                float diemTBTungMon = LayDiemTBHKTheoMon(maHocSinh, maLop, maNamHoc, row["MaMonHoc"].ToString(), maHocKy);
                int heSo = Convert.ToInt32(row["HeSo"].ToString());
                tongDiemCacMon += diemTBTungMon * heSo;
                tongHeSoCacMon += heSo;
            }

            if (tongHeSoCacMon <= 0) return 0;
            return (float)Math.Round(tongDiemCacMon / tongHeSoCacMon, 2);
        }
        public float LayDiemTBHKTheoMon(string maHocSinh, string maLop, string maNamHoc, string maMonHoc, string maHocKy)
        {
            DataTable dataTable = DiemDAL.Instance.LayDanhSachDiemHocSinh(maHocSinh, maMonHoc, maHocKy, maNamHoc, maLop);
            float tongDiem = 0;
            int tongHeSo = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                float diem = Convert.ToSingle(row["Diem"].ToString());
                int heSo = Convert.ToInt32(row["HeSo"].ToString());
                tongDiem += diem * heSo;
                tongHeSo += heSo;
            }

            if (tongHeSo <= 0) return 0;
            return (float)Math.Round(tongDiem / tongHeSo, 2);
        }


    }
}
