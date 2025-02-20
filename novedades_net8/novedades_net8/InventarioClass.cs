using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novedades_net8
{
    public class InventarioClass
    {
        public record Producto(int id, string Nombre, double Precio, int Stock);

        public List<Producto> ListaDeInventario()
        {
            List<Producto> inventario = new List<Producto>()
            {
                new Producto(1, "peras", 4.6, 80),
                new Producto(2, "fresas", 5.8, 90),
                new Producto(2, "limones", 6.7, 100)
            };
            return inventario;
        }
    }
}
