using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(50)]
        public string Nombres
        {
            get; set;
        }
        [Required]
        [MaxLength(50)]
        public string Apellidos
        {
            get; set;
        }

        [Required]
        [MaxLength(15)]
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


        [Required]
        [EmailAddress(ErrorMessage = "Email no valido")]
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

        [Required]
        [MaxLength(15)]
        public string Login
        {
            get; set;
        }

        [Required(ErrorMessage = "Ingrese contraseña")]
        [DataType(DataType.Password)]
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
