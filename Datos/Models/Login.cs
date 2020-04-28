using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El RUC es obligatorio.")]
        public string RUC { get; set; }
        [Required(ErrorMessage = "El Código es obligatorio.")]
        public string CODIGO { get; set; }
        [Required(ErrorMessage = "La Clave es obligatoria.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Mínimo 4 caractéres")]
        public string CLAVE { get; set; }
    }
}
