using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ConfigurationComposition
{
    public Guid Id { get; set; }

    public Guid IdModification { get; set; }

    public Guid IdConfiguration { get; set; }

    public virtual Configuration IdConfigurationNavigation { get; set; } = null!;

    public virtual Modification IdModificationNavigation { get; set; } = null!;
}
