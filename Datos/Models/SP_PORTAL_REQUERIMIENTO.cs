using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class SP_PORTAL_REQUERIMIENTO
    {
        [Key]
        public string TIPO { get; set; }
        [Key]
        [Display(Name = "Nro. Requisición.")]
        public string NRO_REQUERIMIENTO { get; set; }
        public DateTime FECHA { get; set; }
        public string AREA { get; set; }
        public string CODIGO_AREA { get; set; }
        public string CODIGO_SOLICITANTE { get; set; }
        public string SOLICITANTE { get; set; }
        public string GLOSA { get; set; }
        public string CODIGO_ARTICULO { get; set; }
        public string ARTICULO { get; set; }
        public string UNIDAD_MEDIDA { get; set; }
        public decimal CANTIDAD { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string MAQUINA { get; set; }
    }
}
