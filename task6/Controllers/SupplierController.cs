using Microsoft.AspNetCore.Mvc;
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
            var Suppliers = _context.Suppliers.ToList();
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
    }
}
