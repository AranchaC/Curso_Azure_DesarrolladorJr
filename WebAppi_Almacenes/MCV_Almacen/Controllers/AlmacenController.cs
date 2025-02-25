using Microsoft.AspNetCore.Mvc;

namespace MVC_Almacen.Controllers
{
    public class AlmacenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
