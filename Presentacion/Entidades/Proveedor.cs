using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Proveedor
    {
        [Key]
        public int ID {  get; set; }
        [StringLength(50)]
        public string? Nombre { get; set; }
        [StringLength(50)]
        public string? Direccion { get; set; }
        [StringLength(50)]
        public string? Telefono { get; set; }
    }
}
