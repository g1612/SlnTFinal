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
  public  class ListaPeliculaRepository :  Repository<ListaPelicula>, IListaPeliculaRepository
    {

        public ListaPeliculaRepository(string connectionString) : base(connectionString)
        {


        }

        public async Task<IEnumerable<ListaPelicula>> BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
           var parameters = new DynamicParameters();
                parameters.Add("@Titulo", id);
                return await connection.QueryAsync<ListaPelicula>("select Id , IdGenero, IdEstadoPelicula, Titulo , Duracion , Sipnosis ,Estado from dbo.Pelicula " +
                                                        "where Id = @Titulo", parameters,
                                                        commandType: System.Data.CommandType.Text);
          

            }
        }
        public async Task<IEnumerable<ListaPelicula>> buscar()
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                return await connection.QueryAsync<ListaPelicula>("uspListarPeliculas", commandType: System.Data.CommandType.StoredProcedure);

            }
        }


        public async Task<IEnumerable<ListaPelicula>> ListarPeliculas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                return await connection.QueryAsync<ListaPelicula>("uspListarPeliculas", commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<ListaPelicula>> ListaCartelera(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@fini", DateTime.Today);
                parameters.Add("@ffin", DateTime.Today);
                //                return await connection.QueryAsync<ListaPelicula>("SELECT B.TITULO,C.Descripcion,A.HORARIOINICIO,A.PRECIO FROM CARTELERA A INNER JOIN PELICULA B ON A.IDPELICULA=B.ID INNER JOIN "+ 
                //" SALA C ON A.IdSala = C.ID WHERE A.IdPelicula = '@Titulo' AND FECHAINICIO <= '05/02/2022' AND FechaFin >= '05/02/2022' ", parameters,
                //                                                        commandType: System.Data.CommandType.Text);
                return await connection.QueryAsync<ListaPelicula>("ListaCartelera", parameters, commandType: System.Data.CommandType.StoredProcedure);


            }
        }

    }
}