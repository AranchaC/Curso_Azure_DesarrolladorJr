using Entidades;
using Intercfaces;
using Microsoft.EntityFrameworkCore;
using Persistencias.Contexto;

namespace Persistencias
{
    public class Persistir_Proveedores : ICRUD<Proveedor>
    {
        List<Proveedor> _proveedores = new List<Proveedor> ();
        VentasContext context = new VentasContext ();
        public async Task<bool> Create(Proveedor Entidad)
        {
            bool estado = false;
            if (Entidad != null)
            {
                await context.Proveedores.AddAsync(Entidad);
                await context.SaveChangesAsync();
                estado = true;
            }
            return estado;
        }

        public async Task<bool> Delete(Proveedor Entidad)
        {
            bool estado = false;
            Proveedor? proveedorBuscado = await context.Proveedores.FindAsync(Entidad.ID);

            if (proveedorBuscado != null)
            {
                context.Proveedores.Remove(proveedorBuscado);
                await context.SaveChangesAsync();
                estado=true;
            }
            return estado;
        }

        public async Task<Proveedor?> Read(object id)
        {
            Proveedor? proveedorBuscado = await context.Proveedores.FindAsync(id);
            return proveedorBuscado;
        }

        public async Task<List<Proveedor>?> ReadAll()
        {
            return await context.Proveedores.ToListAsync();
        }

        public async Task<bool> Update(Proveedor Entidad)
        {
            bool estado = false;
            Proveedor? proveedorBuscado = await context.Proveedores.FindAsync(Entidad.ID);

            if (proveedorBuscado != null)
            {
                context.Proveedores.Update(proveedorBuscado);
                await context.SaveChangesAsync();
                estado = true;
            }
            return estado;
        }
    }
}
