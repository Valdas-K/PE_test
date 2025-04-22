using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblModuleType
{
    public int ModTid { get; set; }

    public string ModuleName { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public int Number { get; set; }

    public string ModuleIcon { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsFinished { get; set; }

    public bool AlwaysWriteClv { get; set; }

    public bool IsSystem { get; set; }

    public bool IsMbus { get; set; }

    public string? Manufacture { get; set; }

    public bool IsCoreModule { get; set; }

    public int? ConfigPacketSize { get; set; }

    public virtual TblManufacture? ManufactureNavigation { get; set; }

    public virtual ICollection<TblModulesInDevice> TblModulesInDevices { get; set; } = new List<TblModulesInDevice>();
}
