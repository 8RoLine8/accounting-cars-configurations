using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Modification> Modifications { get; set; } = new List<Modification>();
}
