using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LopBLL
    {
        private LopDAL dal = new LopDAL();

        public List<LopDTO> GetAll() => dal.GetAll();
        public bool Insert(LopDTO dto) => dal.Insert(dto);
        public bool Update(LopDTO dto) => dal.Update(dto);
        public bool Delete(int id) => dal.Delete(id);
    }
}
