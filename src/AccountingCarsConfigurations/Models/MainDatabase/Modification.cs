using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Modification
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid IdCategory { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<ConfigurationComposition> ConfigurationCompositions { get; set; } = new List<ConfigurationComposition>();

    public virtual Category IdCategoryNavigation { get; set; } = null!;
}
