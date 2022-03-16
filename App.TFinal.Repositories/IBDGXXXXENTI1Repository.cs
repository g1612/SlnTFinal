using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.TFinal.Repositories
{
   public interface IBDGXXXXENTI1Repository : IRepository<BDGXXXXENTI1>
    {
        Task<BDGXXXXENTI1> BuscarPorId(BDGXXXXENTI1 pelicula, string id);
        //Task<IEnumerable<BDGXXXXENTI1>> BuscarPorId(string id);
        Task<IEnumerable<BDGXXXXENTI1>> Listar(string titulo);
        Task<int> Eliminar(string id);

    
        Task<MensajeRetorno> CrearBDGXXXXENTI1(BDGXXXXENTI1 pelicula);

        Task<IEnumerable<BDGXXXXENTI1>> ListarBDGXXXXENTI1(string tab,string id);
        
 Task<MensajeRetorno> ModificarBDGXXXXENTI1(BDGXXXXENTI1 pelicula);
    }
}
