using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
   public class Pelicula
    {
        public int Id
        {
            get; set;
        }
        public int IdGenero
        {
            get; set;
        }
        public int IdEstadoPelicula
        {
            get; set;
        }
        public string Titulo
        {
            get; set;
        }
        public string Duracion
        {
            get; set;
        }
        public string Sipnosis
        {
            get; set;
        }
        public bool Estado
        {
            get; set;
        }
    }
}
