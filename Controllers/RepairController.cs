using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusManager.Data;
using BusManager.Models;

namespace BusManager.Controllers
{
    public class RepairController : Controller
    {
        private readonly AppDbContext _context;
        public RepairController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            var repairs = _context.Repairs
                 .Include(r => r.Bus) // подгружаем связанные автобусы
                 .ToList();
             return View(repairs);
        }

        public IActionResult Create()
        {
            ViewBag.Buses = new SelectList(_context.Buses.ToList(), "Id", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Repairs.Add(repair);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Buses = new SelectList(_context.Buses.ToList(), "Id", "Number", repair.BusId);
            return View(repair);
        }

        // ====== EDIT ======
        public IActionResult Edit(int id)
        {
            var repair = _context.Repairs.Find(id);
            if (repair == null) return NotFound();

            ViewBag.Buses = new SelectList(_context.Buses.ToList(), "Id", "Number", repair.BusId);
            return View(repair);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Repairs.Update(repair);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Buses = new SelectList(_context.Buses.ToList(), "Id", "Number", repair.BusId);
            return View(repair);
        }

        // ====== DELETE ======
        public IActionResult Delete(int id)
        {
            var repair = _context.Repairs.Find(id);
            if (repair == null) return NotFound();
            return View(repair);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var repair = _context.Repairs.Find(id);
            if (repair != null)
            {
                _context.Repairs.Remove(repair);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
