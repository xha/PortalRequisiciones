using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    class ComprasModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }
}
