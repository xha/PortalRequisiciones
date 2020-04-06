using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class UsuarioModel
    {
        [Key]
        public int idUsuario { get; set; }

        public string nombre { get; set; }
        public string clave { get; set; }
        public bool estatus { get; set; }
        public string email { get; set; }
    }
}
