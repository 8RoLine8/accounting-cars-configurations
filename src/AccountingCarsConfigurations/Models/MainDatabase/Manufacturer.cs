using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Manufacturer
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Info { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
