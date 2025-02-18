using Microsoft.AspNetCore.Mvc;
using App_Alumnos.Controllers;
using App_Alumnos.Models;


namespace App_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly AlumnoRepository _repo;

        public AlumnoController()
        {
            _repo = new AlumnoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var alumnos = await _repo.ReadAll();
            return View(alumnos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                await _repo.Create(alumno);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Alumno? alumno = await _repo.Read(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var alumno = await _repo.Read(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                await _repo.Update(alumno);
                return RedirectToAction(nameof(Index));
            }
            return View(alumno) ;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var alumno = await _repo.Read(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }


    }
}
