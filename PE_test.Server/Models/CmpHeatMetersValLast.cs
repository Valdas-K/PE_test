using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class CmpHeatMetersValLast
{
    public int DevCompId { get; set; }

    public decimal? Energy { get; set; }

    public DateTime? EnergyRt { get; set; }

    public decimal? Volume { get; set; }

    public DateTime? VolumeRt { get; set; }

    public decimal? WorkTime { get; set; }

    public DateTime? WorkTimeRt { get; set; }

    public decimal? Tflow { get; set; }

    public DateTime? TflowRt { get; set; }

    public decimal? Tret { get; set; }

    public DateTime? TretRt { get; set; }

    public decimal? OnTime { get; set; }

    public DateTime? OnTimeRt { get; set; }

    public decimal? NonworkTime { get; set; }

    public DateTime? NonworkTimeRt { get; set; }

    public int? ErrorCode { get; set; }

    public DateTime? ErrorCodeRt { get; set; }

    public decimal? DT { get; set; }

    public DateTime? DTRt { get; set; }

    public decimal? Power { get; set; }

    public DateTime? PowerRt { get; set; }

    public decimal? Flow { get; set; }

    public DateTime? FlowRt { get; set; }

    public decimal? EnergyHs { get; set; }

    public DateTime? EnergyHsRt { get; set; }

    public decimal? EnergyHw { get; set; }

    public DateTime? EnergyHwRt { get; set; }

    public decimal? VolumeHs { get; set; }

    public DateTime? VolumeHsRt { get; set; }

    public decimal? VolumeHw { get; set; }

    public DateTime? VolumeHwRt { get; set; }

    public decimal? TflowHs { get; set; }

    public DateTime? TflowHsRt { get; set; }

    public decimal? TflowHw { get; set; }

    public DateTime? TflowHwRt { get; set; }

    public decimal? TretHs { get; set; }

    public DateTime? TretHsRt { get; set; }

    public decimal? TretHw { get; set; }

    public DateTime? TretHwRt { get; set; }

    public decimal? VolumeAdd { get; set; }

    public DateTime? VolumeAddRt { get; set; }

    public decimal? PowerHs { get; set; }

    public DateTime? PowerHsRt { get; set; }

    public decimal? PowerHw { get; set; }

    public DateTime? PowerHwRt { get; set; }

    public decimal? FlowHs { get; set; }

    public DateTime? FlowHsRt { get; set; }

    public decimal? FlowHw { get; set; }

    public DateTime? FlowHwRt { get; set; }

    public decimal? WorkTime2 { get; set; }

    public DateTime? WorkTime2Rt { get; set; }

    public int? ErrorCode1 { get; set; }

    public DateTime? ErrorCode1Rt { get; set; }

    public int? ErrorCode2 { get; set; }

    public DateTime? ErrorCode2Rt { get; set; }

    public decimal? Mass { get; set; }

    public DateTime? MassRt { get; set; }

    public float? Duration1 { get; set; }

    public DateTime? Duration1Rt { get; set; }

    public float? Duration2 { get; set; }

    public DateTime? Duration2Rt { get; set; }

    public float? Duration3 { get; set; }

    public DateTime? Duration3Rt { get; set; }

    public float? FlowMass { get; set; }

    public DateTime? FlowMassRt { get; set; }

    public virtual TblDeviceComponent DevComp { get; set; } = null!;
}
