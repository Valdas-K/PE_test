using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class CmpHeatMetersVal
{
    public long RecordId { get; set; }

    public DateTime RecordTime { get; set; }

    public int DevCompId { get; set; }

    public int? SerialNo { get; set; }

    public decimal? Energy { get; set; }

    public decimal? Volume { get; set; }

    public decimal? WorkTime { get; set; }

    public decimal? Tflow { get; set; }

    public decimal? Tret { get; set; }

    public decimal? OnTime { get; set; }

    public decimal? NonworkTime { get; set; }

    public int? ErrorCode { get; set; }

    public decimal? DT { get; set; }

    public decimal? Power { get; set; }

    public decimal? Flow { get; set; }

    public decimal? EnergyHs { get; set; }

    public decimal? EnergyHw { get; set; }

    public decimal? VolumeHs { get; set; }

    public decimal? VolumeHw { get; set; }

    public decimal? TflowHs { get; set; }

    public decimal? TflowHw { get; set; }

    public decimal? TretHs { get; set; }

    public decimal? TretHw { get; set; }

    public decimal? VolumeAdd { get; set; }

    public decimal? PowerHs { get; set; }

    public decimal? PowerHw { get; set; }

    public decimal? FlowHs { get; set; }

    public decimal? FlowHw { get; set; }

    public decimal? WorkTime2 { get; set; }

    public int? ErrorCode1 { get; set; }

    public int? ErrorCode2 { get; set; }

    public decimal? Mass { get; set; }

    public float? Duration1 { get; set; }

    public float? Duration2 { get; set; }

    public float? Duration3 { get; set; }

    public DateTime? DeviceTime { get; set; }

    public DateTime? MeterTime { get; set; }

    public float? FlowMass { get; set; }

    public virtual TblDeviceComponent DevComp { get; set; } = null!;
}
