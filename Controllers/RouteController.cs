using Microsoft.AspNetCore.Mvc;
using BusManager.Data;
using BusManager.Models;

namespace BusManager.Controllers
{
    public class RouteController : Controller
    {
        private readonly AppDbContext _context;

        public RouteController(AppDbContext context)
        {
            _context = context;
        }

        // 📋 Список маршрутов
        public IActionResult Index()
        {
            var routes = _context.Routes?.ToList() ?? new List<BusRoute>();
            return View(routes);
        }

        // ➕ Создание маршрута (страница)
        public IActionResult Create()
        {
            return View();
        }

        // 🧾 POST: Создание маршрута
        [HttpPost]
        public IActionResult Create(BusRoute route)
        {
            if (ModelState.IsValid)
            {
                _context.Routes?.Add(route);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // ✏️ Редактирование маршрута
        public IActionResult Edit(int id)
        {
            var route = _context.Routes?.Find(id);
            if (route == null)
                return NotFound();

            return View(route);
        }

        [HttpPost]
        public IActionResult Edit(BusRoute route)
        {
            if (ModelState.IsValid)
            {
                _context.Routes?.Update(route);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // ❌ Удаление маршрута
        public IActionResult Delete(int id)
        {
            var route = _context.Routes?.Find(id);
            if (route == null)
                return NotFound();

            return View(route);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var route = _context.Routes?.Find(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
