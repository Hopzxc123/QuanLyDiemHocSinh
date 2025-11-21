using System.Data;

namespace DAL.Reports
{
    public class KQHSCaNamDAL
    {
        private static KQHSCaNamDAL _instance;
        private KQHSCaNamDAL() { }
        public static KQHSCaNamDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KQHSCaNamDAL();
                }
                return _instance;
            }
            private set => _instance = value;
        }
        public DataTable Report(string maNamHoc, string maLop)
        {
            string query = $"EXEC ReportKQHSCaNam {maNamHoc}, {maLop}";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                maNamHoc,
                maLop
            });
        }
    }
}
