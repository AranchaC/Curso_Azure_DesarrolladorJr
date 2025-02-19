using System.Diagnostics;
using App_Alumnos.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Alumnos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Alumno");
        }
    }
}