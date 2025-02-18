using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppi_VentasCorporativas.Models;


namespace WebAppi_VentasCorporativo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController:ControllerBase
    {

        VentasCorporativasContext context = new VentasCorporativasContext();

        [HttpGet]
        public async Task<List<Cliente>> ReadAll()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Read(int id)
        {
            Cliente? clienteBuscado = await context.Clientes.Where(
               cl => cl.IdCliente == id).FirstOrDefaultAsync();

            if (clienteBuscado == null) 
            {
                return NotFound("El cliente no existe.");
            }
            return Ok(clienteBuscado);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            if (cliente == null)
            {
                return NotFound("El cliente introducido no es válido.");
            }

            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Update(Cliente cliente, int id)
        {
            Cliente? clienteBuscado = await context.Clientes.Where(
               cl => cl.IdCliente == id).FirstOrDefaultAsync();

            if(clienteBuscado == null)
            {
                return BadRequest("El cliente introducido no es válido.");
            }

            clienteBuscado.Nombre = cliente.Nombre;
            clienteBuscado.Direccion = cliente.Direccion;
            clienteBuscado.Telefono = cliente.Telefono;
            clienteBuscado.Email = cliente.Email;
            clienteBuscado.Web = cliente.Web;
            clienteBuscado.Comentarios = cliente.Comentarios;

            context.Clientes.Update(clienteBuscado);
            await context.SaveChangesAsync();
            return Ok(clienteBuscado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            Cliente? clienteBuscado = await context.Clientes.Where(
               cl => cl.IdCliente == id).FirstOrDefaultAsync();

            if (clienteBuscado == null)
            {
                return NotFound("El cliente ingroducido no es válido.");
            }

            context.Clientes.Remove(clienteBuscado);
            await context.SaveChangesAsync();
            return Ok(clienteBuscado);

            
        }
    }
}
