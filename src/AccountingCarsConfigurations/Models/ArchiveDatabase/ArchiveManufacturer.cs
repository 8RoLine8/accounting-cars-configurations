using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveManufacturer
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public string? Info { get; set; }
}
