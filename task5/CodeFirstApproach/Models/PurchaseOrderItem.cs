namespace CodeFirstApproach.Models
{
    public class PurchaseOrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }


    }
}
