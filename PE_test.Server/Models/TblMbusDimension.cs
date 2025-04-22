using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblMbusDimension
{
    public byte MbusDimensionId { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<TblUnit> TblUnits { get; set; } = new List<TblUnit>();
}
