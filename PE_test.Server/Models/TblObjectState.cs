using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblObjectState
{
    public byte ObjectStateId { get; set; }

    public string Keyword { get; set; } = null!;

    public bool OnThirdParty { get; set; }

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}
