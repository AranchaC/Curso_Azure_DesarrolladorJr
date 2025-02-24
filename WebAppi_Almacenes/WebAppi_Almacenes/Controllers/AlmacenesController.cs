using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAppi_Almacenes.Interfaces;
using WebAppi_Almacenes.Models;

namespace WebAppi_Almacenes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase, ICRUD<Almacen>
    {

        private readonly AlmacenDbContext context;
        public AlmacenesController(AlmacenDbContext _context)
        {
            this.context = _context;
        }

        [HttpGet("/read/{id}")]
        public async Task<ActionResult> Read(object id)
        {
            var almacenBuscado = await context.Almacenes.FindAsync(id);
            if (almacenBuscado == null)
            {
                return BadRequest("No existe.");
            }
            return Ok(almacenBuscado);
        }

        [HttpGet]
        public async Task<List<Almacen>> ReadAll()
        {
            return await context.Almacenes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Almacen Entity)
        {
            if(Entity == null)
            {
                return NotFound("No es válido.");
            }
            await context.Almacenes.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Ok(Entity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Almacen Entity)
        {
            //Almacen? almacenBuscado = await context.Almacenes.Where(
            //    alm => alm.Id == Entity.Id).FirstOrDefaultAsync();

            if(Entity == null)
            {
                return NotFound("No existe.");
            }
            context.Almacenes.Remove(Entity);
            await context.SaveChangesAsync();
            return Ok(Entity);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Almacen Entity)
        {
            Almacen? almacenBuscado = await context.Almacenes.FindAsync(Entity.Id);
            if (almacenBuscado == null)
            {
                return NotFound("No existe.");
            }
            almacenBuscado.Nombre = Entity.Nombre;
            almacenBuscado.Ubicacion = Entity.Ubicacion;
            almacenBuscado.Capacidad = Entity.Capacidad;
            
            context.Almacenes.Update(almacenBuscado);
            await context.SaveChangesAsync();
            return Ok(almacenBuscado);

        }
    }
}
