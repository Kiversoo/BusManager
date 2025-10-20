using Microsoft.AspNetCore.Mvc;
using BusManager.Data;
using BusManager.Models;




namespace BusManager.Controllers

{
    public class BusController : Controller
    {
        private readonly AppDbContext _context;

        public BusController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var buses = _context.Buses.ToList();
            return View(buses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Bus bus)
        {
            if (ModelState.IsValid)
            {
                _context.Buses.Add(bus);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }

        public IActionResult Delete(int id)
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
