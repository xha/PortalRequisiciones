using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class REQUISD_PORTAL
    {
		[Key]
		public string NROREQUI { get; set; }
		public string CODPRO { get; set; }
		public string DESCPRO { get; set; }
		public string UNIPRO { get; set; }
		public decimal CANTID { get; set; }
		public DateTime FECREQUE { get; set; }
		public decimal REQITEM { get; set; }
		public decimal SALDO { get; set; }
		public string CENCOST { get; set; }
		public string GLOSA { get; set; }
		public string REMAQ { get; set; }
		public string ORDFAB_REQUI { get; set; }
		public string TIPOREQUI { get; set; }
		public bool LISTO_CARGAR { get; set; }
		public bool ESTADO { get; set; }
    }
}
