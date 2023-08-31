using System.Data;

namespace MasterEstoqueAPI.Domain.Infra
{
    public interface IDbContext
    {
        void Dispose();
        IDbConnection GetConnection();
    }
}