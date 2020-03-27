using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class SP_PORTAL_LISTADO_SOLICITANTE
    {
        [Key]
        public string CODIGO { get; set; }
        public string SOLICITANTE { get; set; }
    }
}
