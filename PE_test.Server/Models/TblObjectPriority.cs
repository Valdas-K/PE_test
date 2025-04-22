using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblObjectPriority
{
    public int ObjectPriorityId { get; set; }

    public int MaxTaskDuration { get; set; }

    public virtual ICollection<TblObject> TblObjects { get; set; } = new List<TblObject>();
}
