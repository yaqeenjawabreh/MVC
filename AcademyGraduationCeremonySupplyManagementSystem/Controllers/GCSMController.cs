using Microsoft.AspNetCore.Mvc;

namespace AcademyGraduationCeremonySupplyManagementSystem.Controllers
{
    public class GCSMController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SupplyRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SupplyRequest(string certificate, string hospitality, string gift)
        {
            // نحفظ فقط اللي اختاره، عشان ما نمسح اختيار سابق
            if (!string.IsNullOrEmpty(certificate))
                HttpContext.Session.SetString("Certificate", certificate);

            if (!string.IsNullOrEmpty(hospitality))
                HttpContext.Session.SetString("Hospitality", hospitality);

            if (!string.IsNullOrEmpty(gift))
                HttpContext.Session.SetString("Gift", gift);

            return RedirectToAction("SelectedOffers");
        }

        public IActionResult SelectedOffers()
        {
            string? c = HttpContext.Session.GetString("Certificate");
            string? h = HttpContext.Session.GetString("Hospitality");
            string? g = HttpContext.Session.GetString("Gift");

            if (c != null) FillOffer(c, "C");
            if (h != null) FillOffer(h, "H");
            if (g != null) FillOffer(g, "G");

            return View();
        }

        public IActionResult ReviewRequest()
        {
            string? c = HttpContext.Session.GetString("Certificate");
            string? h = HttpContext.Session.GetString("Hospitality");
            string? g = HttpContext.Session.GetString("Gift");

            // لازم الثلاثة يكونوا مختارين
            if (c == null || h == null || g == null)
            {
                TempData["Error"] = "You must select one offer from each category before reviewing.";
                return RedirectToAction("SupplyRequest");
            }

            double totalPrice = FillOffer(c, "C") + FillOffer(h, "H") + FillOffer(g, "G");

            double discountPercentage;
            if (totalPrice > 500)
                discountPercentage = 0.15;
            else if (totalPrice > 300)
                discountPercentage = 0.10;
            else
                discountPercentage = 0;

            double discountAmount = totalPrice * discountPercentage;
            double finalTotal = totalPrice - discountAmount;

            ViewBag.TotalPrice = totalPrice;
            ViewBag.DiscountPercentage = discountPercentage * 100;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View();
        }

        // تجيب بيانات العرض حسب الحرف، وتحطها في ViewData، وترجع إجمالي العرض
        private double FillOffer(string code, string prefix)
        {
            string supplier = "", offer = "";
            int quantity = 0;
            double unitPrice = 0;

            switch (code)
            {
                case "A": supplier = "Supplier A"; offer = "Premium Certificate Package"; quantity = 35; unitPrice = 2; break;
                case "B": supplier = "Supplier B"; offer = "Standard Certificate Package"; quantity = 35; unitPrice = 1.5; break;
                case "C": supplier = "Supplier C"; offer = "Luxury Certificate Package"; quantity = 35; unitPrice = 2.5; break;
                case "D": supplier = "Supplier D"; offer = "Coffee & Drinks Package"; quantity = 100; unitPrice = 2; break;
                case "E": supplier = "Supplier E"; offer = "Sandwiches & Snacks Package"; quantity = 100; unitPrice = 3; break;
                case "F": supplier = "Supplier F"; offer = "Full Hospitality Package"; quantity = 100; unitPrice = 4; break;
                case "G": supplier = "Supplier G"; offer = "Customized Mugs Package"; quantity = 35; unitPrice = 2; break;
                case "H": supplier = "Supplier H"; offer = "Graduation Bags Package"; quantity = 35; unitPrice = 3; break;
                case "I": supplier = "Supplier I"; offer = "Premium Gift Boxes Package"; quantity = 35; unitPrice = 4; break;
            }

            double total = quantity * unitPrice;

            ViewData[prefix + "Supplier"] = supplier;
            ViewData[prefix + "Offer"] = offer;
            ViewData[prefix + "Quantity"] = quantity;
            ViewData[prefix + "UnitPrice"] = unitPrice;
            ViewData[prefix + "Total"] = total;

            return total;
        }
    }
}