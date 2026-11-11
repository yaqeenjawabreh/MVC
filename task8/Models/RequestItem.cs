namespace task8.Models
{
    public class RequestItem
    {
        public int Id { set; get; }

        public int ProductId { set; get; }
        public Product Product { set; get; }

        public int SupplyRequestId { set; get; }
        public SupplyRequest SupplyRequest { set; get; }

        public int Quantity { set; get; }
        public double Price { set; get; }
    }
}
