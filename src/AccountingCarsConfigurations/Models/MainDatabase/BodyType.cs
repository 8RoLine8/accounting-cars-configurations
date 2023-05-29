using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class BodyType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
