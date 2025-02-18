using App_Alumnos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App_Alumnos.Models
{
    public class AlumnoRepository : ICRUD<Alumno>
    {
        private readonly ActividadAlumnosContext _context;

        public AlumnoRepository() 
        {
            _context = new ActividadAlumnosContext();

        }

        public async Task<bool> Create(Alumno Entity)
        {
            bool estado = false;
            if (Entity != null)
            {
                await _context.Alumnos.AddAsync(Entity);
                await _context.SaveChangesAsync();
                estado = true;
            }

            return estado;
        }

        public async Task<bool> Delete(object id)
        {
            bool estado = false;
            Alumno? alumnoBuscado = await _context.Alumnos.Where(a => a.Id==(int)id).FirstOrDefaultAsync();
            if (alumnoBuscado != null)
            {
                _context.Alumnos.Remove(alumnoBuscado);
                await _context.SaveChangesAsync();
                estado = true;
            }

            return estado;
        }

        public async Task<Alumno?> Read(object id)
        {
            Alumno? alumnoBuscado = await _context.Alumnos.FindAsync(id);
            return alumnoBuscado;
        }

        public async Task<List<Alumno>> ReadAll()
        {
            return await _context.Alumnos.ToListAsync();
        }

        public async Task<bool> Update(Alumno Entity)
        {
            bool estado = true;
            Alumno? alumnoBuscado = await _context.Alumnos.FindAsync(Entity.Id);
            if (alumnoBuscado != null)
            {
                _context.Entry(alumnoBuscado).State = EntityState.Detached;
                _context.Alumnos.Update(Entity);
                await _context.SaveChangesAsync();
            }
            return estado;
        }
    }
}
