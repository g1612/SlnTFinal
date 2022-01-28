using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TFinal.Models;

namespace App.TFinal.Repositories
{
  public  interface ISalaRepository : IRepository<Sala>
    {
        Sala BuscarPorId(int id);
        Task<IEnumerable<Sala>> Listar(string Descripcion);
        Task<int> Eliminar(int id);


    }
}
