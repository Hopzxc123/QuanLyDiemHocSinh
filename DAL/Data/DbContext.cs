using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemTruongCap3.DAL.Data
{
    public class DbContext : IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlConnection Connection => _connection;
        public DbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
