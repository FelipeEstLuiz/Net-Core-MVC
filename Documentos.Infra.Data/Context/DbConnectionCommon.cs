using System.Data;

namespace Documentos.Infra.Data.Context
{
    public interface IDbConnectionDocumento
    {
        IDbConnection DbConnection { get; }
    }

    public class DbConnectionCommon: IDbConnectionDocumento
    {
        private readonly IDbConnection connection;

        public DbConnectionCommon(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IDbConnection DbConnection => connection;

        public void Dispose() => connection?.Dispose();
    }
}
