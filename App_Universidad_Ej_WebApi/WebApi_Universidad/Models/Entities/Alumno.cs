using System.ComponentModel.DataAnnotations;

namespace WebApi_Universidad.Models.Entities
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string Apellido { get;set; }

        [Required]
        [Range(18,100,ErrorMessage ="La edad no es correcta")]
        public short Edad { get; set; }
    }
}
