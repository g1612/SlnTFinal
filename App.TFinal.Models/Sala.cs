using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
   public class Sala
    {
        public int Id
        {
            get; set;
        }
        public string NSala
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }
        public int Capacidad
        {
            get; set;
        }
        public bool Estado
        {
            get; set;
        }
    }

}
