using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblConnType
{
    public int ConnTypeId { get; set; }

    public string Caption { get; set; } = null!;

    public virtual ICollection<TblConnProvider> TblConnProviders { get; set; } = new List<TblConnProvider>();
}
