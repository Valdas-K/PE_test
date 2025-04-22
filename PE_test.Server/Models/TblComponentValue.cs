using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblComponentValue
{
    public int CompValueId { get; set; }

    public int ComponentId { get; set; }

    public string Keyword { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DataTypeId { get; set; }

    public int UnitId { get; set; }

    public int? ValueListId { get; set; }

    public bool IsCritical { get; set; }

    public bool ForwardOnly { get; set; }

    public short ListOrder { get; set; }

    public double? ValueMin { get; set; }

    public double? ValueMax { get; set; }

    public double? DeltaMin { get; set; }

    public double? DeltaMax { get; set; }

    public bool NullOnError { get; set; }

    public bool IsParamLimitsAvailable { get; set; }

    public bool IsDcvlimitsAvailable { get; set; }

    public bool ForwardGoing { get; set; }

    public virtual TblComponent Component { get; set; } = null!;

    public virtual TblDataType DataType { get; set; } = null!;

    public virtual ICollection<TblDcvalue> TblDcvalues { get; set; } = new List<TblDcvalue>();

    public virtual TblUnit Unit { get; set; } = null!;

    public virtual TblValueList? ValueList { get; set; }
}
