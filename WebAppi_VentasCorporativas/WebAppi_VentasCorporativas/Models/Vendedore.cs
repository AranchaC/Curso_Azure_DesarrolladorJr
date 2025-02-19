using System;
using System.Collections.Generic;

namespace WebAppi_VentasCorporativas.Models;

public partial class Vendedore
{
    public int IdVendedor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Movil { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
