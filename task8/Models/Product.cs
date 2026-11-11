namespace task8.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public int Quantity { set; get; }
        public ICollection<RequestItem> RequestItems { get; set; }
    }
}
