using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblValueList
{
    public int ValueListId { get; set; }

    public string Keyword { get; set; } = null!;

    public virtual ICollection<TblComponentValue> TblComponentValues { get; set; } = new List<TblComponentValue>();
}
