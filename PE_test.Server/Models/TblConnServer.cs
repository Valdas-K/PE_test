using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblConnServer
{
    public int ConnServerId { get; set; }

    public string Caption { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public bool IsVital { get; set; }

    public DateTime SyncTime { get; set; }

    public string Certificate { get; set; } = null!;

    public virtual ICollection<TblConnProvider> TblConnProviders { get; set; } = new List<TblConnProvider>();
}
