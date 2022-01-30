using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{
    // public interface IUsuarioRepository : IRepository<Usuario>
    public interface IPeliculaRepository : IRepository<Pelicula>
    {

        Pelicula BuscarPorId(int id);
        // Task<bool> Modificar(Usuario entidad);
        Task<IEnumerable<Pelicula>> Listar(string titulo);
        Task<int> Eliminar(int id);

        Task<MensajeRetorno> CrearPelicula(Pelicula pelicula);


    }
    //coment
}
