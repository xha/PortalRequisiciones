using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class REQUISC_PORTAL
    {
        //SELECT GRID
        [Key]
        [Required]
        [Display(Name = "No. Req.")]
        public string NROREQUI { get; set; }
        [Required]
        [Display(Name = "Solicitante")]
        public string CODSOLIC { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime FECREQUI { get; set; }
        [Display(Name = "Glosa")]
        public string GLOSA { get; set; }
        [Required]
        [Display(Name = "Área")]
        public string AREA { get; set; }
        [Key]
        [Required]
        [Display(Name = "Tipo de Req.")]
        public string TIPOREQUI { get; set; }
        [Required]
        [Display(Name = "Tipo de Doc.")]
        public string TipoDocumento { get; set; }
        [Required]
        public string COD_USUARIO { get; set; }
    }
}
