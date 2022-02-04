using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{
   public interface IListaPeliculaRepository : IRepository<ListaPelicula>
    {


        Task<IEnumerable<ListaPelicula>> BuscarPorId(int id);
        Task<IEnumerable<ListaPelicula>> ListarPeliculas();
        Task<IEnumerable<ListaPelicula>> ListaCartelera(int id);

    }
    //coment
}
