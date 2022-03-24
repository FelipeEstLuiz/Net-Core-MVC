using Dapper;
using Documentos.Domain.Entities;
using Documentos.Domain.Interfaces;
using Documentos.Infra.Data.Context;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Documentos.Infra.Data.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly IDbConnection _connection;

        public DocumentoRepository(IDbConnectionDocumento conexao)
        {
            _connection = conexao.DbConnection;
        }

        public async Task<Documento> CreateAsync(Documento documento)
        {
            string sql = @"
                INSERT INTO documentos (Codigo,Titulo,Revisao,DataPlanejada,Valor) 
                VALUES(@Codigo,@Titulo,@Revisao,@DataPlanejada,@Valor);
            ";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            await _connection.ExecuteAsync(sql, new
            {
                Titulo = documento.Titulo,
                Revisao = documento.Revisao,
                DataPlanejada = documento.DataPlanejada,
                Valor = documento.Valor,
                Codigo = documento.Codigo
            });

            return documento;
        }

        public async Task<Documento> DeleteAsync(Documento documento)
        {
            string sql = @"DELETE FROM documentos WHERE Codigo = @Codigo";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            await _connection.ExecuteAsync(sql, new
            {
                Codigo = documento.Codigo
            });

            return documento;
        }

        public async Task<IEnumerable<Documento>> GetAllAsync()
        {
            string sql = @"
                SELECT
                    Codigo, Titulo, Revisao, DataPlanejada, Valor
                FROM documentos
            ";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            return await _connection.QueryAsync<Documento>(sql);
        }

        public async Task<Documento> GetByIdAsync(string codigo)
        {
            string sql = @"
                SELECT
                    Codigo, Titulo, Revisao, DataPlanejada, Valor
                FROM documentos
                WHERE Codigo = @Codigo
            ";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            return await _connection.QueryFirstOrDefaultAsync<Documento>(sql, new
            {
                Codigo = codigo
            });
        }

        public async Task<Documento> UpdateAsync(Documento documento)
        {
            string sql = @"
                UPDATE documentos SET
                    Titulo = @Titulo, 
                    Revisao = @Revisao, 
                    DataPlanejada = @DataPlanejada, 
                    Valor = @Valor
                WHERE Codigo = @Codigo
            ";

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            await _connection.ExecuteAsync(sql, new
            {
                Titulo = documento.Titulo,
                Revisao = documento.Revisao,
                DataPlanejada = documento.DataPlanejada,
                Valor = documento.Valor,
                Codigo = documento.Codigo
            });

            return documento;
        }
    }
}
