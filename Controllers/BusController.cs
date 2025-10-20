using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusManager.Data;
using BusManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BusManager.Controllers
{
    public class BusController : Controller
    {
        private readonly AppDbContext _context;

        public BusController(AppDbContext context)
        {
            _context = context;
        }

        // 📋 Список автобусов
        public IActionResult Index()
        {
            var buses = _context.Buses
                .Include(b => b.Driver)
                .Include(b => b.Route)
                .ToList();
            return View(buses);
        }
        
        // ➕ GET: Создать
        public IActionResult Create()
        {
            ViewBag.DriverId = new SelectList(_context.Drivers.OrderBy(d => d.Name), "Id", "Name");
            ViewBag.RouteId = new SelectList(_context.BusRoutes.OrderBy(r => r.Name), "Id", "Name");
            return View();
        }

        // ➕ POST: Создать
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DriverId = new SelectList(_context.Drivers.OrderBy(d => d.Name), "Id", "Name", bus.DriverId);
                ViewBag.RouteId = new SelectList(_context.BusRoutes.OrderBy(r => r.Name), "Id", "Name", bus.RouteId);
                return View(bus);
            }

            _context.Buses.Add(bus);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // ✏️ GET: Редактировать
        public IActionResult Edit(int id)
        {
            var bus = _context.Buses.Find(id);
            if (bus == null)
                return NotFound();

            ViewBag.DriverId = new SelectList(_context.Drivers.OrderBy(d => d.Name), "Id", "Name", bus.DriverId);
            ViewBag.RouteId = new SelectList(_context.BusRoutes.OrderBy(r => r.Name), "Id", "Name", bus.RouteId);
            return View(bus);
        }

        // ✏️ POST: Редактировать
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DriverId = new SelectList(_context.Drivers.OrderBy(d => d.Name), "Id", "Name", bus.DriverId);
                ViewBag.RouteId = new SelectList(_context.BusRoutes.OrderBy(r => r.Name), "Id", "Name", bus.RouteId);
                return View(bus);
            }

            _context.Buses.Update(bus);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // ❌ GET: Удалить (страница подтверждения)
        public IActionResult Delete(int id)
        {
            var bus = _context.Buses
                .Include(b => b.Driver)
                .Include(b => b.Route)
                .FirstOrDefault(b => b.Id == id);

            if (bus == null)
                return NotFound();

            return View(bus);
        }

        // ❌ POST: Удалить подтверждённое действие
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bus = _context.Buses.Find(id);
            if (bus != null)
            {
                _context.Buses.Remove(bus);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
