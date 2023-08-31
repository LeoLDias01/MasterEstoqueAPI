using MasterEstoqueAPI.Domain.Infra;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEstoqueAPI.Data.Infra
{
    public class DbContext : IDisposable, IDbContext
    {
        public IDbConnection Connection { get; }

        public DbContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("Testes"));
            Connection.Open();
        }
        public IDbConnection GetConnection()
        {
            return Connection;
        }
        public void Dispose() => Connection?.Close();
    }
}
