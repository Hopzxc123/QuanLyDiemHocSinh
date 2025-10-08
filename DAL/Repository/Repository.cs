using Dapper;
using Dapper.Contrib.Extensions;
using QLDiemTruongCap3.DAL.Data;
using QLDiemTruongCap3.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemTruongCap3.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(DbContext _db)
        {
            _connection = _db.Connection;
        }
        public IEnumerable<T> GetAll()
        {
            //ADO.net thuan

            //IQueryable<T> list = new List<T>().AsQueryable();
            //string sql = $"SELECT * FROM {typeof(T).Name}";
            //using (SqlCommand command = new SqlCommand(sql, _connection))
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        // Mapping data from reader to object of type T
            //        // This requires reflection or a mapping library like Dapper/AutoMapper
            //        // For simplicity, this part is omitted
            //    }
            //}
            //return list;

            //Dapper
            //string sql = $"SELECT * FROM {typeof(T).Name}";
            //return _connection.Query<T>(sql);
            //Dapper.Contrib
            return _connection.GetAll<T>();
        }

        public T GetById(object id)
        {
            //string sql = $"select * from {typeof(T).Name} where Id = @Id";
            //return _connection.QueryFirstOrDefault<T>(sql, new { Id = id });
            return _connection.Get<T>(id);
        }
    
        public bool Insert(T obj)
        {
            //string sql = $"insert into {typeof(T).Name} values ({@obj})";
            //return _connection.Execute(sql, new { obj }) > 0;
            return _connection.Insert<T>(obj) > 0;
        }

        public bool Update(T obj)
        {
            //string sql = $"update {typeof(T).Name} set @obj where Id = @Id";
            //return _connection.Execute(sql, new { obj }) > 0;
            return _connection.Update<T>(obj);
        }

    }

}
