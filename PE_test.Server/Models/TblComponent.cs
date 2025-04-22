using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblComponent
{
    public int ComponentId { get; set; }

    public string Keyword { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public bool IsHouseMeter { get; set; }

    public bool IsFlatMeter { get; set; }

    public bool DeviceTimePreference { get; set; }

    public double? MaxTimeGap { get; set; }

    public short SortOrder { get; set; }

    public virtual ICollection<TblComponentValue> TblComponentValues { get; set; } = new List<TblComponentValue>();

    public virtual ICollection<TblDeviceComponent> TblDeviceComponents { get; set; } = new List<TblDeviceComponent>();
}
