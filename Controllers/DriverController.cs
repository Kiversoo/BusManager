using Microsoft.AspNetCore.Mvc;
using BusManager.Data;
using BusManager.Models;

namespace BusManager.Controllers
{
    public class DriverController : Controller
    {
        private readonly AppDbContext _context;

        public DriverController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Driver
        public IActionResult Index()
        {
            var drivers = _context.Drivers.ToList();
            return View(drivers);
        }

        // GET: /Driver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Driver/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Drivers.Add(driver);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: /Driver/Edit/5
        public IActionResult Edit(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
                return NotFound();

            return View(driver);
        }

        // POST: /Driver/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Drivers.Update(driver);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: /Driver/Delete/5
        public IActionResult Delete(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
                return NotFound();

            _context.Drivers.Remove(driver);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
