using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveModification
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }
}
