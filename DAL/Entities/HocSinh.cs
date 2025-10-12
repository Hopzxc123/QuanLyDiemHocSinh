using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemTruongCap3.DAL.Entities
{
    [Table("HocSinh")]
    public class HocSinh
    {
        [Key]
        public int Id { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
    }
}
