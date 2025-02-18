using Microsoft.AspNetCore.Mvc;

namespace VentasWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return RedirectToAction("Index", "Proveedor");

            //string? nombre = "Juan";
            //short? edad = 28;

            ////ViewData - ViewBag - Model

            //ViewData["nombre"] = nombre; // guarda un object
            //ViewBag.Nombre = nombre;

            //object[] misObjetos = new object[2];
            //misObjetos[0] = nombre;
            //misObjetos[1] = edad;

            //return View("Index", misObjetos);

        }
    }
}
