using DAL;
using DTO;
using System;
using System.Collections.Generic;
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
    }
}
