using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TFinal.Models;

namespace App.TFinal.Repositories
{
    public interface IEstadoPeliculaRepository : IRepository<EstadoPelicula>
    {
        EstadoPelicula BuscarPorId(int id);
        Task<IEnumerable<EstadoPelicula>> Listar(string Descripcion);
        Task<int> Eliminar(int id);
    }
}