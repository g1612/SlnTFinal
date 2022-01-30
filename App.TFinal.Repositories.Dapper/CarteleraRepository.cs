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

    //   public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    public class CarteleraRepository : Repository<Cartelera>, ICarteleraRepository
    {

        public CarteleraRepository(string connectionString) : base(connectionString)
        {


        }

        public Cartelera BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Cartelera>().Where(c => c.Id.Equals(id)).First();
            }
        }


        public async Task<IEnumerable<Cartelera>> Listar(string titulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Titulo", titulo);
                return await connection.QueryAsync<Cartelera>("select Id , IdGenero, IdEstadoPelicula, Titulo , Duracion , Sipnosis ,Estado from dbo.Pelicula " +
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
                return await connection.ExecuteAsync("update dbo.Cartelera " +
                                                "set Estado = 0 " +
                                                "where Id = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }


        public async Task<MensajeRetorno> CrearCartelera(Cartelera cartelera)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@IdPelicula", cartelera.IdPelicula);
                parameters.Add("@IdSala", cartelera.IdSala);
                parameters.Add("@FechaInicio", cartelera.FechaInicio);
                parameters.Add("@FechaFin", cartelera.FechaFin);
                parameters.Add("@HorarioInicio", cartelera.HorarioInicio);
                parameters.Add("@HorarioFin", cartelera.HorarioFin);
                parameters.Add("@Precio", cartelera.Precio);
                parameters.Add("@Estado", cartelera.Estado);

                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var carteleraCreada = await connection.QueryFirstOrDefaultAsync<Cartelera>("dbo.uspCrearCartelera",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = carteleraCreada, Mensaje = message };
            }
        }


    }



}
