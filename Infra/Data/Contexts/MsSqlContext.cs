using System.Data;
using System.Data.SqlClient;

namespace CustaProject.Infra.Data.Contexts
{
    public class MsSqlContext : IDbContext
    {
        public string ConnectionString { get;}

        public MsSqlContext(string connectionString) => ConnectionString = connectionString;

        public IDbConnection GetConnection() => new SqlConnection(ConnectionString);
    }
}
