using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDeviceComponent
{
    public int DevCompId { get; set; }

    public int DeviceId { get; set; }

    public int ComponentId { get; set; }

    public string Caption { get; set; } = null!;

    public int? SerialNo { get; set; }

    public string? Code { get; set; }

    public string? SerialNoStr { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? LastParsedRt { get; set; }

    public int? ModuleId { get; set; }

    public virtual CmpHeatMetersValLast? CmpHeatMetersValLast { get; set; }

    public virtual CmpPressuresValLast? CmpPressuresValLast { get; set; }

    public virtual ICollection<CmpPressuresVal> CmpPressuresVals { get; set; } = new List<CmpPressuresVal>();

    public virtual TblComponent Component { get; set; } = null!;

    public virtual TblDevice Device { get; set; } = null!;

    public virtual TblModulesInDevice? Module { get; set; }

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();
}
