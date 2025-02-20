using System.Numerics;
using System.Security.Cryptography.X509Certificates;

main();

void main()
{
    var producto1 = new Producto<decimal>("IPhone 15", 850.50m);
    var producto2 = new Producto<decimal>("IPhone 13", 750.50m);
    var producto3 = new Producto<decimal>("IPhone 12", 650.50m);

    var linea1 = new LineaFactura<decimal>(producto1, 5);
    var linea2 = new LineaFactura<decimal>(producto2, 6);
    var linea3 = new LineaFactura<decimal>(producto3, 4);
    var linea4 = new LineaFactura<decimal>(producto2, 3);
    var linea5 = new LineaFactura<decimal>(producto1, 2);

    var factura = new Factura<decimal>();

    factura.Items.Add(linea1);
    factura.Items.Add(linea2);
    factura.Items.Add(linea3);
    factura.Items.Add(linea4);
    factura.Items.Add(linea5);

    factura.ImprimirFactura();
}

//Declaro el record para producto.
public record Producto<T>(string Nombre, T Precio) where T:INumber<T>;

//Declaro el record par línea de factura.
public record LineaFactura<T>(Producto<T> Producto, int Cantidad) where T : INumber<T>
{
    //Declaro variable que obtiene el precio x cantidad del producto.
    public T Subtotal => Producto.Precio * T.CreateChecked(Cantidad);
}

public class Factura<T> where T:INumber<T>
{
    //Declaro listado de productos comprados:
    public List<LineaFactura<T>> Items { get; init; } = new();
    public T CalcularTotal()
    {
        T total = T.Zero;
        // es igual que: double total = 0;
        foreach (var linea in Items)
        {
            total += linea.Subtotal;
        }
        return total;
    }

    public void ImprimirFactura()
    {
        string detalle = string.Empty;
        T totalFactura = CalcularTotal();

        string tituloFactura =
            """
                -------------------------------------
                               FACTURA
                -------------------------------------
            """;

        Console.WriteLine(tituloFactura);

        foreach (var linea in Items)
        {
            detalle =
                $"""

                            *** {linea.Producto.Nombre} ***

                    Precio por ud: {linea.Producto.Precio}
                    Cantidad: {linea.Cantidad}
                    Subtotal: {linea.Subtotal}

                """;
            Console.WriteLine(
                $"""
                    -------------------------------------
                                   {detalle}
                    -------------------------------------
                """
                );
        }
        Console.WriteLine($"Total a pagar: {totalFactura}");
    }
}
