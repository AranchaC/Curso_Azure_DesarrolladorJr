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

        [HttpPost("CrearAlmacen")]
        public async Task<Concesionario> Create(Concesionario entity)
        {
            return await service.Create(entity);
        }

        [HttpPost]
        public async Task<List<Concesionario>?> CrearVarios(List<Concesionario> entity)
        {
            return await service.CrearVarios(entity);
        }

        [HttpGet("{id}")]
        public async Task<Concesionario> Read(int id)
        {
            return await service.Read(id);
        }

        [HttpGet]
        public async Task<List<Concesionario>> ReadAll()
        {
            return await service.ReadAll();
        }

        [HttpPut]
        public async Task<Concesionario> Update(Concesionario entity)
        {
            return await service.Update(entity);
        }

        [HttpDelete]
        public async Task<Concesionario> Delete(Concesionario entity)
        {
            return await service.Delete(entity);
        }

    }
}
