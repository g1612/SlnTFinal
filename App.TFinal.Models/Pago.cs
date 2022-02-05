using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
   public class Pago
    {
        public int Id
        {
            get; set;
        }
        public int IdUsuario
        {
            get; set;
        }
        public int IdCartelera
        {
            get; set;
        }
        public int Cantidad
        {
            get; set;
        }
        public decimal Total
        {
            get; set;
        }

        [Computed]
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

        [Computed]
        public int IdEstadoPelicula
        {
            get; set;
        }
        [Computed]
        public string Titulo
        {
            get; set;
        }
        [Computed]
        public string Duracion
        {
            get; set;
        }
        [Computed]
        public string Sipnosis
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
        [Computed]
        public int IdSala
        {
            get; set;
        }
        [Computed]
        public int IdPelicula
        {
            get; set;
        }
    }
}
