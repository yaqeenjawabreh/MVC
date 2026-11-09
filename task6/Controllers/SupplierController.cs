using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task6.Data;
using task6.Models;
namespace task6.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   
            var Suppliers = _context.Suppliers.Include(s=>s.Products).ToList();
            return View(Suppliers);
        }

        [ HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var suppler = _context.Suppliers.Find(id);
            return View(suppler);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int id) {
            var supplier = _context.Suppliers.Find(id);
            return View(supplier);
        }

        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
