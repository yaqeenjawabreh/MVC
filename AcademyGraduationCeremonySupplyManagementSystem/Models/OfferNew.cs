namespace AcademyGraduationCeremonySupplyManagementSystem.Models
{
    public class OfferNew
    {
        public int OfferId { get; set; }
        public string Category { get; set; }
        public string Supply { get; set; }

        public string OfferName { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}
