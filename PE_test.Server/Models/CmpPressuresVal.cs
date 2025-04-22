using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class CmpPressuresVal
{
    public long RecordId { get; set; }

    public DateTime RecordTime { get; set; }

    public int DevCompId { get; set; }

    public int? SerialNo { get; set; }

    public float? P00 { get; set; }

    public float? P01 { get; set; }

    public float? P02 { get; set; }

    public float? P03 { get; set; }

    public float? P04 { get; set; }

    public float? P05 { get; set; }

    public float? P06 { get; set; }

    public float? P07 { get; set; }

    public float? P08 { get; set; }

    public float? P09 { get; set; }

    public float? P10 { get; set; }

    public DateTime? DeviceTime { get; set; }

    public DateTime? MeterTime { get; set; }

    public virtual TblDeviceComponent DevComp { get; set; } = null!;
}
