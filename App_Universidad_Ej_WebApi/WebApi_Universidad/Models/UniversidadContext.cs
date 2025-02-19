using Microsoft.EntityFrameworkCore;
using WebApi_Universidad.Models.Entities;

namespace WebApi_Universidad.Models
{
    public class UniversidadContext:DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog= UniversidadDB; " +
                "Integrated Security=true; Encrypt=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
