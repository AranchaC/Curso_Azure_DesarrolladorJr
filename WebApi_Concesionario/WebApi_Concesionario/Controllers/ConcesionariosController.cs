using Microsoft.AspNetCore.Mvc;
using WebApi_Concesionario.Interfaces;
using WebApi_Concesionario.Models;

namespace WebApi_Concesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcesionariosController : ControllerBase
    {
        private readonly ICRUD<Concesionario> service;

        public ConcesionariosController(ICRUD<Concesionario> _service)
        {
            service = _service;
        }

        [HttpPost("Crear almacen")]
        public async Task<Concesionario> Create(Concesionario entity)
        {
            return await service.Create(entity);
        }

        [HttpPost("Crear varios almacenes")]
        public async Task<List<Concesionario>?> CrearVarios(List<Concesionario> entity)
        {
            return await service.CrearVarios(entity);
        }

        [HttpGet("Alamacen por ID")]
        public async Task<Concesionario> Read(int id)
        {
            return await service.Read(id);
        }

        [HttpGet("Lista de Almacenes")]
        public async Task<List<Concesionario>> ReadAll()
        {
            return await service.ReadAll();
        }

        [HttpPut("Actualizar almacen")]
        public async Task<Concesionario> Update(Concesionario entity)
        {
            return await service.Update(entity);
        }

        [HttpDelete("Borrar almacen")]
        public async Task<Concesionario> Delete(Concesionario entity)
        {
            return await service.Delete(entity);
        }

    }
}
