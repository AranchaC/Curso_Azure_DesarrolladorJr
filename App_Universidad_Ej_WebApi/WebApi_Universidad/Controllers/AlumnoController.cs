using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Universidad.Models;
using WebApi_Universidad.Models.Entities;

namespace WebApi_Universidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        UniversidadContext context = new UniversidadContext();
        [HttpGet]
        public async Task<List<Alumno>> ReadAll()
        {
            return await context.Alumnos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alumno>> Read(int id)
        {
            Alumno? alumnoBuscado = await context.Alumnos.Where(
                al => al.Id == id).FirstOrDefaultAsync();

            if(alumnoBuscado == null)
            {
                return NotFound("El alumno existe.");
            }
            return Ok(alumnoBuscado);
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> Create(Alumno alumno)
        {
            if (alumno == null)
            {
                return NotFound("El alumno no es válido.");

            }

            await context.Alumnos.AddAsync(alumno);
            await context.SaveChangesAsync();
            return Ok(alumno);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Alumno>> Update(Alumno alumno, int id)
        {
            Alumno? alumnoBuscado = await context.Alumnos.Where(
                al => al.Id == id).FirstOrDefaultAsync();

            if (alumno == null || alumnoBuscado == null)
            {
                return BadRequest("El alumno no es válido.");

            }
            alumnoBuscado.Nombre = alumno.Nombre;
            alumnoBuscado.Apellido = alumno.Apellido;
            alumnoBuscado.Edad = alumno.Edad;

            context.Alumnos.Update(alumnoBuscado);
            await context.SaveChangesAsync();
            return Ok(alumnoBuscado);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Alumno>> Delete( int id)
        {
            Alumno? alumnoBuscado = await context.Alumnos.Where(
               al => al.Id == id).FirstOrDefaultAsync();

            if (alumnoBuscado == null)
            {
                return BadRequest("El alumno no es válido.");
            }

            context.Alumnos.Remove(alumnoBuscado);
            await context.SaveChangesAsync();

            return Ok(alumnoBuscado);
        }

        //obtener alumno por apellido
        //obtener alumno por nombre
        //obtener alumno por edad

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<List<Alumno>>> ReadNombre(string nombre)
        {
            List<Alumno>? alumnoBuscado = await context.Alumnos.Where(
                al => al.Nombre == nombre).ToListAsync();

            if (alumnoBuscado == null)
            {
                return NotFound("El alumno existe.");
            }
            return Ok(alumnoBuscado);
        }

        [HttpGet("apellido/{apellido}")]
        public async Task<ActionResult<Alumno>> ReadApellido(string apellido)
        {
            Alumno? alumnoBuscado = await context.Alumnos.Where(
                al => al.Apellido == apellido).FirstOrDefaultAsync();

            if (alumnoBuscado == null)
            {
                return NotFound("El alumno existe.");
            }
            return Ok(alumnoBuscado);
        }

        [HttpGet("edad/{edad:int}")]
        public async Task<ActionResult<List<Alumno>>> ReadEdad(int edad)
        {
            List<Alumno>? alumnoBuscado = await context.Alumnos.Where(
                al => al.Edad == edad).ToListAsync ();

            if (alumnoBuscado == null)
            {
                return NotFound("El alumno existe.");
            }
            return Ok(alumnoBuscado);
        }


    }
}
