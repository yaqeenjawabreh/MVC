using System;
using System.Collections.Generic;

namespace AcademyGraduationCeremonySupplyManagementSystem.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
