using App.TFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        // Task<int> Agregar(Usuario entidad);
        // Task<Usuario> Obtener(int id);
        Usuario BuscarPorId(int id);
        // Task<bool> Modificar(Usuario entidad);
        Task<IEnumerable<Usuario>> Listar(string nombres );
        Task<int> Eliminar(int id);

        Task<Usuario> ValidarUsuario(string email, string password);


        Task<MensajeRetorno> CrearUsuario(Usuario usuario);

    }
}
