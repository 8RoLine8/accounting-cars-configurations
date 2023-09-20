using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveModel
{
    public Guid? Id { get; set; }

    public Guid? IdManufacturer { get; set; }

    public string? Name { get; set; }
}
