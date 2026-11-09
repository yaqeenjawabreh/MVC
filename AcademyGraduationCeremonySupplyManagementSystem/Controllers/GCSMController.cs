using AcademyGraduationCeremonySupplyManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyGraduationCeremonySupplyManagementSystem.Controllers
{
    public class GCSMController : Controller
    {
        static List<OfferNew> offers = new List<OfferNew>
        {
            new OfferNew { OfferId = 1, Category = "GraduationCertificates", Supply = "Supplier A", OfferName = "Premium Certificate Package",  Quantity = 35,  UnitPrice = 2 },
            new OfferNew { OfferId = 2, Category = "GraduationCertificates", Supply = "Supplier B", OfferName = "Standard Certificate Package", Quantity = 35,  UnitPrice = 1.5 },
            new OfferNew { OfferId = 3, Category = "GraduationCertificates", Supply = "Supplier C", OfferName = "Luxury Certificate Package",   Quantity = 35,  UnitPrice = 2.5 },
            new OfferNew { OfferId = 4, Category = "Hospitality",            Supply = "Supplier D", OfferName = "Coffee & Drinks Package",      Quantity = 100, UnitPrice = 2 },
            new OfferNew { OfferId = 5, Category = "Hospitality",            Supply = "Supplier E", OfferName = "Sandwiches & Snacks Package",  Quantity = 100, UnitPrice = 3 },
            new OfferNew { OfferId = 6, Category = "Hospitality",            Supply = "Supplier F", OfferName = "Full Hospitality Package",     Quantity = 100, UnitPrice = 4 },
            new OfferNew { OfferId = 7, Category = "GraduationGifts",        Supply = "Supplier G", OfferName = "Customized Mugs Package",      Quantity = 35,  UnitPrice = 2 },
            new OfferNew { OfferId = 8, Category = "GraduationGifts",        Supply = "Supplier H", OfferName = "Graduation Bags Package",      Quantity = 35,  UnitPrice = 3 },
            new OfferNew { OfferId = 9, Category = "GraduationGifts",        Supply = "Supplier I", OfferName = "Premium Gift Boxes Package",   Quantity = 35,  UnitPrice = 4 }
        };

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SupplyRequest()
        {
            return View(offers);
        }

        public IActionResult SelectedOffers(int id)
        {
            ViewBag.OfferId = id;

            var offer = offers.FirstOrDefault(x => x.OfferId == id);

            if (offer == null)
            {
                return RedirectToAction("SupplyRequest");
            }

            var categoryName = "";
            if (offer.Category == "GraduationCertificates")
            {
                categoryName = "GraduationCertificates";
            }
            else if (offer.Category == "Hospitality")
            {
                categoryName = "Hospitality";
            }
            else if (offer.Category == "GraduationGifts")
            {
                categoryName = "GraduationGifts";
            }

            HttpContext.Session.SetString(
                categoryName,
                System.Text.Json.JsonSerializer.Serialize(offer)
            );

            return View(offer);
        }

        public IActionResult ReviewRequest()
        {
            string? certificateJson = HttpContext.Session.GetString("GraduationCertificates");
            string? hospitalityJson = HttpContext.Session.GetString("Hospitality");
            string? giftsJson = HttpContext.Session.GetString("GraduationGifts");

            if (certificateJson == null || hospitalityJson == null || giftsJson == null)
            {
                TempData["Error"] = "You must select one offer from each category before reviewing.";
                return RedirectToAction("SupplyRequest");
            }

            var GraduationCertificates = System.Text.Json.JsonSerializer.Deserialize<OfferNew>(certificateJson);
            var Hospitality = System.Text.Json.JsonSerializer.Deserialize<OfferNew>(hospitalityJson);
            var GraduationGifts = System.Text.Json.JsonSerializer.Deserialize<OfferNew>(giftsJson);

            var newOfferList = new List<OfferNew>
            { GraduationCertificates, Hospitality, GraduationGifts };

            decimal total = 0;
            foreach (var item in newOfferList)
            {
                item.Total = item.Quantity * (decimal)item.UnitPrice;
                total += item.Total;
            }

            decimal discountPercentage;
            if (total > 500)
                discountPercentage = 0.15m;
            else if (total > 300)
                discountPercentage = 0.10m;
            else
                discountPercentage = 0;

            decimal discountAmount = total * discountPercentage;
            decimal finalTotal = total - discountAmount;

            ViewBag.Total = total;
            ViewBag.DiscountPercentage = discountPercentage * 100;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View(newOfferList);
        }
    }
}