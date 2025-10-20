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

        public IActionResult Index()
        {
            var routes = _context.BusRoutes.ToList();
            return View(routes);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusRoute route, IFormFile mapImage)
        {
            if (ModelState.IsValid)
            {
                if (mapImage != null && mapImage.Length > 0)
                {
                    var fileName = Path.GetFileName(mapImage.FileName);
                    var path = Path.Combine("wwwroot/uploads", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        mapImage.CopyTo(stream);
                    }
                    route.MapImagePath = "/uploads/" + fileName;
                }

                _context.BusRoutes.Add(route);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(route);
        }

        public IActionResult Edit(int id)
        {
            var route = _context.BusRoutes.Find(id);
            if (route == null) return NotFound();
            return View(route);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BusRoute route, IFormFile mapImage)
        {
            if (ModelState.IsValid)
            {
                if (mapImage != null && mapImage.Length > 0)
                {
                    var fileName = Path.GetFileName(mapImage.FileName);
                    var path = Path.Combine("wwwroot/uploads", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        mapImage.CopyTo(stream);
                    }
                    route.MapImagePath = "/uploads/" + fileName;
                }

                _context.BusRoutes.Update(route);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // ✅ вот этот метод открывает страницу подтверждения удаления
        public IActionResult Delete(int id)
        {
            var route = _context.BusRoutes.Find(id);
            if (route == null) return NotFound();
            return View(route);
        }

        // ✅ а этот реально удаляет маршрут
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var route = _context.BusRoutes.Find(id);
            if (route == null) return NotFound();

            _context.BusRoutes.Remove(route);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
