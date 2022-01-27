using System;
using System.Collections.Generic;
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
    }
}
