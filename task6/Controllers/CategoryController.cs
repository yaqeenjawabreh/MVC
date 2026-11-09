using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task6.Data;
using task6.Models;

namespace task6.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.Include(c=>c.Products).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {   
            
              
                _context.Categories.Add(category);
                _context.SaveChanges();
            
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
         {
            if (category != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }


        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            
            return RedirectToAction("index");
        }
    }
}
