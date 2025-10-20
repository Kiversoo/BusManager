using Microsoft.AspNetCore.Mvc;         
using BusManager.Data;                   
using BusManager.Models;                 
using System.Linq;                       

namespace BusManager.Controllers
{
    public class SparePartController : Controller
    {
        private readonly AppDbContext _context;

        public SparePartController(AppDbContext context)
        {
            _context = context;
        }

        // 📋 Список запчастей
        public IActionResult Index()
        {
            var parts = _context.SpareParts.ToList();
            return View(parts);
        }

        // ➕ Добавить новую
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SparePart part)
        {
            if (ModelState.IsValid)
            {
                _context.SpareParts.Add(part);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // ✏️ Редактировать
        public IActionResult Edit(int id)
        {
            var part = _context.SpareParts.Find(id);
            if (part == null)
                return NotFound();

            return View(part);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SparePart part)
        {
            if (ModelState.IsValid)
            {
                _context.SpareParts.Update(part);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // ❌ Удалить
        public IActionResult Delete(int id)
        {
            var part = _context.SpareParts.Find(id);
            if (part == null)
                return NotFound();

            _context.SpareParts.Remove(part);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }       
    }
}
