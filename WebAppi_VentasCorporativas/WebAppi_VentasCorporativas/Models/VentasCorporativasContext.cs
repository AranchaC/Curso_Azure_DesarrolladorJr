using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAppi_VentasCorporativas.Models;

namespace WebAppi_VentasCorporativas.Models
{
    public class VentasCorporativasContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog= VentasCorporativasDB; " +
                "Integrated Security=true; Encrypt=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
