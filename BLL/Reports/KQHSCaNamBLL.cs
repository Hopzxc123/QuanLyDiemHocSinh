using DAL.Reports;
using System.Data;

namespace BLL.Reports
{
    public class KQHSCaNamBLL
    {
        private static KQHSCaNamBLL _instance;
        private KQHSCaNamBLL() { }
        public static KQHSCaNamBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KQHSCaNamBLL();
                }
                return _instance;
            }
            private set => _instance = value;
        }

        public DataTable Report(string maNamHoc, string maLop)
        {
            return KQHSCaNamDAL.Instance.Report(maNamHoc, maLop);
        }
    }
}
