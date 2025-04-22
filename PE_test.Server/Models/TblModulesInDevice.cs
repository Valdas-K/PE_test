using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblModulesInDevice
{
    public int ModuleId { get; set; }

    public int DeviceId { get; set; }

    public int ModTid { get; set; }

    public byte? ModuleIndex { get; set; }

    public bool IsDeleted { get; set; }

    public int? LockUserId { get; set; }

    public DateTime? LockTime { get; set; }

    public DateTime? LastParsedRt { get; set; }

    public virtual TblDevice Device { get; set; } = null!;

    public virtual TblUser? LockUser { get; set; }

    public virtual TblModuleType ModT { get; set; } = null!;

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();

    public virtual ICollection<TblDeviceComponent> TblDeviceComponents { get; set; } = new List<TblDeviceComponent>();
}
