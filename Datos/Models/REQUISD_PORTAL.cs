using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class REQUISD_PORTAL
    {
		[Key]
		[Required]
		public string NROREQUI { get; set; }
		[Required]
		public string CODPRO { get; set; }
		[Required]
		public string DESCPRO { get; set; }
		[Required]
		public string UNIPRO { get; set; }
		[Required]
		public decimal CANTID { get; set; }
		[Required]
		public DateTime FECREQUE { get; set; }
		[Key]
		[Required]
		public decimal REQITEM { get; set; }
		[Required]
		public decimal SALDO { get; set; }
		public string CENCOST { get; set; }
		public string GLOSA { get; set; }
		public string REMAQ { get; set; }
		public string ORDFAB_REQUI { get; set; }
		[Key]
		[Required]
		public string TIPOREQUI { get; set; }
		[Required]
		public bool LISTO_CARGAR { get; set; }
		public bool ESTADO { get; set; }
    }
}
