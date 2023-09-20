using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveConfigurationSet
{
    public Guid? Id { get; set; }

    public Guid? IdCar { get; set; }

    public Guid? IdConfiguration { get; set; }
}
