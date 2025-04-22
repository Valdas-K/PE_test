using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class CmpPressuresValLast
{
    public int DevCompId { get; set; }

    public float? P00 { get; set; }

    public DateTime? P00Rt { get; set; }

    public float? P01 { get; set; }

    public DateTime? P01Rt { get; set; }

    public float? P02 { get; set; }

    public DateTime? P02Rt { get; set; }

    public float? P03 { get; set; }

    public DateTime? P03Rt { get; set; }

    public float? P04 { get; set; }

    public DateTime? P04Rt { get; set; }

    public float? P05 { get; set; }

    public DateTime? P05Rt { get; set; }

    public float? P06 { get; set; }

    public DateTime? P06Rt { get; set; }

    public float? P07 { get; set; }

    public DateTime? P07Rt { get; set; }

    public float? P08 { get; set; }

    public DateTime? P08Rt { get; set; }

    public float? P09 { get; set; }

    public DateTime? P09Rt { get; set; }

    public float? P10 { get; set; }

    public DateTime? P10Rt { get; set; }

    public virtual TblDeviceComponent DevComp { get; set; } = null!;
}
