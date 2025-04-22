using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDataBindingType
{
    public int BindingTypeId { get; set; }

    public string Keyword { get; set; } = null!;

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();
}
