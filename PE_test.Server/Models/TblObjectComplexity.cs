using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblObjectComplexity
{
    public int ObjectComplexityId { get; set; }

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}
