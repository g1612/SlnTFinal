using App.TFinal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.UnitOfWork
{
    public interface IUnitOfWork
    {
        //ICategoriaRepository Categorias { get; }
        IDocumentoRepository Documentos { get; }
        IGeneroRepository Generos { get; }
        IRolRepository Rols { get; }
        ISalaRepository Salas { get; }
        //IProductoRepository Productos { get; }
       IUsuarioRepository Usuarios { get; }
        //IProveedorRepository Proveedores { get; }
        //ILogRepository Logs { get; }
    }
}
