using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Datos.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        public int ID_Clientes_Portales { get; set; }
        public string RUC_Cliente { get; set; }
        public string Servidor { get; set; }
        public string Base_Datos { get; set; }
        public string Usuario_Server { get; set; }
        public string Contrasenia_Server { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
