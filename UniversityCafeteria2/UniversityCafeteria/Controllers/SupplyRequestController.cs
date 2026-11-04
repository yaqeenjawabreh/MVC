using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Controllers
{
    public class SupplyRequestController : Controller
    {
        private List<SupplyItem> GetDraft()
        {
            var json = HttpContext.Session.GetString("Draft");
            return json == null ? new List<SupplyItem>() : JsonSerializer.Deserialize<List<SupplyItem>>(json);
        }

        private void SaveDraft(List<SupplyItem> items)
        {
            HttpContext.Session.SetString("Draft", JsonSerializer.Serialize(items));
        }
        private static List<SupplyRequest> supplyRequests = new List<SupplyRequest>();
        public IActionResult Index()
        {

            ViewBag.Draft = GetDraft();
            ViewBag.Preferred = Request.Cookies["PreferredPriority"];
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(SupplyItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.ProductName))
            {
                TempData["msg"] = "Please enter a product name.";
                return RedirectToAction("Index");
            }
            if (string.IsNullOrWhiteSpace(item.Category) || string.IsNullOrWhiteSpace(item.Priority))
            {
                TempData["msg"] = "Please fill in all required fields.";
                return RedirectToAction("Index");
            }
            if (item.Quantity <= 0 || item.UnitPrice <= 0)
            {
                TempData["msg"] = "Quantity and Unit Price must be greater than zero.";
                return RedirectToAction("Index");
            }


            var draft = GetDraft();       
            draft.Add(item);              
            SaveDraft(draft);              

            TempData["msg"] = "Item added successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Review()
        {
            var draft = GetDraft();

            if (draft.Count == 0)
            {
                TempData["msg"] = "Your supply request is empty.";
                return RedirectToAction("Index");
            }

            ViewBag.Request = CalculateRequest(draft);
            return View();
        }
        [HttpPost]
        public IActionResult ConfirmRequest()
        {
            var draft = GetDraft();

            // 2) ما بنفع يأكد طلب فاضي
            if (draft.Count == 0)
            {
                TempData["msg"] = "You cannot confirm an empty supply request.";
                return RedirectToAction("Index");
            }

            // 3) احسب الطلب وعطيه رقم وحالة
            var request = CalculateRequest(draft);
            request.RequestId = supplyRequests.Count + 1;
            request.Status = "Confirmed";

            // 4) ضيفه للـ static List (الطلبات المؤكدة)
            supplyRequests.Add(request);

            // 5) فضّي السلة من الـ Session
            HttpContext.Session.Remove("Draft");

            TempData["msg"] = "Request #" + request.RequestId + " confirmed successfully.";
            return RedirectToAction("MyRequests");
        
        }
        public IActionResult ClearDraft()
        {
            HttpContext.Session.Remove("Draft");
            TempData["msg"] = "Draft cleared.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SavePreference(string preferredPriority)
        {
            if (string.IsNullOrWhiteSpace(preferredPriority))
            {
                TempData["msg"] = "Please select a priority.";
                return RedirectToAction("Index");
            }

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);   // مدته 7 أيام

            Response.Cookies.Append("PreferredPriority", preferredPriority, options);

            TempData["msg"] = "Preference saved.";
            return RedirectToAction("Index");
        }

        public IActionResult MyRequests()
        {

            ViewBag.Requests = supplyRequests;
            return View();
        }
        public IActionResult About()
        {
            ViewBag.AppName = "University Cafeteria Supply Management System";
            ViewBag.FeatureName = "Supply Request Management";
            ViewBag.Description = "This feature helps cafeteria employees create, manage, review, and calculate supply requests.";
            return View();
        }

        private SupplyRequest CalculateRequest(List<SupplyItem> items)
        {
            var request = new SupplyRequest();
            request.Items = items;

            // 1+2) إجمالي كل منتج والـ Subtotal
            decimal subtotal = 0;
            foreach (var item in items)
            {
                subtotal += item.Total;   // Total = Quantity * UnitPrice
            }
            request.Subtotal = subtotal;

            // تحديد أولوية الطلب (أعلى أولوية بين المنتجات)
            string priority = "Normal";
            foreach (var item in items)
            {
                if (item.Priority == "Emergency")
                    priority = "Emergency";
                else if (item.Priority == "Urgent" && priority != "Emergency")
                    priority = "Urgent";
            }
            request.Priority = priority;

            // 3) رسوم التحضير باستخدام switch
            switch (priority)
            {
                case "Normal":
                    request.PreparationFee = 2;
                    break;
                case "Urgent":
                    request.PreparationFee = 5;
                    break;
                case "Emergency":
                    request.PreparationFee = 10;
                    break;
            }

            // 4) الخصم باستخدام if (لازم 200 قبل 100)
            if (subtotal > 200)
                request.Discount = subtotal * 0.15m;
            else if (subtotal > 100)
                request.Discount = subtotal * 0.10m;
            else
                request.Discount = 0;

            // 5) الإجمالي النهائي
            request.FinalTotal = subtotal + request.PreparationFee - request.Discount;

            return request;
        }
    }
}
