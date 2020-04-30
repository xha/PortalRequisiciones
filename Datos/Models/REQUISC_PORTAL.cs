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
        [Display(Name = "Nro. Requisición.")]
        public string NROREQUI { get; set; }
        [Required(ErrorMessage = "El solicitante es obligatorio.")]
        [Display(Name = "Solicitante")]
        public string CODSOLIC { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? FECREQUI { get; set; }
        [Display(Name = "Glosa")]
        public string GLOSA { get; set; }
        [Required(ErrorMessage = "El área es obligatoria.")]
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
