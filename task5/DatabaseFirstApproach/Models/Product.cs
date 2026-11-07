using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Categorie? Category { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier? Supplier { get; set; }
}
