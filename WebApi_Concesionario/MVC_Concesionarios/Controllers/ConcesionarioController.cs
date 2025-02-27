using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Concesionarios.Models;
using WebApi_Concesionario.Models;


namespace MVC_Concesionarios.Controllers
{
    public class ConcesionarioController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;

        public ConcesionarioController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("ConcesionarioApi");
            apiUrl = "/api/Concesionarios/Lista de Almacenes";
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.titulo = "Lista de coches";
            var coches = await httpClient.GetFromJsonAsync<IEnumerable<Concesionario>>($"{apiUrl}/Lista%20de%20Almacenes");
            return View(coches);
        }

    }
}
