using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using EagleEye.Core.Interfaces;
using NPoco;

namespace EagleEye.Infrastructure.Repositories
{
  public  class DbFactory : IDbFactory
  {

      private readonly string _connectionString;
        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;

        }
        public IDatabase GetConnection()
        {
           return new Database(_connectionString,DatabaseType.SqlServer2012, SqlClientFactory.Instance);
        }
    }
}
