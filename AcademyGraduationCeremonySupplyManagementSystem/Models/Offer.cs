using System;
using System.Collections.Generic;

namespace AcademyGraduationCeremonySupplyManagementSystem.Models;

public partial class Offer
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public string OfferName { get; set; } = null!;

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
