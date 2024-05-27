using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco.SqlServer;
using NPoco;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class DbFactory : IDbFactory
    {
        private readonly string _connectionString;

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDatabase GetConnection()
        {
            return new Database(_connectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
        }
    }
}
