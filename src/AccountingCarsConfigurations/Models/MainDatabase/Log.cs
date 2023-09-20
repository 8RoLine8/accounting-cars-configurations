using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class Log
{
    public Guid Id { get; set; }

    public DateTime ActionsDate { get; set; }

    public string Action { get; set; } = null!;

    public string Actor { get; set; } = null!;
}
