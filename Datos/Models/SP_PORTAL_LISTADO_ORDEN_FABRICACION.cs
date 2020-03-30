using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class SP_PORTAL_LISTADO_ORDEN_FABRICACION
    {
        [Key]
        public string CODIGO { get; set; }
        public string ORDEN_FABRICACION { get; set; }
    }
}
