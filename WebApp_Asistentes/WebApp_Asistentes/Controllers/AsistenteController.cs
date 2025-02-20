using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Asistentes.Models;

namespace WebApp_Asistentes.Controllers
{
    public class AsistenteController : Controller
    {
        private readonly AsistentesDbContext _context;

        public AsistenteController()
        {
            _context = new AsistentesDbContext();
        }
        
        // GET: AsistentesContoller
        public async Task<IActionResult> Index()
        {
            List<Asistente> asistentes = await _context.Asistentes.ToListAsync();
            return View(asistentes);
        }

        // GET: AsistentesContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsistentesContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsistentesContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AsistentesContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsistentesContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AsistentesContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsistentesContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
