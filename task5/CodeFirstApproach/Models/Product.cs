namespace CodeFirstApproach.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Categorie Categorie { get; set; }
        public int CategorieId { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    }
}
