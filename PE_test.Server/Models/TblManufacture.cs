using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblManufacture
{
    public string Manufacture { get; set; } = null!;

    public string? Description { get; set; }

    public string? ErrorFunction { get; set; }

    public string? ErrorsTableFunction { get; set; }

    public virtual ICollection<TblModuleType> TblModuleTypes { get; set; } = new List<TblModuleType>();
}
