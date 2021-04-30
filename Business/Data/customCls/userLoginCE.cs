using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.Data
{
    public class userLoginCE
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}
