using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ConfigurationSet
{
    public Guid Id { get; set; }

    public Guid IdCar { get; set; }

    public Guid IdConfiguration { get; set; }

    public virtual Car IdCarNavigation { get; set; } = null!;

    public virtual Configuration IdConfigurationNavigation { get; set; } = null!;
}
