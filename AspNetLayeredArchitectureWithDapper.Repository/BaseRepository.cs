using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace AspNetLayeredArchitectureWithDapper.Repository
{
    public class BaseRepository : IDisposable
    {
        private IConfiguration _configuration;
        private readonly string _connectionString;

        private IDbConnection _connection;
        public IDbConnection GetConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new OracleConnection(_connectionString);
                }
                return _connection;
            }
        }
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:OracleDBConnection"];
        }
        public void Dispose()
        {
            if (GetConnection.State == ConnectionState.Open)
            {
                GetConnection.Close();
            }
        }
    }
}
