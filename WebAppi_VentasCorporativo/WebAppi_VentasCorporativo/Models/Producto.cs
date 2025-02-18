using System;
using System.Collections.Generic;

namespace WebAppi_VentasCorporativas.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
