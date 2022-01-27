using System;
using System.Collections.Generic;
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
        public System.DateTime FechaInicio
        {
            get; set;
        }
        public System.DateTime FechaFin
        {
            get; set;
        }
        public string HorarioInicio
        {
            get; set;
        }
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
