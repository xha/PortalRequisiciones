using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class REQUISC_PORTALModel
    {
        //SELECT GRID
        [Key]
        [Display(Name = "Nro. Requerimiento")]
        public string NROREQUI { get; set; }
        [Display(Name = "Cod. de Solicitud")]
        public string CODSOLIC { get; set; }
        [Display(Name = "Fecha Requerimiento")]
        public DateTime FECREQUI { get; set; }
        [Display(Name = "Glosa")]
        public string GLOSA { get; set; }
        [Display(Name = "Área")]
        public string AREA { get; set; }
        [Required]
        [Display(Name = "Tipo de Requerimiento")]
        public string TIPOREQUI { get; set; }
        [Required]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }
    }
}
