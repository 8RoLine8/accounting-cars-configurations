using AccountingCarsConfigurations.Models;
using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Car
{
    public Guid Id { get; set; }

    public Guid IdModel { get; set; }

    public Guid IdBodyType { get; set; }

    public int ProductionYear { get; set; }

    public virtual ICollection<ConfigurationSet> ConfigurationSets { get; set; } = new List<ConfigurationSet>();

    public virtual BodyType IdBodyTypeNavigation { get; set; } = null!;

    public virtual Model IdModelNavigation { get; set; } = null!;
}
