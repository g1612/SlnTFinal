using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
   public class ListaPelicula
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
        [Computed]
        [Display(Name = "Hora Inicio")]
        public string HorarioInicio
        {
            get; set;
        }
        [Computed]
        [Display(Name = "Descripción Sala")]
        public string Descripcion
        {
            get; set;
        }
        [Computed]
        public string Precio
        {
            get; set;
        }
        public int IdSala
        {
            get; set;
        }
        public int IdCartelera
        {
            get; set;
        }
    }
}
