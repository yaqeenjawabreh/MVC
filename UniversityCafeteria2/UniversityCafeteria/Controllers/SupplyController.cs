using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            string[] Categories = { "Drinks", "Food","Snacks" , "Hot Drinks","Cold Drinks" };
            ViewBag.Categories = Categories;
            return View();
        }
        public IActionResult Products()
        {
            ViewData["PageTitle"] = "Cafeteria Products";
            ViewData["ManagerName"] = "Ahmad Ali";
            ViewData["NumberOfProducts"] = 5;
            string[] products = { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };
            ViewData["Products"] = products;
            return View();
        }
        public IActionResult Suppliers()
        {
            ViewBag.PageTitle = "Our Suppliers";
            ViewBag.NumberOfSuppliers = 3;
            string[] Companys = { "Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company" };
            ViewBag.Companys = Companys;
            return View();
        }
        [HttpGet]
        public IActionResult CreateRequest()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SubmitRequest()
        {   
            string employeeName = Request.Form["EmployeeName"];
            
            
            string productName = Request.Form["productName"];
            int quantity = int.Parse(Request.Form["quantity"]);
            DateTime requiredDate = DateTime.Parse(Request.Form["RequiredDate"]);
            if (string.IsNullOrEmpty(employeeName))
            {
                TempData["ErrorMessage"] = "Employee Name is required.";
                return RedirectToAction("CreateRequest");
            }
            else
            {
                TempData["SuccessMessage"] = $"Request submitted successfully for {quantity} units of {productName} by {employeeName}, required by {requiredDate.ToShortDateString()}.";
                return RedirectToAction("About");
            }
        }
        public IActionResult About()
        {
            return View();
        }
       
    }
}
