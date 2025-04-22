using System;
using System.Collections.Generic;

namespace PE_test.Server.Models;

public partial class TblDcvalue
{
    public int DcvalueId { get; set; }

    public int DevCompId { get; set; }

    public int CompValueId { get; set; }

    public string Caption { get; set; } = null!;

    public int BindingTypeId { get; set; }

    public int? ModuleId { get; set; }

    public int? SerialNo { get; set; }

    public bool IsDeleted { get; set; }

    public int? UnitId { get; set; }

    public short? DcvlimitBindingTypeId { get; set; }

    public virtual TblDataBindingType BindingType { get; set; } = null!;

    public virtual TblComponentValue CompValue { get; set; } = null!;

    public virtual TblDcvlimitBindingType? DcvlimitBindingType { get; set; }

    public virtual TblDeviceComponent DevComp { get; set; } = null!;

    public virtual TblModulesInDevice? Module { get; set; }

    public virtual TblUnit? Unit { get; set; }
}
