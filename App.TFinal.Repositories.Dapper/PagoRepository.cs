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
    public class PagoRepository : Repository<Pago>, IPagoRepository
    {


        public PagoRepository(string connectionString) : base(connectionString)
        {


        }

        public Pago BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Pago>().Where(c => c.Id.Equals(id)).First();
            }
        }


        public async Task<IEnumerable<Pago>> Listar(string titulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Titulo", titulo);
                return await connection.QueryAsync<Pago>("select Id , IdGenero, IdEstadoPelicula, Titulo , Duracion , Sipnosis ,Estado from dbo.Pelicula " +
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


        public async Task<MensajeRetorno> RegistrarPago(Pago pago)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@IdUsuario", pago.IdUsuario);
                parameters.Add("@IdCartelera", pago.IdCartelera);
                parameters.Add("@Cantidad", pago.Cantidad);
                parameters.Add("@Total", pago.Total);
         
                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var pagoRegistrado = await connection.QueryFirstOrDefaultAsync<Pago>("dbo.uspRegistrarPago",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = pagoRegistrado, Mensaje = message };
            }
        }


        public async Task<IEnumerable<Pago>> ListaPagos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                return await connection.QueryAsync<Pago>("uspListaPagos", commandType: System.Data.CommandType.StoredProcedure);

            }
        }


    }


}
