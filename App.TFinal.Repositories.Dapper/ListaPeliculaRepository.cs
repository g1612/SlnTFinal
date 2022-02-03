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
  public  class ListaPeliculaRepository : Repository<Pelicula>, IListaPeliculaRepository
    {

        public ListaPeliculaRepository(string connectionString) : base(connectionString)
        {


        }

        public async Task<IEnumerable<Pelicula>> Listar2(string titulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                return await connection.QueryAsync<Pelicula>("uspListarPeliculas", commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}