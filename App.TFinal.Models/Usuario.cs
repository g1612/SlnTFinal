using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TFinal.Models
{
    public class Usuario
    {
        public int Id
        {
            get; set;
        }
        public string Nombres
        {
            get; set;
        }
        public string Apellidos
        {
            get; set;
        }
        public string Telefono
        {
            get; set;
        }
        public string Direccion
        {
            get; set;
        }
        public string Sexo
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public int IdRol
        {
            get; set;
        }
        public int IdDocumento
        {
            get; set;
        }
        public string NumeroDocumento
        {
            get; set;
        }
        public string Login
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public bool Estado
        {
            get; set;
        }
    }
}
