using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TFinal.Models;
namespace App.TFinal.Repositories
{
    public interface IDocumentoRepository : IRepository<Documento>
    {
        Documento BuscarPorId(int id);
        Task<IEnumerable<Documento>> Listar(string Descripcion);
        Task<int> Eliminar(int id); 
    }
}
