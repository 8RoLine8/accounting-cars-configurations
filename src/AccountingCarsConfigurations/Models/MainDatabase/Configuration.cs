using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Configuration
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? Availability { get; set; }

    public virtual ICollection<ConfigurationComposition> ConfigurationCompositions { get; set; } = new List<ConfigurationComposition>();

    public virtual ICollection<ConfigurationSet> ConfigurationSets { get; set; } = new List<ConfigurationSet>();
}
