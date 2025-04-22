using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDeviceType
{
    public int DeviceTypeId { get; set; }

    public string Caption { get; set; } = null!;

    public string? PagePath { get; set; }

    public virtual ICollection<TblDevice> TblDevices { get; set; } = new List<TblDevice>();
}
