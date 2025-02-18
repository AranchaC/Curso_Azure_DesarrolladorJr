using System.ComponentModel.DataAnnotations;

namespace App_Alumnos.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string? Apellido { get; set; }
    }
}