using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{

    //public interface IPeliculaRepository : IRepository<Pelicula>
    public interface IPagoRepository : IRepository<Pago>
    {

        Pago BuscarPorId(int id);
        // Task<bool> Modificar(Usuario entidad);
        Task<IEnumerable<Pago>> Listar(string titulo);
        Task<int> Eliminar(int id);

        Task<MensajeRetorno> RegistrarPago(Pago pago);

        Task<IEnumerable<Pago>> ListaPagos();


    }

}
