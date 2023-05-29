using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Model
{
    public Guid Id { get; set; }

    public Guid IdManufacturer { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;
}
