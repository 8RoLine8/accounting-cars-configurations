using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveLog
{
    public Guid? Id { get; set; }

    public DateTime? ActionsDate { get; set; }

    public string? Action { get; set; }

    public string? Actor { get; set; }
}
