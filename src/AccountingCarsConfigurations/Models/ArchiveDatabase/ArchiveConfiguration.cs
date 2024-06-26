﻿using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveConfiguration
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public bool? Availability { get; set; }
}
