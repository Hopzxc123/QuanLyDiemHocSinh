using DAL.Reports;
using System.Data;

namespace BLL.Reports
{
    public class KQLHHocKyBLL
    {
                                                                      
            private static KQLHHocKyBLL _instance;
            public static KQLHHocKyBLL Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new KQLHHocKyBLL();
                    return _instance;
                }
            }

            public DataTable GetBaoCaoHocKy(string maNamHoc, string maHocKy)
            {
                return KQLHHocKyDAL.Instance.GetBaoCaoHocKy(maNamHoc, maHocKy);
            }
        
    }
}
