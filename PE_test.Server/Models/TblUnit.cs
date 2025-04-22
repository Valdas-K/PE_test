using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblUnit
{
    public int UnitId { get; set; }

    public string Keyword { get; set; } = null!;

    public byte? MbusDimensionId { get; set; }

    public virtual TblMbusDimension? MbusDimension { get; set; }

    public virtual ICollection<TblComponentValue> TblComponentValues { get; set; } = new List<TblComponentValue>();

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();
}
