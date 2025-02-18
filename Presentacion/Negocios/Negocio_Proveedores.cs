using System.Security.Cryptography;
using Entidades;
using Intercfaces;
using Persistencias;

namespace Negocios
{
    public class Negocio_Proveedores : ICRUD<Proveedor>
    {
        Persistir_Proveedores persistir_Proveedores = new Persistir_Proveedores();
        public async Task<bool> Create(Proveedor Entidad)
        {
            return await persistir_Proveedores.Create(Entidad);
        }

        public async Task<bool> Delete(Proveedor Entidad)
        {
            return await persistir_Proveedores.Delete(Entidad);
        }

        public async Task<Proveedor?> Read(object id)
        {
            return await persistir_Proveedores.Read(id);
        }

        public async Task<List<Proveedor>?> ReadAll()
        {
            return await persistir_Proveedores.ReadAll();
        }

        public async Task<bool> Update(Proveedor Entidad)
        {
            return await persistir_Proveedores.Update(Entidad);
        }
    }
}
