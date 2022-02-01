using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{

    // public interface IPeliculaRepository : IRepository<Pelicula>
    public interface ICarteleraRepository : IRepository<Cartelera>
    {


        Cartelera BuscarPorId(int id);
         
        Task<IEnumerable<Cartelera>> Listar(string titulo);
        Task<int> Eliminar(int id);

        Task<MensajeRetorno> CrearCartelera(Cartelera pelicula);

        Task<IEnumerable<Cartelera>> ListarCarteleras();




    }
}
