using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDcvlimitBindingType
{
    public short DcvlimitBindingTypeId { get; set; }

    public string Keyword { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();
}
