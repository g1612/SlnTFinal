using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
    public class Cartelera
    {
        public int Id
        {
            get; set;
        }
        public int IdPelicula
        {
            get; set;
        }
        public int IdSala
        {
            get; set;
        }

        [Computed]
        [Display(Name = "Pelicula")]
        public string titulopelicula
        {
            get; set;
        }


        [Computed]
        [Display(Name = "Sala")]
        public string nombresala
        {
            get; set;
        }

        [Display(Name = "Fecha Inicial")]
        public System.DateTime FechaInicio
        {
            get; set;
        }

        [Display(Name = "Fecha Final")]
        public System.DateTime FechaFin
        {
            get; set;
        }

        [Display(Name = "H. Inicio")]
        public string HorarioInicio
        {
            get; set;
        }

        [Display(Name = "H. Fin")]
        public string HorarioFin
        {
            get; set;
        }
        public decimal Precio
        {
            get; set;
        }
        public bool Estado
        {
            get; set;
        }

    }
}
