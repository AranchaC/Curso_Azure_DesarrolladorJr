using Microsoft.AspNetCore.Mvc;
using Entidades;
using Intercfaces;
using Persistencias;
using Persistencias.Contexto;


namespace VentasWeb.Controllers
{
    public class ProveedorController : Controller
    {
        Persistir_Proveedores persistir_proveedores = new Persistir_Proveedores();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Proveedor> proveedores = await persistir_proveedores.ReadAll();

            return View(proveedores);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                await persistir_proveedores.Create(proveedor);
            }
            return RedirectToAction("Index");
        }
    }
}
