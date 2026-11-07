using System;
using System.Collections.Generic;

namespace AcademyGraduationCeremonySupplyManagementSystem.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Offer? Offer { get; set; }
}
