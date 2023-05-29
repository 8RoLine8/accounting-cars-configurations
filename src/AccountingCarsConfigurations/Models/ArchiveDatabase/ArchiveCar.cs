using System;
using System.Collections.Generic;

namespace AccountingCarsConfigurations.Models;

public partial class ArchiveCar
{
    public Guid? Id { get; set; }

    public Guid? IdModel { get; set; }

    public Guid? IdBodyType { get; set; }

    public int? ProductionYear { get; set; }
}
