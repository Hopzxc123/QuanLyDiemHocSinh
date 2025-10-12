using QLDiemTruongCap3.DAL.Data;
using QLDiemTruongCap3.DAL.Entities;
using QLDiemTruongCap3.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemTruongCap3.DAL.Repository
{
    public class RepositoryHocSinh : Repository<HocSinh>, IRepositoryHocSinh
    {
        private readonly SqlConnection _db;
        public RepositoryHocSinh(DbContext _db) : base(_db)
        {
        }
    }
}
