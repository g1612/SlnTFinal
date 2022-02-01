using App.TFinal.Repositories;
using App.TFinal.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.UnitOfWork
{
    public class VentasUnitOfWork: IUnitOfWork
    {
        public VentasUnitOfWork(string connectionString)
        {
            Generos = new GeneroRepository(connectionString);
            Documentos = new DocumentoRepository(connectionString);
            Salas = new SalaRepository(connectionString);
            Rols = new RolRepository(connectionString);
            EstadoPeliculas = new EstadoPeliculaRepository(connectionString);
            //Productos = new ProductoRepository(connectionString);
            Usuarios = new UsuarioRepository(connectionString);
            Peliculas = new PeliculaRepository(connectionString);
            Carteleras = new CarteleraRepository(connectionString);
            Pagos = new PagoRepository(connectionString);
            //Proveedores= new ProveedorRepository(connectionString);
            //Ventas = new VentaRepository(connectionString);
            //Logs = new LogRepository(connectionString);
        }

        public IPagoRepository Pagos
        {
            get;
            private set;
        }

        public ICarteleraRepository Carteleras
        {
            get;
            private set;
        }


        public IPeliculaRepository Peliculas
        {
            get;
            private set;
        }

        public IGeneroRepository Generos
        {
            get;
            private set;
        }
        public IDocumentoRepository Documentos
        {
            get;
            private set;
        }
        public ISalaRepository Salas
        {
            get;
            private set;
        }
        public IRolRepository Rols
        {
            get;
            private set;
        }

        
        public IEstadoPeliculaRepository EstadoPeliculas
        {
            get;
            private set;
        }
        //public IProductoRepository Productos
        //{
        //    get;
        //    private set;
        //}
        public IUsuarioRepository Usuarios
        {
            get;
            private set;
        }
       // public IProveedorRepository Proveedores
        //{
        //    get;
        //    private set;
        //}
        //public ILogRepository Logs
        //{
        //    get;
        //    private set;
        //}
    }
}
