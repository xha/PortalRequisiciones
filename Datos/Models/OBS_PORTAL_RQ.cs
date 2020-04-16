using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class OBS_PORTAL_RQ
    {
        [Key]
        public string NRO_RQ { get; set; }
        public int PASO { get; set; }
        public string EJECUCION { get; set; }
        public string ERROR { get; set; }
    }
}
