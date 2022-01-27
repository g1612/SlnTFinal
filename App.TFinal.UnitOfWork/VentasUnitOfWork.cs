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
            //Categorias = new CategoriaRepository(connectionString);
            //Marcas = new MarcaRepository(connectionString);
            //Rols = new RolRepository(connectionString);
            //Clientes = new ClienteRepository(connectionString);
            //Productos = new ProductoRepository(connectionString);
            Usuarios = new UsuarioRepository(connectionString);
            //Proveedores= new ProveedorRepository(connectionString);
            //Ventas = new VentaRepository(connectionString);
            //Logs = new LogRepository(connectionString);
        }


        //public ICategoriaRepository Categorias
        //{
        //    get;
        //    private set;
        //}
        //public IVentaRepository Ventas { 
        //    get; 
        //    private set; 
        //}
        //public IMarcaRepository Marcas {
        //    get;
        //    private set;
        //}
        //public IRolRepository Rols
        //{
        //    get;
        //    private set;
        //}
        //public IClienteRepository Clientes
        //{
        //    get;
        //    private set;
        //}
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
