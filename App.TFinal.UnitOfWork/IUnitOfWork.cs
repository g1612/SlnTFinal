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
        IEstadoPeliculaRepository EstadoPeliculas { get; }
        IDocumentoRepository Documentos { get; }
        IGeneroRepository Generos { get; }
        IRolRepository Rols { get; }

        IPeliculaRepository Peliculas { get; }
        ICarteleraRepository Carteleras { get; }

        ISalaRepository Salas { get; }
        //IProductoRepository Productos { get; }
       IUsuarioRepository Usuarios { get; }

        IPagoRepository Pagos { get; }
        IListaPeliculaRepository ListaPeliculas        {            get;        }
        //ILogRepository Logs { get; }
    }
}
