﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
  public class Documento
    {
        public int Id
        {
            get; set;
        }
        public string Documento
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }
        public bool Estado
        {
            get; set;
        }
    }
}
