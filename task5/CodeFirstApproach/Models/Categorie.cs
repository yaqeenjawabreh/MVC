using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class Categorie
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
