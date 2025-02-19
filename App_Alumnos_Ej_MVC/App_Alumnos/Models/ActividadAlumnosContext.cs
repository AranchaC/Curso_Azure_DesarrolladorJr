using Microsoft.EntityFrameworkCore;

namespace App_Alumnos.Models
{
    public class ActividadAlumnosContext:DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.; initial catalog = ActividadAlumnoDB;" +
                " Integrated Security=true; Encrypt=true; TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}