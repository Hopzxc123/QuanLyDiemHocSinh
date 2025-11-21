using DAL;

using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportBLL
    {
        private static ReportBLL _instance;

        public static ReportBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReportBLL();
                return _instance;
            }
        }

        private ReportBLL() { }
        public List<frmBaoCaoTKMHDTO> ReportTongKetMon(string maHocKy, string maMonHoc)
        {
            return ReportDAL.Instance.ReportTongKetMon(maHocKy, maMonHoc);
        }

        public List<ReportMonHocDTO> ReportMonHoc()
        {
            return ReportDAL.Instance.ReportMonHoc();
        }
        public DataTable ReportKQHSCaNam(string maNamHoc, string maLop)
        {
            return ReportDAL.Instance.ReportKQHSCaNam(maNamHoc, maLop);
        }
        public DataTable GetBaoCaoHocKy(string maNamHoc, string maHocKy)
        {
            return ReportDAL.Instance.GetBaoCaoHocKy(maNamHoc, maHocKy);
        }
    }
}
