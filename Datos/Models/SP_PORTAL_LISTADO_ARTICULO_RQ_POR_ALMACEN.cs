using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class SP_PORTAL_LISTADO_ARTICULO_RQ_POR_ALMACEN
    {
        [Key]
        public string CODIGO { get; set; }
        public string ARTICULO { get; set; }
        public string UNIDAD { get; set; }
        public string COD_FAMILIA { get; set; }
        [Key]
        public string COD_ALMACEN { get; set; }
        public string ALMACEN { get; set; }
        public decimal STOCK { get; set; }
        public string UBICACION { get; set; }
    }
}
