using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.TFinal.Models
{
   public class BDGXXXXENTI2
    {
        public string E2_CODENT { get; set; }
        public string E2_TIPO { get; set; }
        public string E2_CODDET { get; set; }
        public string E2_DESDET { get; set; }
        public string E2_TIPNUM { get; set; }
        public string E2_NUMINI { get; set; }
        public string E2_NUMFIN { get; set; }
        public string E2_USCOD { get; set; }
        public Nullable<System.DateTime> E2_FECCRE { get; set; }
        public string E2_USMOD { get; set; }
        public Nullable<System.DateTime> E2_FECMOD { get; set; }
        public string E2_USIMG { get; set; }
        public Nullable<System.DateTime> E2_FECMIG { get; set; }
    }
}
