using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Persistencias.Contexto
{
    public class VentasContext:DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog = VentasDBSQL; " +
                "Integrated Security=true;Encrypt=True;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
