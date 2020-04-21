using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class EMPRESA
    {
        [Key]
        public string EMP_CODIGO { get; set; }
        public string EMP_RAZON_NOMBRE { get; set; }
    }
}
