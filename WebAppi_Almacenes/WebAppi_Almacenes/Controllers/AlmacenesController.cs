using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAppi_Almacenes.Interfaces;
using WebAppi_Almacenes.Models;

namespace WebAppi_Almacenes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly ICRUD<Almacen> service;

        public AlmacenesController(ICRUD<Almacen> _service)
        {
            service = _service; 
        }

        [HttpPost]
        public async Task<Almacen> Create(Almacen Entity)
        {
            return await service.Create(Entity);
        }

        [HttpGet("/{id}")]
        public async Task<Almacen> Read(int id)
        {
            return await service.Read(id);
        }

        [HttpGet("ReadAll")]
        public async Task<List<Almacen>> ReadAll()
        {
            return await service.ReadAll();
        }

        [HttpPut]
        public async Task<Almacen> Update(Almacen Entity)
        {
            return await service.Update(Entity);
        }

        [HttpDelete]
        public async Task<Almacen> Delete(Almacen Entity)
        {
            return await service.Delete(Entity);
        }
    }
}
