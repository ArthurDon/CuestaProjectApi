using System.Data;

namespace CustaProject.Infra.Data.Contexts
{
    public interface IDbContext
    {
        public string ConnectionString { get; }

        IDbConnection GetConnection();
    }
}
