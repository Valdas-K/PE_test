using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblRequestPriority
{
    public byte RequestPriorityId { get; set; }

    public string Keyword { get; set; } = null!;

    public virtual ICollection<TblDevice> TblDevices { get; set; } = new List<TblDevice>();
}
