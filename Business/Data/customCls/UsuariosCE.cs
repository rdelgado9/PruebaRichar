using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.Data
{
  public  class UsuariosCE
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El Password es obligatorio")]
        [Display(Name = "Contraseña")]
        public string password { get; set; }


        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Nro de Identificación es obligatorio")]
        [Display(Name = "Nro de Identificación")]
        public string NroIdentificacion { get; set; }


        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Dirección de correo no válida")]
        public string Email { get; set; }

        [Display(Name = "Tipo de Identificación")]
        [Required(ErrorMessage = "El Tipo de identificación es obligatorio")]
        public string TipoIdentificacion { get; set; }

        public string fullName { get; set; }
        public string identificacionFull { get; set; }

    }
}
