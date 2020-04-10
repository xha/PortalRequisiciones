﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class REQUISC
    {
        [Key]
        [Display(Name = "Número")]
        public string NUMERO { get; set; }
        [Display(Name = "Solicitante")]
        public string SOLICITANTE { get; set; }
        [Display(Name = "Área")]
        public string AREA { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FECHA { get; set; }
        [Display(Name = "Estado")]
        public string ESTADO { get; set; }
    }
}
