using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Computed]
        [Display(Name = "Genero")]
        public string nombregenero
        {
            get; set;
        }

        //descripcionestpel

        [Computed]
        [Display(Name = "Estado Pelicula")]
        public string descripcionestpel
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
