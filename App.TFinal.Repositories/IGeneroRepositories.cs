using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TFinal.Models;

namespace App.TFinal.Repositories
{
    interface IGeneroRepositories : IRepository<Genero>
    {
        Genero BuscarPorId(int id);
        Task<IEnumerable<Genero>> Listar(string Descripcion);
        Task<int> Eliminar(int id);


    }
}
