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
  public  class ListaPeliculaRepository : Repository<ListaPelicula>, IListaPeliculaRepository
    {

        public ListaPeliculaRepository(string connectionString) : base(connectionString)
        {


        }

        public async Task<IEnumerable<ListaPelicula>> ListarPeliculas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                return await connection.QueryAsync<ListaPelicula>("uspListarPeliculas", commandType: System.Data.CommandType.StoredProcedure);

            }
        }

      
    }
}