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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(string connectionString) : base(connectionString)
        {
        }

        public Usuario BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Usuario>().Where(c => c.Id.Equals(id)).First();
            }
        }
        public async Task<IEnumerable<Usuario>> Listar(string nombres)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombres", nombres);
                return await connection.QueryAsync<Usuario>("select Id, Nombres, Estado from dbo.usuario " +
                                                        "where Nombres like '%@nombres%'", parameters,
                                                        commandType: System.Data.CommandType.Text);
            }
        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update dbo.Usuario " +
                                                "set Estado = 0 " +
                                                "where Id = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
        public async Task<Usuario> ValidarUsuario(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                var user = await connection.QueryFirstOrDefaultAsync<Usuario>("dbo.uspValidarUsuario",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task<MensajeRetorno> CrearUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@Nombres", usuario.Nombres);
                parameters.Add("@Apellidos", usuario.Apellidos);
                parameters.Add("@Telefono", usuario.Telefono);
                parameters.Add("@Direccion", usuario.Direccion);
                parameters.Add("@Sexo", usuario.Sexo);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@IdRol", usuario.IdRol);
                parameters.Add("@IdDocumento", usuario.IdDocumento);
                parameters.Add("@NumeroDocumento", usuario.NumeroDocumento);
                parameters.Add("@Login", usuario.Login);
                parameters.Add("@Password", usuario.Password);
                parameters.Add("@Estado", usuario.Estado);
                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var usuarioCreado = await connection.QueryFirstOrDefaultAsync<Usuario>("dbo.uspCrearUsuario",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = usuarioCreado, Mensaje = message };
            }
        }

    }

}
