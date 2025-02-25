using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppi_Almacenes.Interfaces;
using WebAppi_Almacenes.Models;

namespace WebAppi_Almacenes.Services
{
    public class AlmacenService : ICRUD<Almacen>
    {
        private readonly AlmacenDbContext context;
        public AlmacenService(AlmacenDbContext _context)
        {
            this.context = _context;
        }


        public async Task<Almacen?> Read(object id)
        {
            var almacenBuscado = await context.Almacenes.FindAsync(id);
            if (almacenBuscado == null)
            {
                return null;
            }
            return almacenBuscado;
        }

        public async Task<List<Almacen>> ReadAll()
        {
            return await context.Almacenes.ToListAsync();
        }

        public async Task<Almacen?> Create(Almacen Entity)
        {
            if (Entity == null)
            {
                return null;
            }
            await context.Almacenes.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<Almacen?> Delete(Almacen Entity)
        {
            //Almacen? almacenBuscado = await context.Almacenes.Where(
            //    alm => alm.Id == Entity.Id).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return null;
            }
            context.Almacenes.Remove(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<Almacen?> Update(Almacen Entity)
        {
            Almacen? almacenBuscado = await context.Almacenes.FindAsync(Entity.Id);
            if (almacenBuscado == null)
            {
                return null;
            }
            almacenBuscado.Nombre = Entity.Nombre;
            almacenBuscado.Ubicacion = Entity.Ubicacion;
            almacenBuscado.Capacidad = Entity.Capacidad;

            context.Almacenes.Update(almacenBuscado);
            await context.SaveChangesAsync();
            return almacenBuscado;

        }
    }
}
