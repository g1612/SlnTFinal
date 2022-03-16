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
    public class BDGXXXXENTI1Repository : Repository<BDGXXXXENTI1>, IBDGXXXXENTI1Repository
    {

        public BDGXXXXENTI1Repository(string connectionString) : base(connectionString)
        {


        }
        public async Task<BDGXXXXENTI1> ObtenerXY(string id)
        {
            return null;
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    var parameters = new DynamicParameters();
            //    parameters.Add("@Titulo", titulo);
            //    return await connection.QueryAsync<BDGXXXXENTI1>("select * from dbo.bdg0002enti1 " +
            //                                            "where e1_desent like '%@Titulo%'", parameters,
            //                                            commandType: System.Data.CommandType.Text);
            //}
        }
        
            public async Task<BDGXXXXENTI1> BuscarPorId(BDGXXXXENTI1 bdgXXXXenti1, string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               

                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@tabla", "0002");
                parameters.Add("@id", id);
                var carteleraCreada =await connection.QueryFirstOrDefaultAsync<BDGXXXXENTI1>("uspListareNTIDAD", parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = "0-OK";

                //return usuarioCreado;
                return carteleraCreada;// new MensajeRetorno { Objeto = carteleraCreada, Mensaje = message };

                // return await connection.QueryAsync<PCGR>("usp_con_filtrar_pcgr", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

       


        public async Task<IEnumerable<BDGXXXXENTI1>> Listar(string titulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Titulo", titulo);
                return await connection.QueryAsync<BDGXXXXENTI1>("select * from dbo.bdg0002enti1 " +
                                                        "where e1_desent like '%@Titulo%'", parameters,
                                                        commandType: System.Data.CommandType.Text);
            }
        }
        public async Task<int> Eliminar(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("delete dbo.bdg0002enti1 " +
                                                                                               "where e1_codent = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }


        public async Task<MensajeRetorno> CrearBDGXXXXENTI1(BDGXXXXENTI1 bdgXXXXenti1)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_DESENT)) bdgXXXXenti1.E1_DESENT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_APEPAT)) bdgXXXXenti1.E1_APEPAT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_APEMAT)) bdgXXXXenti1.E1_APEMAT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NOMBRE1)) bdgXXXXenti1.E1_NOMBRE1 = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NOMBRE2)) bdgXXXXenti1.E1_NOMBRE2 = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ORIG)) bdgXXXXenti1.E1_ORIG = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPPER)) bdgXXXXenti1.E1_TIPPER = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPDOC)) bdgXXXXenti1.E1_TIPDOC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODDOC)) bdgXXXXenti1.E1_CODDOC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODGRUP)) bdgXXXXenti1.E1_CODGRUP = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_AGEN)) bdgXXXXenti1.E1_AGEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_USCOD)) bdgXXXXenti1.E1_USCOD = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ESTADO)) bdgXXXXenti1.E1_ESTADO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPCONT)) bdgXXXXenti1.E1_TIPCONT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TASA)) bdgXXXXenti1.E1_TASA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODDET)) bdgXXXXenti1.E1_CODDET = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODPER)) bdgXXXXenti1.E1_CODPER = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ZONA)) bdgXXXXenti1.E1_ZONA = "";

                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CLASCLI)) bdgXXXXenti1.E1_CLASCLI = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PAGWEB)) bdgXXXXenti1.E1_PAGWEB = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_MAIL)) bdgXXXXenti1.E1_MAIL = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CONTACTO)) bdgXXXXenti1.E1_CONTACTO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TELEFONO)) bdgXXXXenti1.E1_TELEFONO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODVEN)) bdgXXXXenti1.E1_CODVEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CONDVTA)) bdgXXXXenti1.E1_CONDVTA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PEN)) bdgXXXXenti1.E1_PEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TASDSCTO)) bdgXXXXenti1.E1_TASDSCTO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CTIPA)) bdgXXXXenti1.E1_CTIPA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NUMAC)) bdgXXXXenti1.E1_NUMAC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PORT)) bdgXXXXenti1.E1_PORT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ESTOP)) bdgXXXXenti1.E1_ESTOP = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_COVEDT)) bdgXXXXenti1.E1_COVEDT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_DIAVIS)) bdgXXXXenti1.E1_DIAVIS = "";

                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@tabla", "0002");
                parameters.Add("@codent", bdgXXXXenti1.E1_CODENT);
                parameters.Add("@tipo", bdgXXXXenti1.E1_TIPO);
                parameters.Add("@desent", bdgXXXXenti1.E1_DESENT);
                parameters.Add("@appat", bdgXXXXenti1.E1_APEPAT);
                parameters.Add("@apmat", bdgXXXXenti1.E1_APEMAT);
                parameters.Add("@nomb", bdgXXXXenti1.E1_NOMBRE1);
                parameters.Add("@nomb2", bdgXXXXenti1.E1_NOMBRE2);
                parameters.Add("@origen", bdgXXXXenti1.E1_ORIG);
                parameters.Add("@tiper", bdgXXXXenti1.E1_TIPPER);
                parameters.Add("@tipdoc", bdgXXXXenti1.E1_TIPDOC);
                parameters.Add("@coddoc", bdgXXXXenti1.E1_CODDOC);
                parameters.Add("@codgrup", bdgXXXXenti1.E1_CODGRUP);
                parameters.Add("@agen", bdgXXXXenti1.E1_AGEN);

                parameters.Add("@uscod", bdgXXXXenti1.E1_USCOD);
                parameters.Add("@estado", bdgXXXXenti1.E1_ESTADO);
                parameters.Add("@tipcont", bdgXXXXenti1.E1_TIPCONT);
                parameters.Add("@tasa", bdgXXXXenti1.E1_TASA);
                parameters.Add("@det", bdgXXXXenti1.E1_CODDET);
                parameters.Add("@per", bdgXXXXenti1.E1_CODPER);
                parameters.Add("@zona", bdgXXXXenti1.E1_ZONA);
                parameters.Add("@CLASCLI", bdgXXXXenti1.E1_CLASCLI);
                parameters.Add("@PAGWEB", bdgXXXXenti1.E1_PAGWEB);
                parameters.Add("@mail", bdgXXXXenti1.E1_MAIL);
                parameters.Add("@contacto", bdgXXXXenti1.E1_CONTACTO);
                parameters.Add("@telefono", bdgXXXXenti1.E1_TELEFONO);

                parameters.Add("@codven", bdgXXXXenti1.E1_CODVEN);
                parameters.Add("@codVTA", bdgXXXXenti1.E1_CONDVTA);
                parameters.Add("@codpen", bdgXXXXenti1.E1_PEN);
                parameters.Add("@tdes", bdgXXXXenti1.E1_TASDSCTO);
                parameters.Add("@codtip", bdgXXXXenti1.E1_CTIPA);
                parameters.Add("@numacc", bdgXXXXenti1.E1_NUMAC);
                parameters.Add("@porc", bdgXXXXenti1.E1_PORT);
                parameters.Add("@estop", bdgXXXXenti1.E1_ESTOP);
                parameters.Add("@COVEDT", bdgXXXXenti1.E1_COVEDT);
                parameters.Add("@E1_DIAVIS", bdgXXXXenti1.E1_DIAVIS);

               // return await connection.QueryAsync<Pago>("USP_CON_Guardarentidad", parameters, commandType: System.Data.CommandType.StoredProcedure);

                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var carteleraCreada = await connection.QueryFirstOrDefaultAsync<BDGXXXXENTI1>("dbo.USP_CON_Guardarentidad",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = carteleraCreada, Mensaje = message };
            }
        }



        public async Task<IEnumerable<BDGXXXXENTI1>> ListarBDGXXXXENTI1(string tab,string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@tabla", tab);
                parameters.Add("@id", id);
                return await connection.QueryAsync<BDGXXXXENTI1>("uspListareNTIDAD", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public async Task<MensajeRetorno> ModificarBDGXXXXENTI1(BDGXXXXENTI1 bdgXXXXenti1)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_DESENT)) bdgXXXXenti1.E1_DESENT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_APEPAT)) bdgXXXXenti1.E1_APEPAT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_APEMAT)) bdgXXXXenti1.E1_APEMAT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NOMBRE1)) bdgXXXXenti1.E1_NOMBRE1 = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NOMBRE2)) bdgXXXXenti1.E1_NOMBRE2 = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ORIG)) bdgXXXXenti1.E1_ORIG = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPPER)) bdgXXXXenti1.E1_TIPPER = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPDOC)) bdgXXXXenti1.E1_TIPDOC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODDOC)) bdgXXXXenti1.E1_CODDOC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODGRUP)) bdgXXXXenti1.E1_CODGRUP = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_AGEN)) bdgXXXXenti1.E1_AGEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_USCOD)) bdgXXXXenti1.E1_USCOD = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ESTADO)) bdgXXXXenti1.E1_ESTADO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TIPCONT)) bdgXXXXenti1.E1_TIPCONT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TASA)) bdgXXXXenti1.E1_TASA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODDET)) bdgXXXXenti1.E1_CODDET = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODPER)) bdgXXXXenti1.E1_CODPER = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ZONA)) bdgXXXXenti1.E1_ZONA = "";

                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CLASCLI)) bdgXXXXenti1.E1_CLASCLI = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PAGWEB)) bdgXXXXenti1.E1_PAGWEB = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_MAIL)) bdgXXXXenti1.E1_MAIL = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CONTACTO)) bdgXXXXenti1.E1_CONTACTO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TELEFONO)) bdgXXXXenti1.E1_TELEFONO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CODVEN)) bdgXXXXenti1.E1_CODVEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CONDVTA)) bdgXXXXenti1.E1_CONDVTA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PEN)) bdgXXXXenti1.E1_PEN = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_TASDSCTO)) bdgXXXXenti1.E1_TASDSCTO = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_CTIPA)) bdgXXXXenti1.E1_CTIPA = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_NUMAC)) bdgXXXXenti1.E1_NUMAC = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_PORT)) bdgXXXXenti1.E1_PORT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_ESTOP)) bdgXXXXenti1.E1_ESTOP = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_COVEDT)) bdgXXXXenti1.E1_COVEDT = "";
                if (String.IsNullOrEmpty(bdgXXXXenti1.E1_DIAVIS)) bdgXXXXenti1.E1_DIAVIS = "";

                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@tabla", "0002");
                parameters.Add("@codent", bdgXXXXenti1.E1_CODENT);
                parameters.Add("@tipo", bdgXXXXenti1.E1_TIPO);
                parameters.Add("@desent", bdgXXXXenti1.E1_DESENT);
                parameters.Add("@appat", bdgXXXXenti1.E1_APEPAT);
                parameters.Add("@apmat", bdgXXXXenti1.E1_APEMAT);
                parameters.Add("@nomb", bdgXXXXenti1.E1_NOMBRE1);
                parameters.Add("@nomb2", bdgXXXXenti1.E1_NOMBRE2);
                parameters.Add("@origen", bdgXXXXenti1.E1_ORIG);
                parameters.Add("@tiper", bdgXXXXenti1.E1_TIPPER);
                parameters.Add("@tipdoc", bdgXXXXenti1.E1_TIPDOC);
                parameters.Add("@coddoc", bdgXXXXenti1.E1_CODDOC);
                parameters.Add("@codgrup", bdgXXXXenti1.E1_CODGRUP);
                parameters.Add("@agen", bdgXXXXenti1.E1_AGEN);

                parameters.Add("@uscod", bdgXXXXenti1.E1_USCOD);
                parameters.Add("@estado", bdgXXXXenti1.E1_ESTADO);
                parameters.Add("@tipcont", bdgXXXXenti1.E1_TIPCONT);
                parameters.Add("@tasa", bdgXXXXenti1.E1_TASA);
                parameters.Add("@det", bdgXXXXenti1.E1_CODDET);
                parameters.Add("@per", bdgXXXXenti1.E1_CODPER);
                parameters.Add("@zona", bdgXXXXenti1.E1_ZONA);
                parameters.Add("@CLASCLI", bdgXXXXenti1.E1_CLASCLI);
                parameters.Add("@PAGWEB", bdgXXXXenti1.E1_PAGWEB);
                parameters.Add("@mail", bdgXXXXenti1.E1_MAIL);
                parameters.Add("@contacto", bdgXXXXenti1.E1_CONTACTO);
                parameters.Add("@telefono", bdgXXXXenti1.E1_TELEFONO);

                parameters.Add("@codven", bdgXXXXenti1.E1_CODVEN);
                parameters.Add("@codVTA", bdgXXXXenti1.E1_CONDVTA);
                parameters.Add("@codpen", bdgXXXXenti1.E1_PEN);
                parameters.Add("@tdes", bdgXXXXenti1.E1_TASDSCTO);
                parameters.Add("@codtip", bdgXXXXenti1.E1_CTIPA);
                parameters.Add("@numacc", bdgXXXXenti1.E1_NUMAC);
                parameters.Add("@porc", bdgXXXXenti1.E1_PORT);
                parameters.Add("@estop", bdgXXXXenti1.E1_ESTOP);
                parameters.Add("@COVEDT", bdgXXXXenti1.E1_COVEDT);
                parameters.Add("@E1_DIAVIS", bdgXXXXenti1.E1_DIAVIS);

                // return await connection.QueryAsync<Pago>("USP_CON_Guardarentidad", parameters, commandType: System.Data.CommandType.StoredProcedure);

                parameters.Add("OV_message_error", message, System.Data.DbType.String,
                    System.Data.ParameterDirection.Output);

                var carteleraCreada = await connection.QueryFirstOrDefaultAsync<BDGXXXXENTI1>("dbo.USP_CON_modificarENTIDAD",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OV_message_error");

                //return usuarioCreado;
                return new MensajeRetorno { Objeto = carteleraCreada, Mensaje = message };
            }
        }
    }



}
