using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDataType
{
    public int DataTypeId { get; set; }

    public string Caption { get; set; } = null!;

    public int DeviceSize { get; set; }

    public string Sqlsize { get; set; } = null!;

    public bool IsSigned { get; set; }

    public bool IsFloat { get; set; }

    public virtual ICollection<TblComponentValue> TblComponentValues { get; set; } = new List<TblComponentValue>();
}
