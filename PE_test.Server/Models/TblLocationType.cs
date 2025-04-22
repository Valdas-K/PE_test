using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblLocationType
{
    public byte LocationTypeId { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<TblLocation> TblLocations { get; set; } = new List<TblLocation>();
}
