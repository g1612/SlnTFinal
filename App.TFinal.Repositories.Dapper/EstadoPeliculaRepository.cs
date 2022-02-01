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
   public class EstadoPeliculaRepository : Repository<EstadoPelicula>, IEstadoPeliculaRepository
    {

        public EstadoPeliculaRepository(string connectionString) : base(connectionString)
        {
        }

        public EstadoPelicula BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<EstadoPelicula>().Where(c => c.Id.Equals(id)).First();
            }
        }
        public async Task<IEnumerable<EstadoPelicula>> Listar(string nombres)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombres", nombres);
                return await connection.QueryAsync<EstadoPelicula>("select Id, Descripcion,Estado from dbo.EstadoPelicula " +
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
                return await connection.ExecuteAsync("update dbo.EstadoPelicula " +
                                                "set Estado = 0 " +
                                                "where Id = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }


    }
}

