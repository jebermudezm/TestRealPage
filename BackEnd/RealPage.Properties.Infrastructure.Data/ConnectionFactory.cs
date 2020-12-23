using System;
using RealPage.Properties.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RealPage.Properties.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("PropertyConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }

        public string GetConnectionString
        {
            get
            {
                
                var connectionString = _configuration.GetConnectionString("PropertyConnection");
                return connectionString;
            }
        }
    }
}
