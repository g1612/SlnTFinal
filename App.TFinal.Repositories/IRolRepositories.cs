using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{
   public interface IRolRepositories : IRepository<Rol>
    {
               Rol BuscarPorId(int id);
              Task<IEnumerable<Rol>> Listar(string Descripcion);
        Task<int> Eliminar(int id);

       
    }

}
