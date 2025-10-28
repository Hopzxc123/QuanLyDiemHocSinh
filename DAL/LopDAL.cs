using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LopDAL
    {
        public List<LopDTO> GetAll()
        {
            List<LopDTO> list = new List<LopDTO>();
            string query = "SELECT * FROM Lop";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                LopDTO lop = new LopDTO
                {
                    MaLop = Convert.ToInt32(row["MaLop"]),
                    TenLop = row["TenLop"].ToString(),
                    KhoiLop = Convert.ToInt32(row["KhoiLop"]),
                    SiSo = Convert.ToInt32(row["SiSo"]),
                    NamHoc = Convert.ToInt32(row["NamHoc"]),
                    GhiChu = row["GhiChu"].ToString()
                };
                list.Add(lop);
            }
            return list;
        }

        public bool Insert(LopDTO lop)
        {
            string query = $"INSERT INTO Lop(TenLop, KhoiLop, SiSo, NamHoc,GhiChu)" +
                $" VALUES(N'{lop.TenLop}', {lop.KhoiLop}, {lop.SiSo}, {lop.NamHoc}, N'{lop.GhiChu}')";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool Update(LopDTO lop)
        {
            string query = $"UPDATE Lop SET TenLop = N'{lop.TenLop}'," +
                $" KhoiLop = {lop.KhoiLop}, SiSo = {lop.SiSo}, NamHoc = {lop.NamHoc}, GhiChu = N'{lop.GhiChu}'" +
                $"WHERE MaLop = {lop.MaLop}";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool Delete(int id)
        {
            string query = $"DELETE FROM Lop WHERE MaLop = {id}";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
