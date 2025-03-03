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
            apiUrl = "/api/Concesionarios";
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.titulo = "Lista de coches";
            var coches = await httpClient.GetFromJsonAsync<IEnumerable<Concesionario>>($"{apiUrl}");
            return View(coches);
        }

    }
}
