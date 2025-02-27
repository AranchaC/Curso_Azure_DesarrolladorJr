using WebApi_Concesionario.Interfaces;
using WebApi_Concesionario.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Concesionario.Services
{
    public class ConcesionarioService : ICRUD<Concesionario>
    {
        private readonly ConcesionarioDbContext context;
        public ConcesionarioService(ConcesionarioDbContext _context)
        {
            this.context = _context;
        }
        public async Task<Concesionario?> Create(Concesionario entity)
        {
            if (entity == null)
            {
                return null;
            }
            await context.Concesionarios.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Concesionario>> CrearVarios(List<Concesionario> entity)
        {
            if (entity == null || entity.Count == 0)
            {
                return null;
            }

            foreach (var en in entity)
            {
                await context.Concesionarios.AddAsync(en);
            }

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Concesionario?> Read(object id)
        {
            var concesionarioBuscado = await context.Concesionarios.FindAsync(id);
            if (concesionarioBuscado == null)
            {
                return null;
            }
            return concesionarioBuscado;
        }

        public async Task<List<Concesionario>> ReadAll()
        {
            return await context.Concesionarios.ToListAsync();
        }

        public async Task<Concesionario?> Update(Concesionario entity)
        {
            var concesionarioBuscado = await context.Concesionarios.FindAsync(entity.Id);
            if (concesionarioBuscado == null)
            {
                return null;
            }
            concesionarioBuscado.Marca = entity.Marca;
            concesionarioBuscado.Modelo = entity.Modelo;
            concesionarioBuscado.Precio = entity.Precio;
            concesionarioBuscado.Descripcion = entity.Descripcion;

            context.Concesionarios.Update(concesionarioBuscado);
            await context.SaveChangesAsync();
            return concesionarioBuscado;
        }
        public async Task<Concesionario?> Delete(Concesionario entity)
        {
            if (entity  == null)
            {
                return null;
            }
            context.Concesionarios.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
