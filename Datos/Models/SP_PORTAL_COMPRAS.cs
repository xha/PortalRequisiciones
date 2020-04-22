using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class SP_PORTAL_COMPRAS
    {
        [Key]
        public string EMP_CODIGO { get; set; }
        public string EMP_RAZON_NOMBRE { get; set; }
        [Key]
        public string USU_NOMBRE { get; set; }
    }
}
