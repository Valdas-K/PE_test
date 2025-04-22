using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblMemoryType
{
    public short MemoryTypeId { get; set; }

    public string Caption { get; set; } = null!;

    public byte ArrayFirstBlock { get; set; }

    public byte ArrayLastBlock { get; set; }

    public virtual ICollection<TblDevice> TblDeviceMemoryFlashNavigations { get; set; } = new List<TblDevice>();

    public virtual ICollection<TblDevice> TblDeviceMemorySramNavigations { get; set; } = new List<TblDevice>();
}
