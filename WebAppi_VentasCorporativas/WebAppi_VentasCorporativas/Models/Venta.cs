using System;
using System.Collections.Generic;

namespace WebAppi_VentasCorporativas.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int Cliente { get; set; }

    public int Vendedor { get; set; }

    public int Producto { get; set; }

    public int Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public virtual Cliente ClienteNavigation { get; set; } = null!;

    public virtual Producto ProductoNavigation { get; set; } = null!;

    public virtual Vendedore VendedorNavigation { get; set; } = null!;
}
