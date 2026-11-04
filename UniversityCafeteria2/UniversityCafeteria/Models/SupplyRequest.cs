namespace UniversityCafeteria.Models
{
    public class SupplyRequest
    {
        public int RequestId { get; set; }
        public List<SupplyItem> Items { get; set; } = new();
        public decimal Subtotal { get; set; }
        public decimal PreparationFee { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalTotal { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }


    }
}
