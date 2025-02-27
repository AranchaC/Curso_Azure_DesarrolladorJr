using Microsoft.AspNetCore.Mvc;
using WebAppi_Almacenes.Models;

namespace MVC_Almacen.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;

        public AlmacenController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("AlmacenApi");
            apiUrl = "Api/Almacenes";
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.titulo = "LISTA DE ALMACENES";
            var almacenes = await httpClient.GetFromJsonAsync<IEnumerable<Almacen>>($"{apiUrl}/ReadAll");
            return View(almacenes);
        }
    }
}
