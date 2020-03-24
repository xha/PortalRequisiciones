using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class DbCon : DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {

        }

        //public DbSet<PaisModel> Pais { get; set; }
        //public DbSet<UsuarioModel> Usuario { get; set; }
    }
}