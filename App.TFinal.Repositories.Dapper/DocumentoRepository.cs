using App.TFinal.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.TFinal.Repositories.Dapper
{
  public  class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {

        public DocumentoRepository(string connectionString) : base(connectionString)
        {
        }

        public Documento BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Documento>().Where(c => c.Id.Equals(id)).First();
            }
        }
        public async Task<IEnumerable<Documento>> Listar(string nombres)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombres", nombres);
                return await connection.QueryAsync<Documento>("select Id, CDocumento, Descripcion,Estado from dbo.Documento " +
                                                        "where Descripcion like '%@nombres%'", parameters,
                                                        commandType: System.Data.CommandType.Text);
            }
        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update dbo.Documento " +
                                                "set Estado = 0 " +
                                                "where Id = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }


    }
}

