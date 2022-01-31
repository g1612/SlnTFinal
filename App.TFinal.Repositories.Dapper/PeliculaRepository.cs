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
    
   public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    {

        public PeliculaRepository(string connectionString) : base(connectionString)
        {


        }

        public Pelicula BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Pelicula>().Where(c => c.Id.Equals(id)).First();
            }
        }


        public async Task<IEnumerable<Pelicula>> Listar(string titulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Titulo", titulo);
                return await connection.QueryAsync<Pelicula>("select Id , IdGenero, IdEstadoPelicula, Titulo , Duracion , Sipnosis ,Estado from dbo.Pelicula " +
                                                        "where Titulo like '%@Titulo%'", parameters,
                                                        commandType: System.Data.CommandType.Text);
            }
        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update dbo.Pelicula " +
                                                "set Estado = 0 " +
                                                "where Id = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
      

        public async Task<MensajeRetorno> CrearPelicula(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@IdGenero", pelicula.IdGenero);
                parameters.Add("@IdEstadoPelicula", pelicula.IdEstadoPelicula);
                parameters.Add("@Titulo", pelicula.Titulo);
                parameters.Add("@Duracion", pelicula.Duracion);
                parameters.Add("@Sipnosis", pelicula.Sipnosis);
                parameters.Add("@Estado", pelicula.Estado);
    
                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var peliculaCreada = await connection.QueryFirstOrDefaultAsync<Pelicula>("dbo.uspCrearPelicula",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = peliculaCreada, Mensaje = message };
            }
        }


        public async Task<IEnumerable<Pelicula>> ListarPeliculas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
             

                return await connection.QueryAsync<Pelicula>("uspListarPeliculas", commandType: System.Data.CommandType.StoredProcedure );

            }
        }


    }
}
